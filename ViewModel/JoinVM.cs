using System.Collections.Generic;
using System.Linq;

namespace WpfPostgre
{
    internal class JoinVM : ViewModelBase
    {
        public List<Person> Males
        {
            get
            {
                using (var db = new Database())
                {
                    return db.Males.ToList();
                }
            }
        }

        public string MalesCount
        {
            get => $"Количество строк: {Males.Count}";
        }

        public List<Company> Companies
        {
            get
            {
                using (var db = new Database())
                {
                    return db.Companies.ToList();
                }
            }
        }

        public string CompaniesCount
        {
            get => $"Количество строк: {Companies.Count}";
        }
         
        public List<JoinResult> RightAntiJoin
        {
            get
            {
                using (var db = new Database())
                {
                    var result =
                        from c in Companies
                        join m in Males
                        on c.CompanyINN equals m.CompanyINN into tempStorage
                        from tempElem in tempStorage.DefaultIfEmpty()
                        where tempElem is null
                        select new JoinResult() { GUID = tempElem?.GUID, Name = tempElem?.Name, Surname = tempElem?.Surname, Company = c.Name };

                    return result.ToList();
                }
            }
        }

        public List<JoinResult> FullOuterJoin
        {
            get => LeftOuterJoin.Union(RightAntiJoin).ToList();
        }

        public string FullOuterJoinCount
        {
            get => $"Количество строк: {FullOuterJoin.Count}";
        }

        public List<JoinResult> LeftOuterJoin
        {
            get
            {
                using (var db = new Database())
                {
                    var result = 
                        from m in Males
                        join c in Companies
                        // записываем элементы, проходящие по условию, в промежуточное хранилище
                        on m.CompanyINN equals c.CompanyINN into tempStorage
                        // если в хранилище не оказалось элементов, то берем null
                        from tempElem in tempStorage.DefaultIfEmpty()
                        select new JoinResult() { GUID = m.GUID, Name = m.Name, Surname = m.Surname, Company = tempElem?.Name };

                    return result.ToList();
                }
            }
        }

        public string LeftOuterJoinCount
        {
            get => $"Количество строк: {LeftOuterJoin.Count}";
        }

        public List<JoinResult> RightOuterJoin
        {
            get
            {
                using (var db = new Database())
                {
                    var result =
                        from c in Companies
                        join m in Males
                        on c.CompanyINN equals m.CompanyINN into tempStorage
                        from tempElem in tempStorage.DefaultIfEmpty()
                        select new JoinResult() { GUID = tempElem?.GUID, Name = tempElem?.Name, Surname = tempElem?.Surname, Company = c.Name };

                    return result.ToList();
                }
            }
        }

        public string RightOuterJoinCount
        {
            get => $"Количество строк: {RightOuterJoin.Count}";
        }

        public List<JoinResult> InnerJoin
        {
            get
            {
                using (var db = new Database())
                {
                    var result =
                        from m in Males
                        join c in Companies
                        on m.CompanyINN equals c.CompanyINN
                        select new JoinResult() { GUID = m?.GUID, Name = m?.Name, Surname = m?.Surname, Company = c?.Name };

                    return result.ToList();
                }
            }
        }

        public string InnerJoinCount
        {
            get => $"Количество строк: {InnerJoin.Count}";
        }
    }
}

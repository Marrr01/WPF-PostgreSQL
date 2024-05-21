using System.Collections.Generic;
using System.Linq;

namespace WpfPostgre
{
    internal class UnionVM : ViewModelBase
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

        public List<Person> Females
        {
            get => DataStatic.Females;
        }

        public string FemalesCount
        {
            get => $"Количество строк: {Females.Count}";
        }

        public List<Person> Persons
        {
            get => Males.Union(Females).Where(p => p.CompanyINN != string.Empty).ToList();
        }

        public string PersonsCount
        {
            get => $"Количество строк: {Persons.Count}";
        }
    }
}

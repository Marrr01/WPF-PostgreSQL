using System;

namespace WpfPostgre
{
    internal class Person
    {
        public string GUID { get; private set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyINN { get; set; }
        public Person(string gender, string name, string surname, string companyINN)
        {
            GUID = Guid.NewGuid().ToString();
            Gender = gender;
            Name = name;
            Surname = surname;
            CompanyINN = companyINN;
        }
    }
}

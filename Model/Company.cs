namespace WpfPostgre
{
    internal class Company
    {
        public string CompanyINN { get; set; }
        public string Name { get; set; }
        public Company(string companyINN, string name)
        {
            CompanyINN = companyINN;
            Name = name;
        }
    }
}

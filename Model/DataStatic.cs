using System.Collections.Generic;

namespace WpfPostgre
{
    internal static class DataStatic
    {
        public static List<Person> Females;
        public static List<Person> Persons;

        public static void Initialize()
        {
            Females = new List<Person>();
            Persons = new List<Person>();
        }
    }
}

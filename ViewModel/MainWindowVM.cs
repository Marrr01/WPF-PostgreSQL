using Microsoft.EntityFrameworkCore;

namespace WpfPostgre
{
    internal class MainWindowVM : ViewModelBase
    {
        public MainWindowVM()
        {
            DataGenerator.Initialize();

            // Заполнение базы данных
            using (var db = new Database())
            {
                db.Males.ExecuteDelete();
                db.Companies.ExecuteDelete();

                db.Males.AddRange(DataGenerator.GenerateMales(50));
                db.Companies.AddRange(DataGenerator.Companies);

                db.SaveChanges();
            }

            // Заполнение статического класса
            DataStatic.Initialize();
            DataStatic.Females.AddRange(DataGenerator.GenerateFemales(50));
            DataStatic.Persons.AddRange(DataGenerator.GeneratePersons(50));

            JoinVM = new JoinVM();
            UnionVM = new UnionVM();
        }

        private object joinVM;
        public object JoinVM
        {
            get { return joinVM; }
            set { joinVM = value; OnPropertyChanged(); }
        }

        private object unionVM;
        public object UnionVM
        {
            get { return unionVM; }
            set { unionVM = value; OnPropertyChanged(); }
        }
    }
}

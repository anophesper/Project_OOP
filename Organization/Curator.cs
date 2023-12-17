using Project.Object;

namespace Project.Organization
{
    public class Curator
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Any(char.IsDigit) || value.Length < 2)
                    throw new Exception("Name can't be < 2 or contain numbers");
                name = value;
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (value.Any(char.IsDigit) || value.Length < 2)
                    throw new Exception("Surname can't be < 2 or contain numbers");
                surname = value;
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new Exception("Age can't be < 0");
                age = value;
            }
        }
        public List<Exhibition>? Exhibitions { get; set; }

        public Curator(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Exhibitions = new List<Exhibition>();
        }

        //інофрмація про куратора
        public void infoCurator()
        {
            int exhibitionCount = Exhibitions.Count;

            Console.WriteLine($"Curator: Name={Name}, Surname={Surname}, Age={Age}, Number of Exhibitions={exhibitionCount}");
        }

        //Створення нової виставки
        public Exhibition AddExhibition(string name, DateTime start, DateTime end, IPresentable place, List<ArtObject>? artworks)
        {
            try
            {
                Exhibition newExhibition = new Exhibition(name, start, end, place, artworks);

                Exhibitions.Add(newExhibition);
                return newExhibition; // Повернути створений об'єкт
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; // Виникла помилка
            }
        }
    }
}
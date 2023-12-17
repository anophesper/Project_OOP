using Project.Object;

namespace Project.Organization
{
    public class Owner
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

        public List<IPresentable> Places { get; set; }

        // Конструктор з параметрами
        public Owner(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Places = new List<IPresentable>();
        }

        //вивід інформації
        public void infoOwner()
        {
            int museumCount = Places.OfType<Museum>().Count();
            int galleryCount = Places.OfType<Gallery>().Count();

            Console.WriteLine($"Owner: Name={Name}, Surname={Surname}, Age={Age}, Number of Museums={museumCount}, Number of Galleries={galleryCount}");
        }

        //додання нового місця де можуть проводитись виставки
        public IPresentable AddPlace(string name, string address, Owner owner, List<ArtObject>? artworks, bool isMuseum)
        {
            try
            {
                IPresentable newPlace;
                if (isMuseum)
                    newPlace = new Museum(name, address, owner, artworks);
                else
                    newPlace = new Gallery(name, address, owner, artworks);

                Places.Add(newPlace);
                return newPlace; // Повернути створений об'єкт
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; // Виникла помилка
            }
        }
    }
}
using Project.EnumType;

namespace Project.Object
{
    public class Artist
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 2 || value.Any(char.IsDigit))
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
                if (value.Length < 2 || value.Any(char.IsDigit))
                    throw new Exception("Surname can't be < 2 or contain numbers");
                surname = value;
            }
        }

        private int birthYear;
        public int BirthYear
        {
            get { return birthYear; }
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                    throw new Exception("Birthday year can't be < 0 or > current year");
                birthYear = value;
            }
        }

        private int? deathYear;
        public int? DeathYear
        {
            get { return deathYear; }
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                    throw new Exception("Death year can't be < 0 or more current year");
                deathYear = value;
            }
        }

        public List<ArtObject>? ArtObjects { get; set; }

        // Конструктор з параметрами
        public Artist(string name, string surname, int birthYear, int? deathYear = null)
        {
            Name = name;
            Surname = surname;
            BirthYear = birthYear;
            DeathYear = deathYear;
            ArtObjects = new List<ArtObject>();
        }

        //вивід інформації
        public void infoArtist()
        {
            int paintingCount = ArtObjects?.OfType<Painting>().Count() ?? 0;
            int sculptureCount = ArtObjects?.OfType<Sculpture>().Count() ?? 0;

            Console.WriteLine($"Artist: {Name} {Surname}, Birth Year: {BirthYear}");
            if (DeathYear != null)
                Console.WriteLine($"Death Year: {DeathYear}");
            Console.WriteLine($"Number of Paintings: {paintingCount}, Number of Sculptures: {sculptureCount}");
        }

        //створення арт об'єкта
        public ArtObject CreateArtObject(int id, string name, int? yearOfCreation, Artist artist, float height, float weight, Materials material, MethodOfCreation creation)
        {
            try{
                Sculpture newSculpture = new Sculpture(id, name, yearOfCreation, artist, height, weight, material, creation);
                ArtObjects.Add(newSculpture);
                return newSculpture; // Return the created Art object
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; // An error occurred
            }
        }

        //створення арт об'єкта
        public ArtObject CreateArtObject(int id, string name, int? yearOfCreation, Artist artist, string canvaSize, Style stylePic, Paint material)
        {
            try{
                Painting newPainting = new Painting(id, name, yearOfCreation, artist, canvaSize, stylePic, material);
                ArtObjects.Add(newPainting);
                return newPainting; // Return the created Art object
            }
            catch (Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null; // An error occurred
            }
        }
    }
}

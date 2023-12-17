namespace Project.Object
{
    public abstract class ArtObject
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name can't be null");
                name = value;
            }
        }

        private int? yearofCreation;
        public int? YearofCreation
        {
            get { return yearofCreation; }
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                    throw new Exception("Year can't be < 0 or > current year");
                yearofCreation = value;
            }
        }

        internal Artist Artist { get; set; }
        public bool IsInVenue { get; set; }

        // Конструктор з параметрами для ініціалізації властивостей базового класу ArtObject
        protected ArtObject(int id, string name, int? yearOfCreation, Artist artist)
        {
            Id = id;
            Name = name;
            YearofCreation = yearOfCreation;
            Artist = artist;
            IsInVenue = false;
        }

        //вивід інформації
        public virtual void infoArtObject()
        {
            Console.WriteLine($"Art Object: Name={Name}, Created by: {Artist.Name} {Artist.Surname}");
            if (YearofCreation != null)
            {
                Console.WriteLine($"Year of Creation={YearofCreation}");
            }
        }
    }
}

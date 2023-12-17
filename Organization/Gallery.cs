using Project.Object;

namespace Project.Organization
{
    public class Gallery : IPresentable
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Any(char.IsDigit) || value.Length < 2)
                    throw new Exception("Назва не може містити цифри та бути менше двох літер");
                name = value;
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                if (value.Length < 5)
                    throw new Exception("Адреса не може бути менше 5 літер");
                address = value;
            }
        }

        public Owner Owner { get; set; }
        public List<ArtObject>? ArtWorks { get; set; }

        public Gallery(string name, string address, Owner owner, List<ArtObject>? artworks)
        {
            Name = name;
            Address = address;
            this.Owner = owner;
            ArtWorks = artworks;
        }

        //вивід інформації
        public virtual void info()
        {
            Console.WriteLine($"Gallery: Name={Name}, Address={Address}, Owner={Owner.Name}, Number of Artworks={ArtWorks?.Count ?? 0}");
        }

        //додавання нових арт об'єктів до вже існуючого об'єкта Gallery
        public bool AddArtwork(ArtObject artwork)
        {
            try
            {
                if (artwork == null)
                {
                    Console.WriteLine("Artwork cannot be null");
                    return false; // Artwork is null
                }

                if (ArtWorks == null)
                    ArtWorks = new List<ArtObject>();
                ArtWorks.Add(artwork);
                artwork.IsInVenue = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // An error occurred
            }
        }

    }
}

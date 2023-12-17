using Project.Object;

namespace Project.Organization
{
    public class Exhibition
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value < StartDate)
                    throw new Exception("EndDate can't be earlier than StartDate");
                endDate = value;
            }
        }

        public IPresentable Place { get; set; }
        public List<ArtObject>? ExhibitionObjects { get; set; }

        public Exhibition(string name, DateTime startDate, DateTime endDate, IPresentable place, List<ArtObject>? exhibitionObjects)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Place = place;
            ExhibitionObjects = exhibitionObjects ?? new List<ArtObject>();
        }

        public void infoExhibition()
        {
            int artObjectCount = ExhibitionObjects.Count;

            Console.WriteLine($"Exhibition: Name={Name}, StartDate={StartDate}, EndDate={EndDate}, Place={Place}, Number of ArtObjects={artObjectCount}");
        }

        // Додавання нового об'єкта мистецтва до виставки
        public bool AddArtObject(ArtObject newArtObject)
        {
            try
            {
                if (newArtObject == null)
                {
                    Console.WriteLine("Artwork cannot be null");
                    return false; // Artwork is null
                }

                ExhibitionObjects.Add(newArtObject);
                return true; // Об'єкт мистецтва успішно додано
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Виникла помилка
            }
        }

        //метод для зміни дати
        public bool ChangeDate(DateTime newStartDate, DateTime newEndDate)
        {
            try
            {
                if (newEndDate < newStartDate)
                    throw new Exception("New EndDate can't be earlier than new StartDate");

                StartDate = newStartDate;
                EndDate = newEndDate;

                return true; // Дата успішно змінена
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Виникла помилка
            }
        }
    }
}

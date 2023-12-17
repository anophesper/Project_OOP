using Project.EnumType;

namespace Project.Object
{
    public class Sculpture : ArtObject
    {
        private float height;
        public float Height
        {
            get { return height; }
            set
            {
                if (value < 0 || value.ToString().Any(char.IsLetter))
                    throw new Exception("Height must be a number and can't be < 0");
                height = value;
            }
        }

        private float weight;
        public float Weight
        {
            get { return weight; }
            set
            {
                if (value < 0 || value.ToString().Any(char.IsLetter))
                    throw new Exception("Weight must be a number and can't be < 0");
                weight = value;
            }
        }

        public Materials Material { get; set; }
        public MethodOfCreation Creation { get; set; }

        // Конструктор з параметрами, який викликає конструктор базового класу ArtObject
        public Sculpture(int id, string name, int? yearOfCreation, Artist artist, float height, float weight, Materials material, MethodOfCreation creation)
            : base(id, name, yearOfCreation, artist)
        {
            Height = height;
            Weight = weight;
            Material = material;
            Creation = creation;
        }

        //вивід інформації
        public override void infoArtObject()
        {
            base.infoArtObject(); // Викликати метод базового класу для виведення загальної інформації

            // Додаткова інформація, специфічна для класу Sculpture
            Console.WriteLine($"Height: {Height}, Weight: {Weight}, Material: {Material}, Creation Method: {Creation}");
        }
    }
}

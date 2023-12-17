using Project.EnumType;

namespace Project.Object
{
    public class Painting : ArtObject
    {
        public string CanvaSize { get; set; }
        public Style StylePic { get; set; }
        public Paint Material { get; set; }

        // Конструктор з параметрами для ініціалізації властивостей класу Painting та його базового класу ArtObject
        public Painting(int id, string name, int? yearOfCreation, Artist artist, string canvaSize, Style stylePic, Paint material)
            : base(id, name, yearOfCreation, artist)
        {
            CanvaSize = canvaSize;
            StylePic = stylePic;
            Material = material;
        }

        //вивід інформації
        public override void infoArtObject()
        {
            base.infoArtObject(); // Викликати метод базового класу для виведення загальної інформації

            // Додаткова інформація, специфічна для класу Painting
            Console.WriteLine($"Canvas Size: {CanvaSize}, Style: {StylePic}, Material: {Material}");
        }
    }
}

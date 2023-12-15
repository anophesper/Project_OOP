using Project.Enum;

namespace Project.Object
{
    public class Painting : ArtObject
    {
        public string CanvaSize { get; set; }
        public Style StylePic { get; set; }
        public Paint Material { get; set; }

        public Painting() { }

        public override void infoArtObject()
        {
            throw new NotImplementedException();
        }
    }
}

using Project.Enum;

namespace Project.Object
{
    public class Sculpture : ArtObject
    {
        public float Height { get; set; }
        public float Weight { get; set; }
        public Materials Material { get; set; }
        public MethodOfCreation Creation { get; set; }

        public Sculpture() { }

        public override void infoArtObject()
        {
            throw new NotImplementedException();
        }
    }
}

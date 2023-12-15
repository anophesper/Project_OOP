using Project.Object;

namespace Project.Organization
{
    public class Gallery : IPresentable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Owner owner { get; set; }
        public List<ArtObject>? ArtWorks { get; set; }

        public Gallery() { }

        public void info()
        {
            throw new NotImplementedException();
        }
    }
}

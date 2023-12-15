using Project.Object;

namespace Project.Organization
{
    public class Museum : IPresentable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Owner owner { get; set; }
        public List<ArtObject>? ArtWorks { get; set; }

        public Museum() { }

        public void info()
        {
            throw new NotImplementedException();
        }
    }
}

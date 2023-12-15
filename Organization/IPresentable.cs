using System.Buffers;
using Project.Object;

namespace Project.Organization
{
    public interface IPresentable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Owner owner { get; set; }
        public List<ArtObject>? ArtWorks { get; set; }

        public void info()
        {
            throw new NotImplementedException();
        }
    }
}
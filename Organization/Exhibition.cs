using System.Xml.Linq;
using Project.Object;

namespace Project.Organization
{
    public class Exhibition
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IPresentable Place { get; set; }
        public List<ArtObject>? ExhibitionObjects { get; set; }

        public Exhibition() { }

        public void infoExhibition()
        {
            throw new NotImplementedException();
        }

        public bool AddArtObject(object IPresentable, string name)
        {
            throw new NotImplementedException();
        }

        public bool RemoveArtObject(object IPresentable, string name)
        {
            throw new NotImplementedException();
        }

        public bool ChangeDate()
        {
            throw new NotImplementedException();
        }
    }
}

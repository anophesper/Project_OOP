using Project.Object;

namespace Project.Organization
{
    public interface IPresentable
    {
        string Name { get; set; }
        string Address { get; set; }
        Owner Owner { get; set; }
        List<ArtObject>? ArtWorks { get; set; }
        void info();
        bool AddArtwork(ArtObject artwork);
    }
}
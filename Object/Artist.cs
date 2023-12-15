namespace Project.Object
{
    public class Artist
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthYear { get; set; }
        public DateTime? DeathYear { get; set; }
        public List<ArtObject>? ArtObjects { get; set; }

        public Artist() { }

        public void infoArtist()
        {
            throw new NotImplementedException();
        }

        public bool CreateArtObject()
        {
            throw new NotImplementedException();
        }
    }
}

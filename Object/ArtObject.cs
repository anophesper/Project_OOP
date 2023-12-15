namespace Project.Object
{
    public abstract class ArtObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearofCreation { get; set; }
        internal Artist Artist { get; set; }

        public ArtObject() { }

        public virtual void infoArtObject()
        {
            throw new NotImplementedException();
        }
    }
}

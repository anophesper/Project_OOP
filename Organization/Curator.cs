namespace Project.Organization
{
    public class Curator
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Exhibition>? Exhibitions { get; set; }

        public Curator() { }

        public void infoCurator()
        {
            throw new NotImplementedException();
        }

        public bool AddExhibition()
        {
            throw new NotImplementedException();
        }

        public bool RemoveExhibition()
        {
            throw new NotImplementedException();
        }
    }
}
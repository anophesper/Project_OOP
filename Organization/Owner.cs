namespace Project.Organization
{
    public class Owner
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<IPresentable> Places { get; set; }

        public Owner() { }

        public void infoOwner()
        {
            throw new NotImplementedException();
        }

        public bool AddPlace()
        {
            throw new NotImplementedException();
        }

        public bool DeletePlace()
        {
            throw new NotImplementedException();
        }
    }
}
namespace Roadway.Data.Entities
{
    public class Brand : IAgregateRoot
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public bool Removed { get; set; }
        
    }
}

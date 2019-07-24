namespace Roadway.Data.Entities
{
    public class Brand : IAggregateRoot
    {
        public int Id { get; set; }
        public bool Disabled { get; set; }

        public string Name { get; set; }

    }
}

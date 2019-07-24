namespace Roadway.Data.Entities
{
    public interface IAggregateRoot
    {
        int Id { get; set; }
        bool Disabled { get; set; }
    }
}
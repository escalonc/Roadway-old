namespace Roadway.Data.Entities
{
    public interface IAgregateRoot
    {
        int Id { get; set; }
        bool Removed { get; set; }
    }
}
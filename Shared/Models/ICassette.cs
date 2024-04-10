namespace Shared.Models
{
    public interface ICassette
    {
        int Id { get; set; }
        string Name { get; }
        int Quantity { get; }
    }
}

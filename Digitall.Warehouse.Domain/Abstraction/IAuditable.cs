namespace Digitall.Warehouse.Domain.Abstraction
{
    public interface IAuditable
    {
        DateTime? CreatedAt { get; set; }

        DateTime? ModifiedAt { get; set; }
    }
}

namespace Digitall.Warehouse.Application.Contracts.Responses;

public class PaginatedResponseT<TResponseItem>(List<TResponseItem> items)
    where TResponseItem : class
{
    public List<TResponseItem> Items { get; set; } = items;
}

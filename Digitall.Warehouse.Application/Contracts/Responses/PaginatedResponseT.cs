namespace Digitall.Warehouse.Application.Contracts.Responses
{
    public class PaginatedResponseT<TResponseItem>
        where TResponseItem : class
    {
        public PaginatedResponseT(List<TResponseItem> items)
        {
            Items = items;
        }

        public List<TResponseItem> Items { get; set; } = [];
    }
}

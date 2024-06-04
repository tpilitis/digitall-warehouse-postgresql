using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Domain.Exceptions
{
    public static class DomainErrors
    {
        public static class ProductVariant
        {
            public static Error DuplicatedItemBySize => new("ProductVariant.DuplicatedItem", "An item with specifcied size already exists.");
        }
    }
}

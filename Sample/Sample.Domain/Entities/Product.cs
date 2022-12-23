using Common.Wrappers;

namespace Sample.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}

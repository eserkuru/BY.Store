using BY.Store.Domain.Base;

namespace BY.Store.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

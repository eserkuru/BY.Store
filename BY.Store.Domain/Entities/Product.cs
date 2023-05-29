using BY.Store.Domain.Base;

namespace BY.Store.Domain.Entities
{
    /// <summary>
    /// It is the class that contains the product information.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// It is the field that represents the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// It is the field that represents the price of the product.
        /// </summary>
        public double Price { get; set; }
    }
}
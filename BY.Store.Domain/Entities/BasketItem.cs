using BY.Store.Domain.Base;

namespace BY.Store.Domain.Entities
{
    /// <summary>
    /// This class keeps the information of the product items in the basket.
    /// </summary>
    public class BasketItem : BaseEntity
    {
        /// <summary>
        /// In the basket, it keeps the information of which basket the product belongs to.
        /// </summary>
        public int BasketId { get; set; }

        /// <summary>
        /// It is the field that holds the product information in the basket.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// It is the field that holds the amount of product added to the cart.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// It is the field that holds the unit price of the product added to the cart.
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// It is the field that holds the total price of the product added to the cart according to the quantity.
        /// </summary>
        public double TotalPrice { get; set; }
    }
}

using BY.Store.Application.Interfaces;

namespace BY.Store.Application.Dtos.Custom.Basket
{
    /// <summary>
    /// It contains the information needed for creating a basket 
    /// with the selected product and adding products to the existing basket.
    /// </summary>
    public class AddProductToBasketDto : IDto
    {
        /// <summary>
        /// Represents the product to be added to the cart.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// It represents the amount of product added to the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}

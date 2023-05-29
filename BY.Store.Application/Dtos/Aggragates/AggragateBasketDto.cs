using BY.Store.Application.Interfaces;
using BY.Store.Application.Dtos.Master;

namespace BY.Store.Application.Dtos.Aggragates
{
    public class AggragateBasketDto : IDto
    {
        /// <summary>
        /// It is the information of which customer the cart belongs to.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// It is the field that holds the total price of the products in the basket.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// It is the field that holds the total basket amount.
        /// </summary>
        public double TotalAmount { get; set; }

        public List<BasketItemDto>? BasketItems { get; set; }
    }
}

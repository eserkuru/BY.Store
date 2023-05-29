using BY.Store.Domain.Base;

namespace BY.Store.Domain.Entities
{
    /// <summary>
    /// It is the class that contains the customer basket information.
    /// </summary>
    public class Basket : BaseEntity
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
        public double TotalAmount { get; set; } // INFO: Bu alan kargo bedeli, iskonto vs. gibi kalemlerin eklenmesi ihtimaline karşın koyulmuştur. Şuan için TotalPrice ile aynı veriyi tutmaktadır.
    }
}
namespace BY.Store.Application.Dtos.Master
{
    /// <summary>
    /// It is the class that contains the product information.
    /// </summary>
    public class ProductDto : BaseDto
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

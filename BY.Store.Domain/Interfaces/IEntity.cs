namespace BY.Store.Domain.Interfaces
{
    /// <summary>
    /// The entity represents its identity and basic needs to its objects.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the entity created time
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the entity created by
        /// </summary>
        int CreatedBy { get; set; }
    }
}

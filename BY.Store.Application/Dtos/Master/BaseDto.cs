using BY.Store.Application.Interfaces;

namespace BY.Store.Application.Dtos.Master
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public class BaseDto : IDto
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the entity created time
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the entity created by
        /// </summary>
        public int CreatedBy { get; set; }
    }
}

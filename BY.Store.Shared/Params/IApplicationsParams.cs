using BY.Store.Domain.Entities;

namespace BY.Store.Shared.Params
{
    public interface IApplicationParams
    {
        int CurrentCustomerId { get; set; }
        bool IsAppStarted { get; set; }
    }
}

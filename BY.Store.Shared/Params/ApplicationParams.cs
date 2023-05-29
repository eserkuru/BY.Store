using BY.Store.Domain.Entities;

namespace BY.Store.Shared.Params
{
    public class ApplicationParams : IApplicationParams
    {
        public bool IsAppStarted { get; set; } 
        public int CurrentCustomerId { get; set; } // INFO: Bu alan eğer bir token mekanizması vb. yöntemler kullanılıyorsa oradan alınması gerekir.
    }
}

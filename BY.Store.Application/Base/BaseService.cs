using AutoMapper;
using BY.Store.Application.Interfaces;
using BY.Store.Shared.Params;

namespace BY.Store.Application.Base
{
    public class BaseService : IService
    {
        protected readonly IApplicationParams _applicationParams;
        protected readonly IMapper _mapper;
        public BaseService(IApplicationParams applicationParams, IMapper mapper)
        {
            _applicationParams = applicationParams;
            _mapper = mapper;
        }
    }
}

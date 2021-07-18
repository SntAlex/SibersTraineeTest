using AutoMapper;

namespace Sibers.Services.Services.Base
{
    /// <summary>
    /// Базовый сервис
    /// </summary>
    public abstract class BaseService
    {
        protected readonly IMapper mapper;

        #region constructor
        protected BaseService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion
    }
}

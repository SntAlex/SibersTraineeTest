using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Sibers.WebApi.Controllers.Base
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    [ApiController]
    [Route("api/v1/ProjectEmployee/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper mapper;

        #region constructor
        protected BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion
    }
}

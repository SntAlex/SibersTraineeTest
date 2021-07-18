using Sibers.Services.Exceptions.Base;

namespace Sibers.Services.Exceptions
{
    public class NotFoundException : BaseBllException
    {
        #region constructor
        public NotFoundException(string message) : base(message)
        {
        }
        #endregion
    }
}

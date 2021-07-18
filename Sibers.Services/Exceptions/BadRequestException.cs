using Sibers.Services.Exceptions.Base;

namespace Sibers.Services.Exceptions
{
    public class BadRequestException : BaseBllException
    {
        #region constructor
        public BadRequestException(string message) : base(message)
        {
        }
        #endregion
    }
}

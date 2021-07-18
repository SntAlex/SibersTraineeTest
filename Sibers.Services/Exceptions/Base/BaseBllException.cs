using System;

namespace Sibers.Services.Exceptions.Base
{
    [Serializable]
    public abstract class BaseBllException : Exception
    {
        #region constructor
        protected BaseBllException(string message) : base(message)
        {
        }
        #endregion
    }
}

using System;

namespace Sibers.Services.Exceptions.Base
{
    /// <summary>
    /// Базовый класс исключения
    /// </summary>
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

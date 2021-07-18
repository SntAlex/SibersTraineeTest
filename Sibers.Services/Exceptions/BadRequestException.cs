using Sibers.Services.Exceptions.Base;

namespace Sibers.Services.Exceptions
{
    public class BadRequestException : BaseBllException
    {
        /// <summary>
        /// Исключение при проблеме в исполнении запроса
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        #region constructor
        public BadRequestException(string message) : base(message)
        {
        }
        #endregion
    }
}

using Sibers.Services.Exceptions.Base;

namespace Sibers.Services.Exceptions
{
    public class NotFoundException : BaseBllException
    {
        /// <summary>
        /// Исключение при отсутсвии сущности в системе
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        #region constructor
        public NotFoundException(string message) : base(message)
        {
        }
        #endregion
    }
}

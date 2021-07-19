namespace Sibers.WebApi.Enums
{
    /// <summary>
    /// Возможные способы сортировки проектов
    /// </summary>
    public enum ProjectSortingSettings
    {
        /// <summary>
        /// Название проекта
        /// </summary>
        ProjectName = 1,

        /// <summary>
        /// Имя заказчика
        /// </summary>
        ClientName = 2,

        /// <summary>
        /// Имя исполнителя
        /// </summary>
        ContractorName = 3,

        /// <summary>
        /// Дата начала проекта
        /// </summary>
        StartingDate = 4,

        /// <summary>
        /// Дата окончания проекта
        /// </summary>
        EndingDate = 5,

        /// <summary>
        /// Приоритет
        /// </summary>
        Priority = 6
    }
}

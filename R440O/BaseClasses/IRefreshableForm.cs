namespace R440O.BaseClasses
{
    /// <summary>
    /// Интерфейс, необходимый для реализации всеми формами приложения.
    /// </summary>
    public interface IRefreshableForm
    {
        /// <summary>
        /// Обновление состояния элемнтов, отображаемых на форме.
        /// </summary>
        void RefreshFormElements();
    }
}
using Kesco.Lib.BaseExtention.Enums.Docs;

namespace Kesco.Lib.Web.Settings.Parameters
{
    /// <summary>
    ///     Класс параметра приложения
    /// </summary>
    public class AppParameter
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Значение</param>
        /// <param name="type">Тип</param>
        public AppParameter(string name, string value, AppParamType type)
        {
            Name = name;
            Value = value;
            SaveType = type;
        }

        /// <summary>
        ///     Имя параметра
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Значение параметра
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Тип сохранения параметра
        /// </summary>
        public AppParamType SaveType { get; set; }
    }
}
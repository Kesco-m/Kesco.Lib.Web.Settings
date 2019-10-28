using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace Kesco.Lib.Web.Settings
{
    /// <summary>
    ///     Корпоративные настройки, связанные с региональными параметрами: форматы вывода чисел, дат...
    /// </summary>
    public class CorporateCulture
    {
        /// <summary>
        ///     Объект для блокировки доступа к словарю культур, когда процесс пытается добавить новый элемент.
        /// </summary>
        private static readonly object culturesWithCorporateSettingsCacheLock = new object();


        /// <summary>
        ///     Кеш, содержащий региональные настройки для разных языков, адаптированные к корпоративным настройкам
        /// </summary>
        private static volatile CultureDictionary culturesWithCorporateSettingsCache = new CultureDictionary();


        /// <summary>
        ///     Вовзвращает адаптированные региональные настройки
        /// </summary>
        /// <param name="culture">идентификатор культуры</param>
        /// <returns>Сведения об языке и региональных параметрах</returns>
        public static CultureInfo GetCorporateCulture(string culture)
        {
            InitCultureWithCorporateSettings(culture);
            return culturesWithCorporateSettingsCache[culture];
        }


        /// <summary>
        ///     Инициализирует языковой стандарт (сведения об языке и региональных параметрах) в соотвествии с корпоративными
        ///     стандартами
        /// </summary>
        /// <param name="culture">идентификатор культуры</param>
        private static void InitCultureWithCorporateSettings(string culture)
        {
            if (!culturesWithCorporateSettingsCache.ContainsKey(culture))
                lock (culturesWithCorporateSettingsCacheLock)
                {
                    // двойная проверка
                    if (!culturesWithCorporateSettingsCache.ContainsKey(culture))
                    {
                        var ci = Config.ToCorporateCulture(CultureInfo.CreateSpecificCulture(culture));
                        culturesWithCorporateSettingsCache.Add(culture, ci);
                    }
                }
        }

        #region Nested type: CultureDictionary

        /// <summary>
        ///     Словарь для хранения региональных настроек (язык --> настройки)
        /// </summary>
        private class CultureDictionary : NameObjectCollectionBase
        {
            private DictionaryEntry _de;

            public CultureDictionary()
            {
            }

            /// <summary>
            ///     Adds elements from an IDictionary into the new collection.
            /// </summary>
            public CultureDictionary(IDictionary d, bool bReadOnly)
            {
                foreach (DictionaryEntry de in d) BaseAdd((string) de.Key, de.Value);
                IsReadOnly = bReadOnly;
            }

            /// <summary>
            ///     Gets a key-and-value pair (DictionaryEntry) using an index.
            /// </summary>
            public DictionaryEntry this[int index]
            {
                get
                {
                    _de.Key = BaseGetKey(index);
                    _de.Value = BaseGet(index);
                    return _de;
                }
            }

            public CultureInfo this[string key]
            {
                get { return (CultureInfo) BaseGet(key); }
                set { BaseSet(key, value); }
            }

            public string[] AllKeys => BaseGetAllKeys();

            public Array AllValues => BaseGetAllValues();

            public CultureInfo[] AllCultureInfoValues =>
                (CultureInfo[]) BaseGetAllValues(Type.GetType("System.Globalization.CultureInfo"));

            public bool HasKeys => BaseHasKeys();

            public bool ContainsKey(string key)
            {
                foreach (var s in BaseGetAllKeys())
                    if (s == key)
                        return true;

                return false;
            }

            public void Add(string key, CultureInfo value)
            {
                BaseAdd(key, value);
            }

            public void Remove(string key)
            {
                BaseRemove(key);
            }

            public void Remove(int index)
            {
                BaseRemoveAt(index);
            }

            public void Clear()
            {
                BaseClear();
            }
        }

        #endregion
    }
}
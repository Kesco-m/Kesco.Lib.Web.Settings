using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;

namespace Kesco.Lib.Web.Settings
{   
    /// <summary>
    /// Класс получения настроек web-приложения
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Индентификатор русской культуры приложения
        /// </summary>
        public const string langRu = "ru";

        /// <summary>
        /// Индентификатор английской культуры приложения
        /// </summary>
        public const string langEn = "en";

        /// <summary>
        /// SMTP-сервер, через который отправляет сообщения об исключительных ситуациях Kesco.Lib.Log
        /// </summary>
        public static string smtpServer;

        /// <summary>
        /// Почтовый ящик службы поддержки, в который попадают сообщения, отправляемые Kesco.Lib.Log
        /// </summary>
        public static string email_Support;

        /// <summary>
        /// Название текущего приложения
        /// </summary>
        public static string appName;

        /// <summary>
        /// Адрес сервера отчетов Reporting Service
        /// </summary>
        public static string uri_Report;

        /// <summary>
        /// Дата перехода на новые названия инкотермс в таможенном классификаторе
        /// </summary>
        public static DateTime incoterms_date = DateTime.MaxValue;

        /// <summary>
        /// Текущая версия 1С бухгалтерии
        /// </summary>
        public static string version_1s_buh;

        /// <summary>
        /// HTTP-адрес отчета "Акт сверки"
        /// </summary>
        public static string rpt_tradeSverka;

        /// <summary>
        /// HTTP-адрес отчета "Реестр отгруженных вагонов"
        /// </summary>
        public static string rpt_rwreestr;

        /// <summary>
        /// HTTP-адрес отчета "Сводка по отправленным вагонам"
        /// </summary>
        public static string rpt_deliverySvodka;

        /// <summary>
        /// HTTP-адрес отчета "Отчет агента"
        /// </summary>
        public static string rpt_tradeSverkaAgent;

        /// <summary>
        /// HTTP-адрес отчета "Оборотная ведомость"
        /// </summary>
        public static string rpt_tradeOborotka;

        /// <summary>
        /// HTTP-адрес отчета "Оборотная ведомость с детализацией"
        /// </summary>
        public static string rpt_tradeOborotkaDetail;

        /// <summary>
        /// HTTP-адрес web-сервиса сервера отчетов
        /// </summary>
        public static string report_srv;

        /// <summary>
        /// Строка подключения к БД Справочники, использовать для получения информации по лицам
        /// </summary>
        public static string DS_person;

        /// <summary>
        /// Строка подключения к БД Документы, использовать для получения информации по документам
        /// </summary>
        public static string DS_document;

        /// <summary>
        /// Строка подключения к БД Инвентаризация, использовать для получения по всем сущностям Corporate
        /// </summary>
        public static string DS_user;

        /// <summary>
        /// Строка подключения к БД Справочники, использовать для получения информации по ресурсам
        /// </summary>
        public static string DS_resource;

        /// <summary>
        /// Строка подключения к БД Бухгалтерия, использовать для получения информации с объектами бухгалтерий 1С
        /// </summary>
        public static string DS_Buh;

        /// <summary>
        /// Строка подключения к БД Тарификация, использовать для получения информации по тарификации мобильной и стационарной связи
        /// </summary>
        public static string DS_accounting_phone;

        /// <summary>
        /// HTTP-адрес формы поиска лиц
        /// </summary>
        public static string person_search;

        /// <summary>
        /// HTTP-адрес формы досье лиц
        /// </summary>
        public static string person_form;

        /// <summary>
        /// HTTP-адрес формы роли
        /// </summary>
        public static string role_form;

        /// <summary>
        /// HTTP-адрес формы выбора роли
        /// </summary>
        public static string roles_search;

        /// <summary>
        /// HTTP-адрес формы выбора типов
        /// </summary>
        public static string person_types_search;

        /// <summary>
        /// HTTP-адрес web-сервиса, который возвращает информацию по лицам
        /// </summary>
        public static string person_srv;

        /// <summary>
        /// HTTP-адрес формы создания юридического лица
        /// </summary>
        public static string person_jp_add;

        /// <summary>
        /// HTTP-адрес формы создания физического лица
        /// </summary>
        public static string person_np_add;

        /// <summary>
        /// HTTP-адрес формы поиска складов
        /// </summary>
        public static string store_search;

        /// <summary>
        /// HTTP-адрес формы поиска складов
        /// </summary>
        public static string v4person_themes;

        /// <summary>
        /// HTTP-адрес формы редактирования склада
        /// </summary>
        public static string store_form;

        /// <summary>
        /// HTTP-адрес отчетов по складам
        /// </summary>
        public static string store_report;
        

        /// <summary>
        /// HTTP-адрес web-сервиса, который возвращает информацию по складам
        /// </summary>
        public static string store_srv;

        /// <summary>
        /// HTTP-адрес web-сервиса, который экспортирует данные в 1С
        /// </summary>
        public static string store_export1s;

        /// <summary>
        /// HTTP-адрес формы c фотографиями сотрудника
        /// </summary>
        public static string user_extFields;

        /// <summary>
        /// HTTP-адрес формы c фотографиями сотрудника
        /// </summary>
        public static string user_photo;

        /// <summary>
        /// HTTP-адрес формы c фотографиями сотрудника
        /// </summary>
        public static string user_photos;

        /// <summary>
        /// HTTP-адрес формы поиска сотрудников
        /// </summary>
        public static string user_search;

        /// <summary>
        /// HTTP-адрес формы c информацией о сотруднике
        /// </summary>
        public static string user_form;

        /// <summary>
        /// HTTP-адрес формы замещения сотрудника
        /// </summary>
        public static string user_filling;

        /// <summary>
        /// HTTP-адрес формы c информацией о сотруднике
        /// </summary>
        public static string user_workplace;
        
        /// <summary>
        /// HTTP-адрес web-сервиса, который Возвращает информацию по сотрудникам
        /// </summary>
        public static string user_srv;

        /// <summary>
        /// HTTP-адрес формы поиска ресурсов
        /// </summary>
        public static string resource_search;

        /// <summary>
        /// HTTP-адрес формы поиска мест хранения
        /// </summary>
        public static string residences_search;

        /// <summary>
        /// HTTP-адрес формы редактирования/создания ресурса
        /// </summary>
        public static string resource_form;

        /// <summary>
        /// HTTP-адрес web-сервиса, который возвращает информацию по ресурсам
        /// </summary>
        public static string resource_srv;

        /// <summary>
        /// HTTP-адрес формы поиска бизнес-проектов
        /// </summary>
        public static string business_project_search;

        /// <summary>
        /// HTTP-адрес web-сервиса, который возвращает информацию по бизнес-проектам
        /// </summary>
        public static string bproject_srv;

        /// <summary>
        /// HTTP-адрес формы поиска статей движения денежных средств
        /// </summary>
        public static string cash_flow_item_search;

        /// <summary>
        /// HTTP-адрес формы редактирования статьи движения денежных средств
        /// </summary>
        public static string cash_flow_item_form;

        /// <summary>
        /// HTTP-адрес web-сервиса, который возвращает информацию по статьям движения денежных средств
        /// </summary>
        public static string cash_flow_item_srv;

        /// <summary>
        /// HTTP-адрес формы поиска территорий
        /// </summary>
        public static string area_search;

        /// <summary>
        /// HTTP-адрес web-сервиса, который возвращает информацию территориям
        /// </summary>
        public static string area_srv;

        /// <summary>
        /// HTTP-адрес формы редактирования оборудования
        /// </summary>
        public static string equipment_form;

        /// <summary>
        /// Текущий домен приложения
        /// </summary>
        public static string domain;

        /// <summary>
        /// HTTP-адрес формы поиска отправок вагонов
        /// </summary>
        public static string delivery_search;

        /// <summary>
        /// HTTP-адрес формы редактирования/создания отправки вагона
        /// </summary>
        public static string delivery_form;

        /// <summary>
        /// HTTP-адрес формы поиска розеток
        /// </summary>
        public static string socket_search;

        /// <summary>
        /// HTTP-адрес формы редактирования/создания розетки
        /// </summary>
        public static string socket_form;

        /// <summary>
        /// HTTP-адрес формы поиска телефонного номера
        /// </summary>
        public static string tel_search;

        /// <summary>
        /// HTTP-адрес формы редактирования/создания телефонного номера
        /// </summary>
        public static string tel_form;

        /// <summary>
        /// HTTP-адрес формы поиска расположений
        /// </summary>
        public static string location_search;

        /// <summary>
        /// HTTP-адрес формы поиска моделей оборудования
        /// </summary>
        public static string model_search;

        /// <summary>
        /// HTTP-адрес формы поиска территории
        /// </summary>
        public static string territory_search;

        /// <summary>
        /// HTTP-адрес формы поиска бизнес проекта
        /// </summary>
        public static string bproject_search;
        

        /// <summary>
        /// HTTP-адрес формы редактирования/создания территории
        /// </summary>
        public static string territory_form;

        /// <summary>
        /// HTTP-адрес формы редактирования/создания модели оборудования
        /// </summary>
        public static string model_form;

        /// <summary>
        /// HTTP-адрес папки с корпоративными стилями
        /// </summary>
        public static string styles;

        /// <summary>
        /// HTTP-адрес формы поиска статей бюджета
        /// </summary>
        public static string budgetline_search;

        /// <summary>
        /// HTTP-адрес формы редактирования статей бюджета
        /// </summary>
        public static string budgetline_form;

        /// <summary>
        /// HTTP-адрес web-сервиса сохранения настроей приоложений
        /// </summary>
        public static string setting_srv;

        /// <summary>
        /// HTTP-адрес приложения контакты
        /// </summary>
        public static string contacts;

        /// <summary>
        /// HTTP-адрес web звонилки
        /// </summary>
        public static string contacts_caller;
        
        //v4 persons
        public static string person_requsites_v4;
        public static string person_natural_v4;
        public static string person_juridical_v4;
        public static string person_contact_form_v4;
        public static string person_link_form_v4;
        /// <summary>
        /// статический конструктор, в котором инициализируются все переменные
        /// </summary>
        static Config()
        {
            //person_requsites_v4 = ConfigurationManager.AppSettings["URI_person_requsites_v4"];
            //person_natural_v4 = ConfigurationManager.AppSettings["URI_person_natural_v4"];
            //person_juridical_v4 = ConfigurationManager.AppSettings["URI_person_juridical_v4"];
            //person_contact_form_v4 = ConfigurationManager.AppSettings["URI_person_contact_form_v4"];
            //person_link_form_v4 = ConfigurationManager.AppSettings["URI_person_link_form_v4"];
            bproject_search = ConfigurationManager.AppSettings["URI_bproject_search"];

            domain = ConfigurationManager.AppSettings["Domain"];

            version_1s_buh = ConfigurationManager.AppSettings["Version_1S_Buh"];

            contacts = ConfigurationManager.AppSettings["URI_contacts"];
            contacts_caller = ConfigurationManager.AppSettings["URI_contacts_caller"]; ;

            email_Support = ConfigurationManager.AppSettings["Email_Support"];
            smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            appName = ConfigurationManager.AppSettings["AppName"];

            uri_Report = ConfigurationManager.AppSettings["URI_Report"];

            // Сделано на время - пока параметр не будет добавлен в глобальный web.config
            if (ConfigKeyExists("incoterms_date"))
                incoterms_date = DateTime.ParseExact(ConfigurationManager.AppSettings["incoterms_date"], "yyyy.MM.dd",
                                                     CultureInfo.InvariantCulture);

            ConnectionStringSettingsCollection DS = ConfigurationManager.ConnectionStrings;

            DS_person = CN_Value(DS, "DS_person");
            DS_document = CN_Value(DS, "DS_doc");
            DS_user = CN_Value(DS, "DS_user");
            DS_resource = CN_Value(DS, "DS_resource");
            DS_Buh = CN_Value(DS, "DS_Buh");
            DS_accounting_phone = CN_Value(DS, "DS_accounting_phone");

            territory_search = ConfigurationManager.AppSettings["URI_territory_search"];
            territory_form = ConfigurationManager.AppSettings["URI_territory_form"];
            person_search = ConfigurationManager.AppSettings["URI_person_search"];
            person_form = ConfigurationManager.AppSettings["URI_person_form"];
            person_types_search = ConfigurationManager.AppSettings["URI_theme_search"];
            person_srv = ConfigurationManager.AppSettings["URI_person_srv"];
            person_jp_add = ConfigurationManager.AppSettings["URI_person_jp_add"];
            person_np_add = ConfigurationManager.AppSettings["URI_person_np_add"];
            v4person_themes = ConfigurationManager.AppSettings["URI_v4person_themes"];

            store_search = ConfigurationManager.AppSettings["URI_store_search"];
            store_form = ConfigurationManager.AppSettings["URI_store_form"];
            store_report = ConfigurationManager.AppSettings["URI_store_rptplan"];
            store_srv = ConfigurationManager.AppSettings["URI_store_srv"];
            store_export1s = ConfigurationManager.AppSettings["URI_export"];

            cash_flow_item_search = ConfigurationManager.AppSettings["URI_cashflowitem_search"];
            cash_flow_item_form = ConfigurationManager.AppSettings["URI_cashflowitem_form"];
            cash_flow_item_srv = ConfigurationManager.AppSettings["URI_cashflowitem_srv"];


            user_photo = ConfigurationManager.AppSettings["URI_user_photo"];
            user_photos = ConfigurationManager.AppSettings["URI_user_photos"];
            user_search = ConfigurationManager.AppSettings["URI_user_search"];
            user_form = ConfigurationManager.AppSettings["URI_user_form"];
            user_srv = ConfigurationManager.AppSettings["URI_user_srv"];
            user_extFields = ConfigurationManager.AppSettings["URI_user_extFields"];
            user_workplace = ConfigurationManager.AppSettings["URI_user_workplace"];
            user_filling = ConfigurationManager.AppSettings["URI_user_filling"]; 


            resource_search = ConfigurationManager.AppSettings["URI_resource_search"];
            resource_form = ConfigurationManager.AppSettings["URI_resource_form"];
            resource_srv = ConfigurationManager.AppSettings["URI_resource_srv"];

            residences_search = ConfigurationManager.AppSettings["URI_residences_search"];

            location_search = ConfigurationManager.AppSettings["URI_location_search"];
            socket_search = ConfigurationManager.AppSettings["URI_socket_search"];
            socket_form = ConfigurationManager.AppSettings["URI_socket_form"];
            tel_search = ConfigurationManager.AppSettings["URI_tel_search"];
            tel_form = ConfigurationManager.AppSettings["URI_tel_form"];
            model_search = ConfigurationManager.AppSettings["URI_model_search"];
            model_form = ConfigurationManager.AppSettings["URI_model_form"];

            business_project_search = ConfigurationManager.AppSettings["URI_bproject_search"];
            bproject_srv = ConfigurationManager.AppSettings["URI_bproject_srv"];

            area_search = ConfigurationManager.AppSettings["URI_area_search"];
            area_srv = ConfigurationManager.AppSettings["URI_area_srv"];

            equipment_form = ConfigurationManager.AppSettings["URI_Equipment_form"];

            delivery_form = ConfigurationManager.AppSettings["URI_delivery_form"];
            delivery_search = ConfigurationManager.AppSettings["URI_delivery_search"];

            styles = ConfigurationManager.AppSettings["URI_styles"];

            setting_srv = ConfigurationManager.AppSettings["URI_setting_srv"];

            rpt_tradeSverka = ConfigurationManager.AppSettings["rpt_TradeSverka"];
            rpt_rwreestr = ConfigurationManager.AppSettings["rpt_RWReestr"];
            rpt_deliverySvodka = ConfigurationManager.AppSettings["rpt_DeliverySvodka"];

            rpt_tradeSverkaAgent = ConfigurationManager.AppSettings["rpt_TradeSverkaAgent"];

            rpt_tradeOborotka = ConfigurationManager.AppSettings["rpt_TradeOborotka"];
            rpt_tradeOborotkaDetail = ConfigurationManager.AppSettings["rpt_TradeOborotkaDetail"];
            report_srv = ConfigurationManager.AppSettings["URI_report_srv"];

            budgetline_form = ConfigurationManager.AppSettings["URI_budgetline_form"];
            budgetline_search = ConfigurationManager.AppSettings["URI_budgetline_search"];

            role_form = ConfigurationManager.AppSettings["URI_role_form"];
            roles_search = ConfigurationManager.AppSettings["URI_roles_search"];
        }

        /// <summary>
        /// Получение значения строки подключения из секции connectionStrings файла web.config
        /// </summary>
        /// <param name="DS">Коллекция строк подключения</param>
        /// <param name="id">Идентификтор строки подключения</param>
        /// <returns>Строка подключения</returns>
        private static string CN_Value(ConnectionStringSettingsCollection DS, string id)
        {
            string ret = "";

            if (DS[id] != null)
                ret = DS[id].ConnectionString;


            return ret;
        }


        /// <summary>
        /// Проверка наличия значения в файле конфигурации приложения (web.config)
        /// Значение проверяется в секции appSettings
        /// </summary>
        /// <param name="name">имя параметра</param>
        public static bool ConfigKeyExists(string name)
        {
            var collection = (NameValueCollection) ConfigurationManager.GetSection("appSettings");
            string res = collection.Get(name);
            return res != null;
        }

        /// <summary>
        /// Формирования строки подлючения к SQL-серверу
        /// </summary>
        /// <param name="server">SQL-сервер(название или ip-адрес)</param>
        /// <param name="database">Название базы данных</param>
        /// <returns>Строка подключения</returns>
        public static string GetConnectionString(string server, string database)
        {
            return
                string.Format("data source={0};initial catalog={1};integrated security=SSPI;Current Language=Russian;",
                              server, database);
        }


        /// <summary>
        /// Преобразование региональных настроек к корпоративному формату
        /// </summary>
        /// <param name="ci">региональные настройки, подлежащие преобразованию</param>
        /// <returns>преобразованные региональные настройки</returns>
        public static CultureInfo ToCorporateCulture(CultureInfo ci)
        {
            var corporate = (CultureInfo) ci.Clone();

            corporate.NumberFormat.NumberNegativePattern =
                GetNumberNegativePattern(ConfigurationManager.AppSettings["Culture.Number.NegativePattern"]);
            corporate.NumberFormat.NumberDecimalSeparator =
                ConfigurationManager.AppSettings["Culture.Number.DecimalSeparator"];
            corporate.NumberFormat.NumberGroupSeparator =
                ConfigurationManager.AppSettings["Culture.Number.GroupSeparator"];
            //corporate.NumberFormat.NumberGroupSizes = ConfigurationManager.AppSettings["Culture.Number.GroupSizes"]);
            corporate.NumberFormat.NumberDecimalDigits =
                Int32.Parse(ConfigurationManager.AppSettings["Culture.Number.Decimals"]);

            corporate.NumberFormat.PercentNegativePattern =
                GetPercentNegativePattern(ConfigurationManager.AppSettings["Culture.Percent.NegativePattern"]);
            corporate.NumberFormat.PercentPositivePattern =
                GetPercentPositivePattern(ConfigurationManager.AppSettings["Culture.Percent.PositivePattern"]);
            corporate.NumberFormat.PercentDecimalSeparator =
                ConfigurationManager.AppSettings["Culture.Percent.DecimalSeparator"];
            corporate.NumberFormat.PercentGroupSeparator =
                ConfigurationManager.AppSettings["Culture.Percent.GroupSeparator"];
            //corporate.NumberFormat.PercentGroupSizes = ConfigurationManager.AppSettings["Culture.Percent.GroupSizes.ToArray<int>(new char[] { ',' }, s => Int32.Parse(s))"];
            corporate.NumberFormat.PercentDecimalDigits =
                Int32.Parse(ConfigurationManager.AppSettings["Culture.Percent.Decimals"]);
            corporate.NumberFormat.PercentSymbol = ConfigurationManager.AppSettings["Culture.Percent.Symbol"];

            corporate.NumberFormat.CurrencyNegativePattern =
                GetCurrencyNegativePattern(ConfigurationManager.AppSettings["Culture.Currency.NegativePattern"]);
            corporate.NumberFormat.CurrencyPositivePattern =
                GetCurrencyPositivePattern(ConfigurationManager.AppSettings["Culture.Currency.PositivePattern"]);
            corporate.NumberFormat.CurrencyDecimalSeparator =
                ConfigurationManager.AppSettings["Culture.Currency.DecimalSeparator"];
            corporate.NumberFormat.CurrencyGroupSeparator =
                ConfigurationManager.AppSettings["Culture.Currency.GroupSeparator"];
            //corporate.NumberFormat.CurrencyGroupSizes = ConfigurationManager.AppSettings["Culture.Currency.GroupSizes.ToArray<int>(new char[] { ',' }, s => Int32.Parse(s))"];
            corporate.NumberFormat.CurrencyDecimalDigits =
                Int32.Parse(ConfigurationManager.AppSettings["Culture.Currency.Decimals"]);
            corporate.NumberFormat.CurrencySymbol = ConfigurationManager.AppSettings["Culture.Currency.Symbol"];

            corporate.DateTimeFormat.DateSeparator =
                ConfigurationManager.AppSettings["Culture.DateTime.DatePartsSeparator"];
            corporate.DateTimeFormat.TimeSeparator =
                ConfigurationManager.AppSettings["Culture.DateTime.TimePartsSeparator"];
            corporate.DateTimeFormat.AMDesignator = ConfigurationManager.AppSettings["Culture.DateTime.AM"];
            corporate.DateTimeFormat.PMDesignator = ConfigurationManager.AppSettings["Culture.DateTime.PM"];

            corporate.DateTimeFormat.ShortDatePattern =
                ConfigurationManager.AppSettings["Culture.DateTime.ShortDatePattern"];
            corporate.DateTimeFormat.LongDatePattern =
                ConfigurationManager.AppSettings["Culture.DateTime.LongDatePattern"];
            corporate.DateTimeFormat.ShortTimePattern =
                ConfigurationManager.AppSettings["Culture.DateTime.ShortTimePattern"];
            corporate.DateTimeFormat.LongTimePattern =
                ConfigurationManager.AppSettings["Culture.DateTime.LongTimePattern"];
            corporate.DateTimeFormat.FullDateTimePattern =
                ConfigurationManager.AppSettings["Culture.DateTime.FullDateTimePattern"];

            return corporate;
        }

        /// <summary>
        /// Получение корпоративного формата отображения чисел
        /// </summary>
        /// <param name="negativePattern">Значение шаблона из конфигурационного файла</param>
        /// <returns>Идентификатор шаблона</returns>
        public static int GetNumberNegativePattern(string negativePattern)
        {
            int pattern = 1;
            switch (negativePattern)
            {
                case "(n)":
                    pattern = 0;
                    break;
                case "-n":
                    pattern = 1;
                    break;
                case "- n":
                    pattern = 2;
                    break;
                case "n-":
                    pattern = 3;
                    break;
                case "n -":
                    pattern = 4;
                    break;
            }
            return pattern;
        }

        /// <summary>
        /// Получение корпоративного формата отображения процентов с положительным числом
        /// </summary>
        /// <param name="negativePattern">Значение шаблона из конфигурационного файла</param>
        /// <returns>Идентификатор шаблона</returns>
        public static int GetPercentPositivePattern(string negativePattern)
        {
            int pattern = -1;
            switch (negativePattern)
            {
                case "n %":
                    pattern = 0;
                    break;
                case "n%":
                    pattern = 1;
                    break;
                case "%n":
                    pattern = 2;
                    break;
                case "% n":
                    pattern = 3;
                    break;
            }
            return pattern;
        }

        /// <summary>
        /// Получение корпоративного формата отображения процентов с отрицательным числом
        /// </summary>
        /// <param name="negativePattern">Значение шаблона из конфигурационного файла</param>
        /// <returns>Идентификатор шаблона</returns>
        public static int GetPercentNegativePattern(string negativePattern)
        {
            int pattern = -1;
            switch (negativePattern)
            {
                case "-n %":
                    pattern = 0;
                    break;
                case "-n%":
                    pattern = 1;
                    break;
                case "-%n":
                    pattern = 2;
                    break;
                case "%-n":
                    pattern = 3;
                    break;
                case "%n-":
                    pattern = 4;
                    break;
                case "n-%":
                    pattern = 5;
                    break;
                case "n%-":
                    pattern = 6;
                    break;
                case "-% n":
                    pattern = 7;
                    break;
                case "n %-":
                    pattern = 8;
                    break;
                case "% n-":
                    pattern = 9;
                    break;
                case "% -n":
                    pattern = 10;
                    break;
                case "n- %":
                    pattern = 11;
                    break;
            }
            return pattern;
        }

        /// <summary>
        /// Получение корпоративного формата отображения денежных симовлов при выводе с положительным числом
        /// </summary>
        /// <param name="negativePattern">Значение шаблона из конфигурационного файла</param>
        /// <returns>Идентификатор шаблона</returns>
        public static int GetCurrencyPositivePattern(string negativePattern)
        {
            int pattern = -1;
            switch (negativePattern)
            {
                case "$n":
                    pattern = 0;
                    break;
                case "n$":
                    pattern = 1;
                    break;
                case "$ n":
                    pattern = 2;
                    break;
                case "n $":
                    pattern = 3;
                    break;
            }
            return pattern;
        }

        /// <summary>
        /// Получение корпоративного формата отображения денежных симовлов при выводе с отрицательным числом
        /// </summary>
        /// <param name="negativePattern">Значение шаблона из конфигурационного файла</param>
        /// <returns>Идентификатор шаблона</returns>
        public static int GetCurrencyNegativePattern(string negativePattern)
        {
            int pattern = -1;
            switch (negativePattern)
            {
                case "($n)":
                    pattern = 0;
                    break;
                case "-$n":
                    pattern = 1;
                    break;
                case "$-n":
                    pattern = 2;
                    break;
                case "$n-":
                    pattern = 3;
                    break;
                case "(n$)":
                    pattern = 4;
                    break;
                case "-n$":
                    pattern = 5;
                    break;
                case "n-$":
                    pattern = 6;
                    break;
                case "n$-":
                    pattern = 7;
                    break;
                case "-n $":
                    pattern = 8;
                    break;
                case "-$ n":
                    pattern = 9;
                    break;
                case "n $-":
                    pattern = 10;
                    break;
                case "$ n-":
                    pattern = 11;
                    break;
                case "$ -n":
                    pattern = 12;
                    break;
                case "n- $":
                    pattern = 13;
                    break;
                case "($ n)":
                    pattern = 14;
                    break;
                case "(n $)":
                    pattern = 15;
                    break;
            }
            return pattern;
        }
    }
}
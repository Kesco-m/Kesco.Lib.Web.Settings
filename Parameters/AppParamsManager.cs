using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using Kesco.Lib.BaseExtention.Enums.Docs;
using Kesco.Lib.DALC;
using Convert = Kesco.Lib.ConvertExtention.Convert;

namespace Kesco.Lib.Web.Settings.Parameters
{
    /// <summary>
    /// </summary>
    public class AppParamsManager
    {
        /// <summary>
        ///     Клиент ID
        /// </summary>
        private int _clid;

        /// <summary>
        ///     Словарь параметров со значениями
        /// </summary>
        private List<AppParameter> _params;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="clid">Клиент ID</param>
        /// <param name="paramNames"></param>
        public AppParamsManager(int clid, StringCollection paramNames)
        {
            _clid = clid;
            _params = new List<AppParameter>();
            LoadParams(paramNames);
        }

        /// <summary>
        ///     Аксессор к словарю параметров
        /// </summary>
        public List<AppParameter> Params
        {
            get { return _params; }
            set { _params = value; }
        }

        /// <summary>
        /// </summary>
        public int CLID
        {
            get { return _clid; }
            set { _clid = value; }
        }

        /// <summary>
        ///     Загрузка параметров
        /// </summary>
        private void LoadParams(StringCollection paramNames)
        {
            if (paramNames.Count < 1) return;

            var parametersStr = Convert.Collection2Str(paramNames).Replace(",", "','");

            if (string.IsNullOrWhiteSpace(parametersStr)) return;

            var sqlParams = new Dictionary<string, object> {{"@clid", _clid}};
            var dt = DBManager.GetData(string.Format(SQLQueries.q_НастройкиОбщие_Получить, parametersStr),
                Config.DS_user, CommandType.Text, sqlParams);

            /*
            for (int i = 0; i< dt.Rows.Count; i++)
            {
                string name = dt.Rows[i]["Параметр"].ToString().Trim();
                string value = dt.Rows[i]["Значение"] == DBNull.Value ? string.Empty : dt.Rows[i]["Значение"].ToString();
                AppParamType paramType = (AppParamType)int.Parse(dt.Rows[i]["ТипПараметра"].ToString());
                _params.Add(new AppParameter(name, value, paramType));
            }
            */

            foreach (DataRow r in dt.Rows)
            {
                var dbObj = r["Параметр"];
                var name = dbObj.ToString();

                dbObj = r["Значение"];
                var value = dbObj == DBNull.Value ? string.Empty : dbObj.ToString();

                dbObj = r["ТипПараметра"];
                var paramType = dbObj == DBNull.Value
                    ? AppParamType.NotSaved
                    : (AppParamType) int.Parse(dbObj.ToString());

                //dbObj = r["КодНастройкиКлиента"];
                //int clid = dbObj == DBNull.Value ? 0 : (int)dbObj;

                //В первую очередь добавляем параметры с требуемым _clid
                //if (clid == _clid)
                //    _params.Add(new AppParameter(name, value, paramType));
                //else
                //{
                if (!_params.Exists(p => p.Name == name))
                    _params.Add(new AppParameter(name, value, paramType));
                //}
            }
        }

        /// <summary>
        ///     Сохранение параметров
        /// </summary>
        public void SaveParams()
        {
            foreach (var param in _params)
                if (param.SaveType == AppParamType.AlwaysSaved ||
                    param.SaveType == AppParamType.SavedWithClid && _clid >= 0)
                {
                    var sqlParams = new Dictionary<string, object>(3)
                        {{"@CLID", _clid}, {"@Key", param.Name}, {"@Value", param.Value}};
                    DBManager.ExecuteNonQuery(SQLQueries.q_НастройкиОбщие_Записать, CommandType.Text, Config.DS_user,
                        sqlParams);
                }
        }

        /// <summary>
        ///     Метод получает значение параметра из строки запроса или БД сохраненных параметров
        /// </summary>
        /// <param name="requestQuery">Коллекция переменных строки запроса HTTP</param>
        /// <param name="name">Имя параметра</param>
        /// <param name="isRequired">Возращаемый флаг, указывающий, что применение этого параметра обязательно</param>
        /// <param name="defstr">Значение по умолчанию для параметра</param>
        /// <returns>Значение параметра</returns>
        public string GetParameterValue(NameValueCollection requestQuery, string name, out bool isRequired,
            string defstr)
        {
            var value = requestQuery[name];
            isRequired = !string.IsNullOrEmpty(value);
            if (isRequired)
                return value;

            value = GetDbParameterValue(name);

            if (null == value)
            {
                value = requestQuery["_" + name];

                if (null == value)
                    return defstr;
            }

            return value;
        }

        /// <summary>
        ///     Получение последнего значения параметра из БД сохраненных параметров пользователей
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <returns>Значение параметра</returns>
        public string GetDbParameterValue(string name)
        {
            var appParam = Params.Find(p => p.Name == name);
            if (null == appParam)
                return null;
            return appParam.Value;
        }

        /// <summary>
        ///     Установка значения параметра (без сохранения в БД)
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="value">Значение параметра</param>
        public void SetDbParameterValue(string name, string value)
        {
            SetDbParameterValue(name, value, false);
        }


        /// <summary>
        ///     Установка значения параметра в БД
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="value">Значение параметра</param>
        /// <param name="withSave">Признак необходимости сохранения в БД</param>
        public void SetDbParameterValue(string name, string value, bool withSave)
        {
            var appParam = Params.Find(p => p.Name == name);

            if (null == appParam)
                return;

            appParam.Value = value;

            if (withSave)
                SaveParams();
        }
    }
}
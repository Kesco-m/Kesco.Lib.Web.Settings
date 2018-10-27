using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using Kesco.Lib.BaseExtention.Enums;
using Kesco.Lib.BaseExtention.Enums.Docs;
using Kesco.Lib.DALC;

namespace Kesco.Lib.Web.Settings.Parameters
{
    /// <summary>
    /// 
    /// </summary>
    public class AppParamsManager
    {
        /// <summary>
        /// Словарь параметров со значениями
        /// </summary>
        private List<AppParameter> _params;
        
        /// <summary>
        /// Аксессор к словарю параметров
        /// </summary>
        public List<AppParameter> Params
        {
            get { return _params; }
            set { _params = value; }
        }

        /// <summary>
        /// Клиент ID
        /// </summary>
        private int _clid;
        /// <summary>
        /// 
        /// </summary>
        public int CLID
        {
            get { return _clid; }
            set { _clid = value; }
        }

        /// <summary>
        /// Конструктор
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
        /// Загрузка параметров
        /// </summary>
        private void LoadParams(StringCollection paramNames)
        {
            if (paramNames.Count < 1) return;

            string parametersStr = ConvertExtention.Convert.Collection2Str(paramNames).Replace(",", "','");

            if (string.IsNullOrWhiteSpace(parametersStr)) return;

            Dictionary<string, object> sqlParams = new Dictionary<string, object> { { "@clid", _clid } };
            DataTable dt = DBManager.GetData(string.Format(SQLQueries.q_НастройкиОбщие_Получить, parametersStr), Config.DS_user, CommandType.Text, sqlParams); 

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
                object dbObj = r["Параметр"];
                string name = dbObj.ToString();

                dbObj = r["Значение"];
                string value = dbObj == DBNull.Value ? string.Empty : dbObj.ToString();

                dbObj = r["ТипПараметра"];
                AppParamType paramType = dbObj == DBNull.Value ? AppParamType.NotSaved : (AppParamType)int.Parse(dbObj.ToString());

                //dbObj = r["КодНастройкиКлиента"];
                //int clid = dbObj == DBNull.Value ? 0 : (int)dbObj;

                //В первую очередь добавляем параметры с требуемым _clid
                //if (clid == _clid)
                //    _params.Add(new AppParameter(name, value, paramType));
                //else
                //{
                    if (!_params.Exists((p) => p.Name == name))
                        _params.Add(new AppParameter(name, value, paramType));
                //}
            }
        }

        /// <summary>
        /// Сохранение параметров
        /// </summary>
        public void SaveParams()
        {
            foreach (var param in _params)
            {
                if (param.SaveType == AppParamType.AlwaysSaved || (param.SaveType == AppParamType.SavedWithClid && _clid >= 0))
                {
                    var sqlParams = new Dictionary<string, object>(3) { { "@CLID", _clid }, { "@Key", param.Name }, { "@Value", param.Value } };
                    DBManager.ExecuteNonQuery(SQLQueries.q_НастройкиОбщие_Записать, CommandType.Text, Config.DS_user, sqlParams);
                }
            }
        }
    }
}

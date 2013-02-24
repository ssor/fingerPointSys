using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace nsConfigDB
{
    public class ConfigItem
    {
        public string name = string.Empty;
        public List<string> columnList = new List<string>();
        public ConfigItem(string _name)
        {
            this.name = _name;
        }
        public void AddColumn(string _item)
        {
            if (!this.columnList.Contains(_item))
            {
                this.columnList.Add(_item);
            }
        }
    }

    /// <summary>
    /// 该类转为保存一些常用的设置
    /// 这个类要做到以下几点：
    /// 1 无需配置即可使用
    /// 2 根据配置名保存和读取配置
    /// </summary>
    public class ConfigDB
    {

        static bool bInitialled = false;
        static string configFile = "config.xml";
        static DataSet ds = null;
        static List<ConfigItem> itemList = new List<ConfigItem>();
        public static void save(string table_name)
        {
            if (ds.Tables.IndexOf(table_name) != -1)
            {
                ds.WriteXml(configFile);
            }
        }
        public static DataTable getTable(string tbName)
        {
            if (initialDB())
            {
                return ds.Tables[tbName];
            }
            return null;
        }
        public static void addConfigItem(ConfigItem _item)
        {
            if (!itemList.Contains(_item))
            {
                itemList.Add(_item);
            }
        }
        static bool initialDB()
        {
            if (bInitialled == true)
            {
                return true;
            }
            else
            {

                try
                {
                    ds = new DataSet("nsConfig");
                    ds.Namespace = "";
                    if (!File.Exists(configFile))
                    {

                        ds.WriteXml(configFile);
                    }
                    else
                    {
                        ds.ReadXml(configFile);

                    }
                    if (ds.Tables.IndexOf("config") == -1)
                    {
                        DataTable dt = new DataTable("config");
                        dt.Columns.Add("key", typeof(string));
                        dt.Columns.Add("value", typeof(object));
                        ds.Tables.Add(dt);
                    }
                    configDB();
                    bInitialled = true;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        static void configDB()
        {

            foreach (ConfigItem _configItem in itemList)
            {

                if (ds.Tables.IndexOf(_configItem.name) == -1)
                {
                    DataTable dt = new DataTable(_configItem.name);
                    dt.Columns.Add("key", typeof(string));
                    foreach (string s in _configItem.columnList)
                    {
                        dt.Columns.Add(s, typeof(string));
                    }
                    ds.Tables.Add(dt);
                }
            }
        }
        public static bool saveConfig(string _key, object _value)
        {
            bool bR = true;
            if (initialDB())
            {
                DataTable dt = ds.Tables["config"];
                DataRow[] rows = dt.Select("key = '" + _key + "'");
                if (rows.Length > 0)
                {
                    rows[0]["value"] = _value;
                }
                else
                {
                    dt.Rows.Add(new object[] { _key, _value });
                }
                ds.WriteXml(configFile);
            }
            return bR;
        }
        /// <summary>
        /// 根据表名、键值保存数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="_key">键值</param>
        /// <param name="values">要保存的数据，不包含键值</param>
        /// <returns></returns>
        public static bool saveConfig(string tableName, string _key, string[] values)
        {
            bool bR = true;
            if (initialDB())
            {
                DataTable dt = ds.Tables[tableName];
                DataRow[] rows = dt.Select("key = '" + _key + "'");
                if (rows.Length > 0)
                {
                    for (int i = 0; i < dt.Columns.Count - 1; i++)
                    {
                        rows[0][i + 1] = values[i];
                    }
                }
                else
                {
                    object[] array = new object[dt.Columns.Count];
                    array[0] = _key;
                    for (int i = 0; i < dt.Columns.Count - 1; i++)
                    {
                        array[i + 1] = values[i];
                    }
                    dt.Rows.Add(array);
                }
                ds.WriteXml(configFile);
            }
            return bR;
        }
        public static bool deleConfig(string tableName, string _key)
        {
            bool bR = true;
            if (initialDB())
            {
                DataTable dt = ds.Tables[tableName];
                DataRow[] rows = dt.Select("key = '" + _key + "'");
                if (rows.Length > 0)
                {
                    dt.Rows.Remove(rows[0]);
                    ds.WriteXml(configFile);
                }

            }
            return bR;
        }
        /// <summary>
        /// 根据表名和键值提取数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="_key">键值</param>
        /// <returns></returns>
        public static string[] getConfig(string tableName, string _key)
        {
            string[] items;
            //object oR = null;
            if (initialDB())
            {
                DataTable dt = ds.Tables[tableName];
                DataRow[] rows = dt.Select("key = '" + _key + "'");
                if (rows.Length > 0)
                {
                    DataRow dr = rows[0];
                    object[] array = dr.ItemArray;
                    items = Array.ConvertAll(array, new Converter<object, string>(objectToString));
                    return items;
                    //oR = rows[0]["value"];
                }
            }
            return null;
        }
        public static object getConfig(string _key)
        {
            object oR = null;
            if (initialDB())
            {
                DataTable dt = ds.Tables["config"];
                DataRow[] rows = dt.Select("key = '" + _key + "'");
                if (rows.Length > 0)
                {
                    oR = rows[0]["value"];
                }
            }
            return oR;
        }
        public static List<object> getKeys()
        {
            List<object> keys = new List<object>();
            if (initialDB())
            {
                DataTable dt = ds.Tables["config"];
                DataRow[] rows = dt.Select();
                if (rows.Length > 0)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        keys.Add(rows[i]["key"]);
                    }
                }
            }
            return keys;
        }
        public static bool isConfigExists(string _key)
        {
            return (getConfig(_key) == null) ? false : true;
        }
        static string objectToString(object o)
        {
            return (string)o;
        }

    }
}

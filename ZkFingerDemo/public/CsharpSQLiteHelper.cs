using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Collections;
using Community.CsharpSqlite.SQLiteClient;

namespace CsharpSQLite
{
    /// <summary>
    /// SQLiteHelper is a utility class similar to "SQLHelper" in MS
    /// Data Access Application Block and follows similar pattern.
    /// </summary>
    public class CsharpSQLiteHelper
    {
        public static string connectString = "Version=3,uri=file:personCheck.db3";
        //string cs = string.Format("Version=3,uri=file:{0}", dbFilename);
        /// <summary>
        /// Creates a new <see cref="SQLiteHelper"/> instance. The ctor is marked private since all members are static.
        /// </summary>
        private CsharpSQLiteHelper()
        {
        }
        public static int ExecuteNonQuery(string commandText, object[] paramList)
        {
            SqliteConnection cn = new SqliteConnection(connectString);
            IDbCommand cmd = cn.CreateCommand();
            cmd.CommandText = commandText;
            if (null!=paramList)
            {
                cmd.CommandText = string.Format(commandText, paramList);
            }

            if (cn.State == ConnectionState.Closed)
                cn.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

            return result;
        }

        /// <summary>
        /// Shortcut to ExecuteNonQuery with SqlStatement and object[] param values
        /// </summary>
        /// <param name="connectionString">SQLite Connection String</param>
        /// <param name="commandText">Sql Statement with embedded "@param" style parameters</param>
        /// <param name="paramList">object[] array of parameter values</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, object[] paramList)
        {
            SqliteConnection cn = new SqliteConnection(connectionString);
            IDbCommand cmd = cn.CreateCommand();
            cmd.CommandText = commandText;
            if (paramList != null)
            {
                cmd.CommandText = string.Format(commandText, paramList);
            }

            if (cn.State == ConnectionState.Closed)
                cn.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();

            return result;
        }

        ///<overloads></overloads> 
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="cmd">CMD.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(IDbCommand cmd)
        {
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Dispose();
            return result;
        }
        public static DataTable ExecuteTable(string commandText, object[] paramList)
        {
            SqliteConnection cn = new SqliteConnection(connectString);
            string sqlQuery = commandText;
            if (paramList != null)
            {
                sqlQuery = string.Format(commandText, paramList);
            }
            SqliteCommand command = new SqliteCommand(sqlQuery, cn);
            DataTable dataTable = new DataTable();
            SqliteDataAdapter dataAdapter = new SqliteDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataTable);

            return dataTable;
        }
        /// <summary>
        /// Shortcut to ExecuteScalar with Sql Statement embedded params and object[] param values
        /// </summary>
        /// <param name="connectionString">SQLite Connection String</param>
        /// <param name="commandText">SQL statment with embedded "@param" style parameters</param>
        /// <param name="paramList">object[] array of param values</param>
        /// <returns></returns>
        //public static object ExecuteScalar(string connectionString, string commandText, object[] paramList)
        //{
        //    SQLiteConnection cn = new SQLiteConnection(connectionString);
        //    SQLiteCommand cmd = cn.CreateCommand();
        //    cmd.CommandText = commandText;
        //    SQLiteParameterCollectionSub parms = DeriveParameters(commandText, paramList);
        //    if (null != parms)
        //    {
        //        foreach (SQLiteParameter p in parms)
        //            cmd.Parameters.Add(p);
        //    }
        //    if (cn.State == ConnectionState.Closed)
        //        cn.Open();
        //    object result = cmd.ExecuteScalar();
        //    cmd.Dispose();
        //    cn.Close();

        //    return result;
        //}

    }
}
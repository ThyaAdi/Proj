using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Util;

namespace BankApp.DB
{
    /// <summary>
    /// Utility class to create database connection
    /// </summary>
    class DbConnection
    {
        private static DbConnection instance;

        /// <summary>
        /// Private constructor
        /// </summary>
        private DbConnection()
        {

        }

        /// <summary>
        /// Creates an instance
        /// </summary>
        /// <returns></returns>
        public static DbConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DbConnection();
            }
            return instance;
        }

        /// <summary>
        /// Creates a connection to the database
        /// </summary>
        /// <returns></returns>
        public SqlConnection getConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(AppSettings.ConnectionStr);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

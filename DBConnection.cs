using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace BookAPI
{
    public class DBConnection
    {

        public static IConfigurationRoot GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();
            return builder;
        }
        public static string GetConnectionString()
        {
            SqlConnection conSql = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("Databasecon").Value);
            string strCon = conSql.ConnectionString;
            return strCon;

        }
    }
}

using System;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()                                 //these 4 lines (14,15,16) will find our app settings file 

                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");    //this line will identify where "defaultconnection" is called in "appsettings" and grab the connection string - then store it in "Connection string"
            IDbConnection conn = new MySqlConnection(connString);
        }
    }
}



﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace studentAdmissionDAL
{
     class Helper
    {
        public static string GetConnectionString()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"] == null)
            {
                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return MyConfig.GetConnectionString("MyDbConnectionString");
            }
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
            return connString;
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.AppSettings["MyDbConnectionString"];
        }
    }
}


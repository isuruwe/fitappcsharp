﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace AsyncWeb_Recv
{
    /// <summary>
    /// Summary description for selectym
    /// </summary>
    public class delete : IHttpHandler
    {

        SqlConnection oSqlConnection;
        SqlCommand oSqlCommand;
        SqlDataAdapter oSqlDataAdapter;
        public string sqlQuery;
        public void ProcessRequest(HttpContext context)
        {
            string devid = context.Request["devid"];
            string dt = context.Request["dt"];
            // string km = context.Request["km"];
            // string cal = context.Request["cal"];
            DataSet odsvoltxndata = new DataSet();

            oSqlConnection = new SqlConnection("Data Source =AFHQ-VTS; Initial Catalog = fitapp; User ID = sa; Password = 123@com");
            oSqlCommand = new SqlCommand();
            sqlQuery = "delete from fit where dtval='" + dt + "' and devid='" + devid + "'";

            oSqlCommand.Connection = oSqlConnection;
            oSqlCommand.CommandText = sqlQuery;
            oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
            oSqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
            oSqlDataAdapter.Fill(odsvoltxndata);
            oSqlConnection.Close();

            string json = JsonConvert.SerializeObject(odsvoltxndata);
            context.Response.ContentType = "text/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
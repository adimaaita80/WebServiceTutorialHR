using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebServiceTutorialHR
{
    /// <summary>
    /// Summary description for WebServiceHR
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceHR : System.Web.Services.WebService
    {
        DataTable tblDepartments = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "We are testing our first web service.";
        }

        [WebMethod]
        public string GetDepartments()
        {
            tblDepartments.Columns.Add("DepartmentId");
            tblDepartments.Columns.Add("DepartmentName");

            tblDepartments.Rows.Add(1, "HR");
            tblDepartments.Rows.Add(2, "Finance");
            tblDepartments.Rows.Add(3, "Projects");

            return JsonConvert.SerializeObject(tblDepartments);
        }

        [WebMethod]
        public string GetDepartmentsFromDB()
        {
            string connectionString = @"server = DESKTOP-BKKL4I9\SQLEXPRESS ; database = HRDB ; integrated security = SSPI";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("Select * from Departments", connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable tblDatabaseDepartments = new DataTable();

            dataAdapter.Fill(tblDatabaseDepartments);

            return JsonConvert.SerializeObject(tblDatabaseDepartments);
        }
    }
}

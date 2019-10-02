using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APpInsightsTraining.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            try
            {
                Random random = new Random();
                int num = random.Next();
                string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection cnn;
                cnn = new SqlConnection(connectionString);
                string sql = "INSERT INTO People (Id, Name) VALUES ('" + num.ToString() + "', 'User" + num.ToString() + "')";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }catch(Exception e)
            {
                ViewBag.Message = e.StackTrace;
            }

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            object m = null;
            string s = m.ToString();

            throw new HttpException(500, "");

        }
    }
}
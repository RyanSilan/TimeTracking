using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CET_TimeLogging.SQL
{
    class Connection
    {
         public Connection()
        {

            try
            {
                Console.WriteLine("Attempting to insert data");

                string query = "INSERT INTO dbo.calls(Time, Date) VALUES(@TimeValue, @DateValue)"; 

                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Database=CET;Trusted_Connection=True;"))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    string hr = "12"; 
                    string min = "10"; 
                    string time = hr + ":" + min;

                    // set the parameter value
                    cmd.Parameters.Add("@TimeValue", SqlDbType.Time).Value = TimeSpan.Parse(time);
                    cmd.Parameters.Add("@DateValue", SqlDbType.Date).Value = DateTime.Parse("12/10/2018"); 

                    // open connection, execute your INSERT, close connection
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occre while creating table:" + e.Message + "\t" + e.GetType());
            }
            

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDataLayer
{
    public class EmpDepDAL
    {
       
        public ArrayList getData(string desig)
        {
           
            ArrayList list = new ArrayList();
            SqlConnection connection = new SqlConnection("data source=.;database=Week2Review;integrated security = true");
            try
            {
                string query = "SELECT * FROM udfGetEmployees(@val)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@val", desig);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                 
                    string designation = Convert.ToString(reader[0]);
                    string noOfEmployes= Convert.ToString(reader[1]);
                    string noOfLocation = Convert.ToString(reader[2]);
                    list.Add(designation + "  No Of Employees =>" + noOfEmployes + " No Of Locations => " + noOfLocation);

                }
            }
            catch (SqlException ex)
            {
                throw ex;
                // Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw e;
                // Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}

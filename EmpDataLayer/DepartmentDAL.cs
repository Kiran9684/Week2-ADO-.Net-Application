using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDataLayer
{
    public class DepartmentDAL
    {
        public bool createTable(string name)
        {
            bool flag = true;
            SqlConnection connection = new SqlConnection("data source=.; database = Week2Review;integrated security = true");
            try
            {
                string query = "CREATE TABLE " + name + " (departmentId varchar(20) Primary key, departmentName varchar(20) Not Null ,locationName varchar(20))";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int i = command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                flag = false;
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public bool insertDepData(Department department , string name1)
        {
            bool flag = true;
            SqlConnection connection = new SqlConnection("data source=.; database= Week2Review;integrated security = true");
            try
            {
                string query = "INSERT INTO "+name1+" VALUES(@deptid,@deptName,@locationName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@deptid", department.DepartmentId);
                command.Parameters.AddWithValue("@deptName", department.DepartmentName);
                command.Parameters.AddWithValue("@locationName", department.LocationName);
                connection.Open();
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (SqlException ex)
            {
                flag = false;
                throw ex;
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public List<Department> displayDepartments(string name1)
        {
            List<Department> departmentList = new List<Department>();
            SqlConnection connection = new SqlConnection("data source=.;database=Week2Review;integrated security = true");
            try
            {
                string query = "SELECT * FROM " + name1;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Department department = new Department();
                    department.DepartmentId = Convert.ToString(reader["departmentId"]); // you could also give reader[0]
                    department.DepartmentName = Convert.ToString(reader["departmentName"]); // you could also give reader[1]
                    department.LocationName = Convert.ToString(reader["locationName"]); // you could also give reader[2]

                    departmentList.Add(department);
                    //Console.WriteLine(reader["EmployeeId"] + " " + reader["Name"] + " " + reader["Designation"] + " " + reader["Address"] + " " + reader["DateOfJoining"] + " " + reader["DepartmentId"]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return departmentList;
        }

    }
}

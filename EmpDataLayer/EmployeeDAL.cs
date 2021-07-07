using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpDataLayer
{
    public class EmployeeDAL
    {
        public bool createEmpTable(string name2 , string name1)
        {

            bool flag = true;
            SqlConnection connection = new SqlConnection("data source=.; database = Week2Review;integrated security = true");
            try
            {
                string query = "CREATE TABLE " + name2 + " (employeId int Primary key, name varchar(20) Not Null ,designation varchar(20) ," +
                    "dateOfJoinig date Not Null,departmentId varchar(20) Not Null FOREIGN KEY (departmentId) REFERENCES " + name1+ "(departmentId))";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int i = command.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                flag = false;
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
            return flag;
        }

     

        public bool insertEmp(Employee employee , string name2)
        {
            bool flag = true;
            SqlConnection connection = new SqlConnection("data source=.; database= Week2Review;integrated security = true");
            try
            {
                string query = "INSERT INTO " + name2 + " VALUES(@EmpId,@name,@designation,@doj,@departmentId)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmpId", employee.EmployeId);
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@designation", employee.Designation);
               
                command.Parameters.AddWithValue("@doj", employee.DateOfJoinig);
                command.Parameters.AddWithValue("@departmentId", employee.DepartmentId);
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

        public List<Employee> displayAllEmployees(string name2)
        {
            List<Employee> employeeList = new List<Employee>();
            SqlConnection connection = new SqlConnection("data source=.;database=Week2Review;integrated security = true");
            try
            {
                string query = "SELECT * FROM "+name2;
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeId = Convert.ToInt32(reader["employeId"]);
                    employee.Name = Convert.ToString(reader["name"]);
                    employee.Designation = Convert.ToString(reader["designation"]);
                   
                    employee.DateOfJoinig = (DateTime)(reader["dateOfJoinig"]);
                    employee.DepartmentId = Convert.ToString(reader["departmentId"]);
                    employeeList.Add(employee);
                    //Console.WriteLine(reader["EmployeeId"] + " " + reader["Name"] + " " + reader["Designation"] + " " + reader["Address"] + " " + reader["DateOfJoining"] + " " + reader["DepartmentId"]);
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
            return employeeList;
        }

        public bool updateDesig(string name2, string newDesignation)
        {

            bool flag = true;
            SqlConnection connection = new SqlConnection("data source=.; database = Week2Review;integrated security = true");
            try
            {
                string query = "UPDATE " + name2 + " SET designation = @val";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@val", newDesignation);
                connection.Open();
                int i = command.ExecuteNonQuery();
                if(i>0)
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
              //  Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw e;
               //Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return flag;
        }

        public bool deleteEmp(string name2, int id)
        {
            bool flag = true;
            SqlConnection connection = new SqlConnection("data source=.; database = Week2Review;integrated security = true");
            try
            {
                

                SqlCommand command = new SqlCommand("uspDeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id); //id is the parameter for stored procedure
              
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
            catch(SqlException ex)
            {
                throw ex;
            }
            catch(Exception e)
            {
                throw e;
            }
            return flag;
        }

    }
}

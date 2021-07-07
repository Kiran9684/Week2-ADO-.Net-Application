using EmpBusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EmpPresentationLayer
{
    public class Program
    {
        static string name1 = "", name2 = "";
        static EmployeeBL employeeBusinessLayer = new EmployeeBL();
        static DepartmentBL departmentBusinessLayer = new DepartmentBL();
        static EmpDepBL empDepBusinessLayer = new EmpDepBL();
        public static void Main(string[] args)
        {
            try
            {
                //create objects of business layer
                bool flag = true;
                bool checkflag = false;
                do
                {
                    try
                    {


                        int option = displayMenu();
                       
                        switch (option)
                        {
                            case 1:
                                {
                                    checkflag = createTableMenu();
                                    break;
                                }
                            case 2:
                                {
                                    if (checkflag == true)
                                    {
                                        Console.WriteLine("Enter 1 To Add Details To Deparment Table");
                                        Console.WriteLine("Enter 2 To Add Details To Employee Table");
                                        int val = Convert.ToInt32(Console.ReadLine());
                                        if (val == 1)
                                        {
                                            //To get Details of department
                                            Department department = getDeptDetails();
                                            //To insert data into table
                                            if (departmentBusinessLayer.insertDepData(department, name1))
                                            {
                                                Console.WriteLine("Data Inserted Successfully");
                                            }
                                        }
                                        else if (val == 2)
                                        {
                                            //To get details of Employee
                                            Employee employee = getEmpDetails();
                                            //To insert Employee Details into Database
                                            if (employeeBusinessLayer.insertEmpData(employee, name2))
                                            {
                                                Console.WriteLine("Data Inserted Successfully");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("You Have Entered Wrong Input");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Create Table First . Option 1");
                                    }


                                    break;
                                }
                            case 3:
                                {
                                    if (checkflag == true)
                                    {
                                        Console.WriteLine("Enter 1 To Get Employee Details");
                                        Console.WriteLine("Enter 2 To Get Department Details");
                                        int val2 = Convert.ToInt32(Console.ReadLine());
                                        if (val2 == 1)
                                        {
                                            List<Employee> employeeList = new List<Employee>();
                                            //method(in business layer) call to display all employees
                                            employeeList = employeeBusinessLayer.displayAllEmployees(name2);
                                            //method call to display employee List
                                            displayEmployeeList(employeeList);

                                        }
                                        else if (val2 == 2)
                                        {
                                            List<Department> departmentList = new List<Department>();

                                            departmentList = departmentBusinessLayer.displayAllDepartments(name1);

                                            displayDepartmentList(departmentList);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Create Table First  . Option 1");
                                    }

                                    break;
                                }
                            case 4:
                                {
                                    if (checkflag == true)
                                    {
                                        Console.WriteLine("Enter New Designation name ");
                                        string newDesignation = Console.ReadLine();
                                        if (employeeBusinessLayer.updateDesig(name2, newDesignation))
                                        {
                                            Console.WriteLine("Data Updated ");
                                        }

                                        else
                                        {
                                            Console.WriteLine("Create Table First  . Option 1");
                                        }
                                    }
                                    break;

                                }

                            case 5:
                                {
                                    if(checkflag == true)
                                    {
                                        Console.WriteLine("Enter Employee Id To Delete");
                                        int id = Convert.ToInt32(Console.ReadLine());
                                        if (employeeBusinessLayer.deleteEmp(name2, id))
                                        {
                                            Console.WriteLine("Employee Deleted ");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Create Table First  . Option 1");
                                    }
                                    
                                    break;
                                }
                            case 6:
                                {
                                    if(checkflag == true)
                                    {
                                        ArrayList datalist = new ArrayList();
                                        Console.WriteLine("Enter Designation");
                                        string desig = Console.ReadLine();

                                        datalist = empDepBusinessLayer.getData(desig);
                                        foreach (var data in datalist)
                                        {
                                            Console.WriteLine(data);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Create Table First  . Option 1");
                                    }
                                  
                                    break;
                                }
                            case 7:
                                {
                                    Console.WriteLine("System Is Exiting");
                                    flag = false;
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("You Have Entered Wrong Input");
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (flag);




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool createTableMenu()
        {
            Console.WriteLine("Choose Y If you want To Create Table");
            Console.WriteLine("Choose N If You Already Created a Table");
            Console.WriteLine("Want To create Table Y/N");
            char ch = Convert.ToChar(Console.ReadLine());

            if (ch == 'Y' || ch == 'y')
            {
                Console.WriteLine("Enter 1st Table Name To Create ");
                name1 = Console.ReadLine();  // name1 = Departments
                if (departmentBusinessLayer.createTable(name1))
                {
                    Console.WriteLine(name1 + "Table Created");
                    Console.WriteLine("Enter 2nd Table Name");
                    name2 = Console.ReadLine(); //name2 = Employees
                    if (employeeBusinessLayer.CreateEmpTable(name2, name1))
                    {
                        Console.WriteLine(name2 + "Table created ");
                    }

                }
            }
            else
            {
                Console.WriteLine("Enter Already Created Table Names");
                Console.WriteLine("Enter First Table Name");
                name1 = Console.ReadLine();
                Console.WriteLine("Enter Second Table Name");
                name2 = Console.ReadLine();

            }
            return true;
        }

        private static int displayMenu()
        {
            Console.WriteLine("********Welcome To Employee Management System*********");
            Console.WriteLine("Enter 1 To create Table");

            Console.WriteLine("Enter 2 To Insert Data ");
            Console.WriteLine("Enter 3 To Display Data ");
            Console.WriteLine("Enter 4 To Update Employee Designation");
            Console.WriteLine("Enter 5 To Delete Employee");
            Console.WriteLine("Enter 6 To Get No Of Employees And No Of Locations Based On Designation");
            Console.WriteLine("Enter 7 To Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }


        private static Department getDeptDetails()
        {
            Department dep = new Department();
            Console.WriteLine("Enter Department ID");
            dep.DepartmentId = Console.ReadLine();
            Console.WriteLine("Enter DepartName");
            dep.DepartmentName = Console.ReadLine();
            Console.WriteLine("Enter Location Name");
            dep.LocationName = Console.ReadLine();
            return dep;

        }
        private static Employee getEmpDetails()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter Employee Id");
            emp.EmployeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            emp.Name = Console.ReadLine();
            Console.WriteLine("Enter Designation");
            emp.Designation = Console.ReadLine();

            Console.WriteLine("Emter Employee Date Of Joining in YYYY-MM-DD Format");
            emp.DateOfJoinig = Convert.ToDateTime(Console.ReadLine()); //Important

            Console.WriteLine("Enter Department ID");
            emp.DepartmentId = Console.ReadLine();

            return emp;

        }

        private static void displayEmployeeList(List<Employee> employeeList)
        {
            foreach (Employee employe in employeeList)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(employe.EmployeId);
                Console.WriteLine(employe.Name);
                Console.WriteLine(employe.Designation);
                Console.WriteLine(employe.DateOfJoinig.ToShortDateString());

                Console.WriteLine(employe.DepartmentId);
                Console.WriteLine("-------------------------");
            }
        }

        private static void displayDepartmentList(List<Department> departmentList)
        {
            foreach (Department item in departmentList)
            {
                Console.WriteLine("******************");
                Console.WriteLine(item.DepartmentId);
                Console.WriteLine(item.DepartmentName);
                Console.WriteLine(item.LocationName);
                Console.WriteLine("******************");
            }
        }

    }
}

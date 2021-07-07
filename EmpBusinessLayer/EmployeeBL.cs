using EmpDataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBusinessLayer
{
    public class EmployeeBL
    {
        EmployeeDAL empDataLayer = new EmployeeDAL();

        public bool CreateEmpTable(string name2 , string name1)
        {
            bool val = empDataLayer.createEmpTable(name2 , name1);
            return val;
        }

        public bool insertEmpData(Employee employee , string name2)
        {
            return (empDataLayer.insertEmp(employee, name2));
        }

        public List<Employee> displayAllEmployees(string name2)
        {
            return (empDataLayer.displayAllEmployees(name2));
        }

        public bool updateDesig(string name2, string newDesignation)
        {
            return (empDataLayer.updateDesig(name2, newDesignation));
        }

        public bool deleteEmp(string name2, int id)
        {
            return (empDataLayer.deleteEmp(name2, id));
        }
    }
}

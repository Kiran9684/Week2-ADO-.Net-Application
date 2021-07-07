using EmpDataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBusinessLayer
{
    public class DepartmentBL
    {
        DepartmentDAL departmentdataLayer = new DepartmentDAL();
        public bool createTable(string name1)
        {
            bool val = departmentdataLayer.createTable(name1);
            return val;
        }

        public bool insertDepData(Department deparment,string name1)
        {
            return (departmentdataLayer.insertDepData(deparment,name1));
        }

        public List<Department> displayAllDepartments(string name1)
        {
            return (departmentdataLayer.displayDepartments(name1));
        }

    }
}

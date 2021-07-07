using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        private int employeId;
        private string name;
        private string designation;

        private DateTime dateOfJoinig;
        private string departmentId;

        public int EmployeId { get => employeId; set => employeId = value; }
        public string Name { get => name; set => name = value; }
        public string Designation { get => designation; set => designation = value; }

        public DateTime DateOfJoinig { get => dateOfJoinig; set => dateOfJoinig = value; }
        public string DepartmentId { get => departmentId; set => departmentId = value; }
    }
}

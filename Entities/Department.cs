using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Department
    {
        private string departmentId;
        private string departmentName;
        private string locationName;

        public string DepartmentId { get => departmentId; set => departmentId = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
        public string LocationName { get => locationName; set => locationName = value; }
    }
}

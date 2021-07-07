using EmpDataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpBusinessLayer
{
    public class EmpDepBL
    {
        EmpDepDAL empDepDataLayer = new EmpDepDAL();

        public ArrayList getData(string desig)
        {
           return empDepDataLayer.getData(desig);
        }
     
    }
}

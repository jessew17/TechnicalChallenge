using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationArithmetic
{
    /// <summary>
    /// class for sales order details table including properties for relevant columns
    /// </summary>
    class SalesOrderDetails
    {
        public int OrderID { get; set; }
        public int Sequence { get; set; }
        public string Descrption { get; set; }
        public double Price { get; set; }
    }
}

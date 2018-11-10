using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationArithmetic
{
    /// <summary>
    /// class for sales order including relevant columns
    /// </summary>
    class SalesOrder
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public string UserName { get; set; }
    }
}

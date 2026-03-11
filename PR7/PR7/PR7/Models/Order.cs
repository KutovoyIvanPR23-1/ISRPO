using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7.Models
{
    public class Order
    {
        public int Id_Order { get; set; }
        public string Name { get; set; }
        public int Customer { get; set; }
        public int Type { get; set; }
        public int Publication { get; set; }
        public int Office { get; set; }
        public string DateOfAdmission { get; set; }
        public string DateOfCompletion { get; set; }
        public string Price { get; set; }  
        public string BookTitle { get; set; }
        public string CustomerName { get; set; }
        public string OfficeName { get; set; }

        public DateTime GetOrderDate()
        {
            if (DateTime.TryParse(DateOfAdmission, out DateTime date))
                return date;
            return DateTime.Now;
        }

        public decimal GetPriceDecimal()
        {
            if (decimal.TryParse(Price, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                return price;
            return 0;
        }
    }
}

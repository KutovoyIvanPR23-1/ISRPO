using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using BackpackApp.Models;

namespace BackpackApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{Name}: вес {Weight}, стоимость {Cost}";
        }
    }
}

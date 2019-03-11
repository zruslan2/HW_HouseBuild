using HouseBuild.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuild.Model
{
    class Roof : IPart
    {
        public string name { get; set; }
        public double price { get; set; }
        public int count { get; set; }
        public ITask task { get; set; }
        public int order { get; set; }
        public string getInfo()
        {
            string info = string.Format("Наименование : {0} ({1})\nЦена: {2}", name, count, price);
            return info;
        }
    }
}

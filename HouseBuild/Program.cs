using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseBuild.Model;

namespace HouseBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            HouseProject project = new HouseProject();
            project.startBuilding();
        }
    }
}

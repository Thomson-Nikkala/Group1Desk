using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1Desk
{
    enum SurfaceMaterial { pine, laminate, oak };

    class Desk
    {
        public double width { get; set; }
        public double length { get; set; }
        public int drawers { get; set; }
        public SurfaceMaterial surfaceType { get; set; }

        public double getSurfaceArea()
        {
            double area;
            area = width * length;
            return area;
        }
    }
}

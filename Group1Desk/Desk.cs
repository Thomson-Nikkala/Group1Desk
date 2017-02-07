using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1Desk
{
    public enum SurfaceMaterial { pine, laminate, oak, poplar, alder };

    public class Desk
    {
        public int width { get; set; }
        public int length { get; set; }
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

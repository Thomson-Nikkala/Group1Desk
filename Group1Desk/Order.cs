using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1Desk
{
    enum OrderSpeed { noRush = 1, threeDay, fiveDay, sevenDay }

    class Order
    {
        public Desk yourDesk { get; set; }
        public OrderSpeed speed { get; set; }
        public static int BasePrice = 20000;

        public int getSurfaceAreaPrice()
        {
            double surfaceArea=yourDesk.getSurfaceArea();
            if (surfaceArea <= 1000)
                return 0;
            else return (int)(surfaceArea - 1000) * 500;
        }
        
        public int getDrawersPrice()
        {
            return 5000 * yourDesk.drawers;
        }

        public int getSurfaceTypePrice()
        {
            switch (yourDesk.surfaceType)
            {
                case SurfaceMaterial.laminate:
                    return 10000;
                case SurfaceMaterial.oak:
                    return 20000;
                case SurfaceMaterial.pine:
                    return 5000;
                default:  // this should never be triggered
                    return 0;
            }
        }

        public int getSpeedPrice()
        {
            int i;
            int j;
            int[,] rushOrderArray;
            double surfaceArea = yourDesk.getSurfaceArea();

            //read rushOrderArray in here

            switch (speed)
            {
                case OrderSpeed.noRush:
                    return 0;
                case OrderSpeed.threeDay: i = 0; break;
                case OrderSpeed.fiveDay: i = 1; break;
                case OrderSpeed.sevenDay: i = 2; break;
                default:  // this should never occur
                    return 0;
            }

            if (surfaceArea < 1000)
                j = 0;
            else if (surfaceArea < 2000)
                j = 1;
            else j = 2;

            return rushOrderArray[i, j];
        }

        public int getTotalPrice()
        {
            int totalPrice;
            totalPrice = BasePrice + this.getSurfaceAreaPrice() + this.getDrawersPrice() + this.getSurfaceTypePrice() + this.getSpeedPrice();
            return totalPrice;
        }
    }
}

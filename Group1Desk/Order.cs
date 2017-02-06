using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1Desk
{

    public class Order
    {
        public Desk yourDesk { get; set; }
        public int shipTime { get; set; }
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
            SurfaceMaterial surface = yourDesk.surfaceType;
            switch (surface)
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
            int[,] rushOrderArray = new int[3,3];
            double surfaceArea = yourDesk.getSurfaceArea();

            //read rushOrderArray in here

            switch (shipTime)  // shipping time in days
            {
                case 14:
                    return 0;
                case 3: i = 0; break;
                case 5: i = 1; break;
                case 7: i = 2; break;
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

        // read in the text file to populate rushOrderArray    
        private static void ReadRushOrderPrices(ref int[,] rushOrderArray)
        {
            try
            {
                string[] rushPrices = File.ReadAllLines(@"rushOrderPrices.txt");
                int readLineCounter = 0;
                for (int i = 0; i < rushOrderArray.GetLength(0); i++)
                {
                    for (int j = 0; j < rushOrderArray.GetLength(1); j++)
                    {
                        rushOrderArray[i, j] = int.Parse(rushPrices[readLineCounter]) * 100; //adjusting for cents
                        readLineCounter++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

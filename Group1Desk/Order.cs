using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1Desk
{
    public enum OrderSpeed { noRush = 14, threeDay = 3, fiveDay = 5, sevenDay = 7 }

    public class Order
    {
        public Desk yourDesk { get; set; }
        public OrderSpeed speed { get; set; }
        public static int BasePrice = 200;

        public int getSurfaceAreaPrice()
        {
            int surfaceArea = yourDesk.getSurfaceArea();
            if (surfaceArea <= 1000)
                return 0;
            else return (int)(surfaceArea - 1000) * 5;
        }

        public int getDrawersPrice()
        {
            return 50 * yourDesk.drawers;
        }

        public int getSurfaceTypePrice()
        {
            switch (yourDesk.surfaceType)
            {
                case SurfaceMaterial.laminate:
                    return 100;
                case SurfaceMaterial.oak:
                    return 200;
                case SurfaceMaterial.pine:
                    return 50;
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

            //read rushOrderArray 
            try
            {
                string[] rushPrices = File.ReadAllLines(@"rushOrderPrices.txt");
                int readLineCounter = 0;
                for (int k = 0; k < rushOrderArray.GetLength(0); k++)
                {
                    for (int m = 0; m < rushOrderArray.GetLength(1); m++)
                    {
                        rushOrderArray[k, m] = int.Parse(rushPrices[readLineCounter]); 
                        readLineCounter++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

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

            /*return rushOrderArray[i, j];*/
            return 5;
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
                        rushOrderArray[i, j] = int.Parse(rushPrices[readLineCounter]); 
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

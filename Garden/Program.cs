using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenMower
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Mower> mowers = new List<Mower>();

            Console.Write("Garden Length: ");
            int gardenLength = int.Parse(Console.ReadLine());

            Console.Write("Garden Width: ");
            int gardenWidth = int.Parse(Console.ReadLine());

            Garden garden = new Garden { Length = gardenLength, Width = gardenWidth };

            Console.Write("No. of Mowers: ");
            int mowerCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < mowerCount; i++)
            {
                mowers.Add(new Mower(garden));
            }

            foreach (Mower robotMower in mowers)
            {
                Console.Write("X Y Heading: ");
                string mowerParams = Console.ReadLine();

                Console.Write("Instructions: ");
                string moveParams = Console.ReadLine();

                try {
                    char[] mowerParamArray = mowerParams.ToCharArray();

                    robotMower.Position.X = int.Parse(mowerParamArray[0].ToString());

                    robotMower.Position.Y = int.Parse(mowerParamArray[1].ToString());

                    robotMower.Heading = mowerParamArray[2];

                    robotMower.move(moveParams);
                }
                catch
                {
                    Console.Write("The move is illegal: ");
                }

            }

            foreach (Mower robotMower in mowers)
            {
                Console.WriteLine(robotMower.ToString());
            }

            Console.ReadLine();
        }
    }
}

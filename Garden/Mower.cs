using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenMower
{
    public class Mower
    {
        private IGarden _garden;

        public CoOrdinate Position { get; set; }

        public char Heading { get; set; }

        public Mower(IGarden garden):this(garden, new CoOrdinate {X=0, Y=0 }, 'N')
        {

        }

        public Mower(IGarden garden, CoOrdinate position, char heading) {

            _garden = garden;

            Position = position;

            Heading = heading;

        }
        public void move (string movement) {

            char[] movements = movement.ToCharArray();

            foreach(char moving in movements)
            {
                move(moving);
            }
        }
        public void move(char movement) {

            switch(movement)
            {
                case 'L':
                    switch (Heading)
                    {
                        case 'N':
                            Heading = 'W';
                            break;
                        case 'E':
                            Heading = 'N';
                            break;
                        case 'S':
                            Heading = 'E';
                            break;
                        case 'W':
                            Heading = 'S';
                            break;

                    }
                    break;
                case 'R':
                    switch (Heading)
                    {
                        case 'N':
                            Heading = 'E';
                            break;
                        case 'E':
                            Heading = 'S';
                            break;
                        case 'S':
                            Heading = 'W';
                            break;
                        case 'W':
                            Heading = 'N';
                            break;
                    }
                    break;

                case 'M':
                    if (Heading == 'N')
                    {
                        if (Position.Y < _garden.Length)
                        {
                            Position.Y++;
                        }
                        else
                        {
                            throw new Exception("You have reached the edge of the garden");
                        }
                    }
                    else if (Heading == 'S')
                    {
                        if (Position.Y > 0)
                        {
                            Position.Y--;
                        }
                        else
                        {
                            throw new Exception("You have reached the edge of the garden");
                        }
                    }
                    else if (Heading == 'E')
                    {
                        if (Position.X < _garden.Width)
                        {
                            Position.X++;
                        }
                        else
                        {
                            throw new Exception("You have reached the edge of the garden");
                        }
                    }
                    else if (Heading == 'W')
                    {
                        if (Position.X > 0)
                        {
                            Position.X--;
                        }
                        else
                        {
                            throw new Exception("You have reached the edge of the garden");
                        }
                    }

                        break;
                    
               }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", Position.X, Position.Y, Heading);
        }
    }
}

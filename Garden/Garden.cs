using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenMower
{
    public class Garden : IGarden
    {
        public int Length { get; set; }
        public int Width { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Positions
    {
        public int PositionsId {get; set;}
        public String PositionsName { get; set; }
        public IList<PlayersPositions> PlayersPositions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class PlayersPositions
    {
        public int PlayersPositionsId { get; set; }
        public int PlayersId { get; set; }
        public int PositionsId { get; set; }
        public Players Players { get; set; }
        public Positions Positions { get; set; }
    }
}

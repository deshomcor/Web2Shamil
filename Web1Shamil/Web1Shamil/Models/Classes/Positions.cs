using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Positions
    {
        public int PositionsId {get; set;}
        public String PositionsName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Position name required entry")]
        [StringLength(16)]
        public IList<PlayersPositions> PlayersPositions { get; set; }
    }
}

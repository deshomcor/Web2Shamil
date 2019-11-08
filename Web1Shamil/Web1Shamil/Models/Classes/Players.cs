using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Players
    {
        public int PlayersId { get; set; }
        public string PlayersName { get; set; }
        public string PlayersSurname { get; set; }
        public int? TeamsId { get; set; }
        public IList<PlayersPositions> PlayersPositions { get; set; }
        public Teams Teams { get; set; }
    }
}

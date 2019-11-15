using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Regions
    {
        public Regions()
        {
            this.RegionsName = "Asia";
        }
        public int RegionsId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Regions name required entry")]
        [StringLength(16)]
        public string RegionsName { get; set; }
        public List<Teams> Teams { get; set; }

    }

}

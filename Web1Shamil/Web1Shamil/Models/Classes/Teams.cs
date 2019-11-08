using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Teams
    {
        public int TeamsId { get; set; }
        public string TeamsName { get; set; }
        public string TeamsStadium { get; set; }
        public ICollection<Players> Players { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Uniforms Uniforms { get; set; }
        public int? RegionsId { get; set; }
        public int? StageId { get; set; }
        public Regions Regions { get; set; }
        public Stage Stages { get; set; }
    }
}

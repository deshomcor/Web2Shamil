using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Uniforms
    {
        [Key]
        public int UniformsId { get; set; }
        public string UniformsName { get; set; }
        public string UniformsColor { get; set; }
        public int? TeamsId { get; set; }
        public virtual Teams Teams { get; set; }
        

    }
}

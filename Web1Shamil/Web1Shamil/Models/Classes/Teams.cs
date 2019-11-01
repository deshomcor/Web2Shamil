using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public ICollection<Players> Players { get; set; }
        public virtual Coach Coach { get; set; }
    }
}

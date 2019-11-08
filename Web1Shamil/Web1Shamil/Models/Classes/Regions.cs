﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Regions
    {
        public int RegionsId { get; set; }
        public string RegionsName { get; set; }
        public ICollection<Teams> Teams { get; set; }
 
    }

}
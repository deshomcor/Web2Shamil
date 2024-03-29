﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    public class Stage
    {
        public Stage()
        {
            this.StageName = "Play-Off";
        }
        public int StageId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Stage name required entry")]
        [StringLength(16)]
        public string StageName { get; set; }
        public List<Teams> Teams { get; set; }
    }
   
}

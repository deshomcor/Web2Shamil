﻿using Microsoft.AspNetCore.Mvc;
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
        public Players()
        {
            this.PlayersName = "Shamil";
            this.PlayersSurname = "Aripov";
        }
        public int PlayersId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name required entry")]
        [StringLength(16)]
        [Remote("IsPlayerNameAvailable", "Players", HttpMethod = "POST", ErrorMessage = "Player already exists!")]
        public string PlayersName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname required entry")]
        [StringLength(16)]
        public string PlayersSurname { get; set; }
        public int? TeamsId { get; set; }
        public Teams Teams { get; set; }
        public List<PlayersPositions> PlayersPositions { get; set; }
        public List<Positions> Positions { get; set; }
    }
}

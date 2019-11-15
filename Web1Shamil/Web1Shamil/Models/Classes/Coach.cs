using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web1Shamil.Models.Classes
{
    public class Coach
    {
        public Coach()
        {
            this.CoachName= "Vasya";
            this.CoachSurname = "Vasilyev";
        }
        [ForeignKey("Teams")]
        public int CoachId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Coach name required entry")]
        [StringLength(16)]
        public string CoachName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Coach surname required entry")]
        [StringLength(16)]
        public string CoachSurname { get; set; }

        public virtual Teams Teams { get; set; }
    }
}
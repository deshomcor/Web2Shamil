using System.ComponentModel.DataAnnotations.Schema;

namespace Web1Shamil.Models.Classes
{
    public class Coach
    {
        [ForeignKey("Teams")]
        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public string CoachSurname { get; set; }
    }
}
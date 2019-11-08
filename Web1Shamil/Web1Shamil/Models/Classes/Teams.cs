using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web1Shamil.Models.Classes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class NoneStadium : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            var isValid = true;

            if (string.IsNullOrEmpty(inputValue))
            {
                return !isValid;
            }

            return isValid;
        }
    }
    public class Teams : IValidatableObject
    {
        private const int length = 16;
        public int TeamsId { get; set; }
        public string TeamsName { get; set; }
        [NoneStadium(ErrorMessage = "Write stadium's name.")]
        public string TeamsStadium { get; set; }
        public ICollection<Players> Players { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual Uniforms Uniforms { get; set; }
        public int? RegionsId { get; set; }
        public int? StageId { get; set; }
        public Regions Regions { get; set; }
        public Stage Stages { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TeamsName.Length > length)
            {
                yield return new ValidationResult(
                    $"TeamsName must be less than {length}.",
                    new[] { "TeamsName" });
            }
        }
    }
}

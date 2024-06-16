using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatavidCakeTracker.Models
{
    public class Member
    {
        //annotation as a key for the db table
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Fist name is required")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        [BirthDate(MinAge=18,MaxAge=80, ErrorMessage = "Age must be between 18 and 80")]
        public required DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public required string Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        public required string City { get; set; }

        public int Age {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                return age;
            }
        }


        //validtion for the age to be between the minimum of 18yo and a reasonable 80yo
        public class BirthDateAttribute : ValidationAttribute
        {
            public int MinAge;
            public int MaxAge;

            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value is DateOnly BirthDate)
                {
                    var age = DateTime.Today.Year - BirthDate.Year;
                    if (age >= MinAge && age <= MaxAge)
                        return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}

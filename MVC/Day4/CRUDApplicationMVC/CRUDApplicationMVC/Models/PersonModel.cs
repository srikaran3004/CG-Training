using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDApplicationMVC.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 to 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabets allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 to 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "State must be 2 to 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabets allowed")]
        public string State { get; set; }
    }
}
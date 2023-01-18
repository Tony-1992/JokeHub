using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JokeHub.Web.Models.Jokes
{
    public class EditJokeViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The joke setup is required")]
        [StringLength(100, ErrorMessage = "Max length is 100 characters")]
        [Display(Name = "Setup")]
        public string Setup { get; set; }

        [Required(ErrorMessage = "The joke punch line is required")]
        [StringLength(100, ErrorMessage = "Max length is 100 characters")]
        [Display(Name = "Punch line")]
        public string PunchLine { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }

        [Required]
        public string CategoryId { get; set; }
    }
}

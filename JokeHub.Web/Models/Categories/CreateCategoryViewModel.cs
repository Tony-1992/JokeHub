using System.ComponentModel.DataAnnotations;

namespace JokeHub.Web.Models.Categories
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get;set; }
    }
}

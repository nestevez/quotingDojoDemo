using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public class AuthorViewModel: BaseEntity
    {
        [Required]
        [MinLength(6)]
        public string name {get;set;}
    }
}
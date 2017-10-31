using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public class QuoteViewModel: BaseEntity
    {
        [Required]
        [MinLength(10)]
        public string quote {get;set;}

        [Required]
        public int authorId {get;set;}
        
        [Required]
        public int categoryId {get;set;}

        [Required]
        public string meta {get;set;}
    }
}
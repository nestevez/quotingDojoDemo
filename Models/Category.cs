using System.Collections.Generic;

namespace quotingDojo.Models
{
    public class Category : BaseEntity
    {
        public int id {get;set;}
        public string category {get;set;}
        public List<QuoteCat> quotecats {get;set;}

        public Category()
        {
            quotecats = new List<QuoteCat>();
        }
    }
}
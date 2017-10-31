using System.Collections.Generic;

namespace quotingDojo.Models
{
    public class Author : BaseEntity
    {
        public int authorId {get;set;}
        public string name {get;set;}
        public List<Quote> quotes {get;set;}

        public Author()
        {
            quotes = new List<Quote>();
        }
    }
}
namespace quotingDojo.Models
{
    public class QuoteCat : BaseEntity
    {
        public int quotecatId {get;set;}
        public int quoteId {get;set;}
        public Quote quote {get;set;}
        public int categoryid {get;set;}
        public Category category {get;set;}
    }
}
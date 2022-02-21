namespace BookAPI.Data.Entities
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public bool DisplayStatus { get; set; }
        public bool IsDeleted { get; set; }
        public int GenrId { get; set; }
        public Genr Genr { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

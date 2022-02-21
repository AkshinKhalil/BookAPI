using System;

namespace BookAPI.Apps.AdminApi.DTOs.BookDtos
{
    public class BookGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Profit { get; set; }
        public bool DisplayStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public GenrInBookGetDto Genr { get; set; }
        public AuthorInBookGetDto Author { get; set; }
    }
    public class GenrInBookGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCounts { get; set; }
    }
    public class AuthorInBookGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCounts { get; set; }
    }
}

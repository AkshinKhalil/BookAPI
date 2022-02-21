namespace BookAPI.Apps.AdminApi.DTOs.BookDtos
{
    public class BookListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public bool DisplayStatus { get; set; }
        public GenrInBookListItemDto Genr { get; set; }
        public AuthorInBookListItemDto Author { get; set; }
    }

    public class GenrInBookListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }  
    public class AuthorInBookListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

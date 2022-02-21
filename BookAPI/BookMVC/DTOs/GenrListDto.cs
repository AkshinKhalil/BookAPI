using System.Collections.Generic;

namespace BookMVC.DTOs
{
    public class GenrListDto
    {
        public List<GenrListItemDto> Items { get; set; }
        public int TotalCount { get; set; }
    }
}

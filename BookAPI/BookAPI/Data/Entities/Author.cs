using System.Collections.Generic;

namespace BookAPI.Data.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }        
        public bool IsDeleted { get; set; }
        public string Image { get; set; }
        public List<Book> Books { get; set; }
    }
}

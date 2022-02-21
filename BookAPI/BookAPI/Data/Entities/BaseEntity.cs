using System;

namespace BookAPI.Data.Entities
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

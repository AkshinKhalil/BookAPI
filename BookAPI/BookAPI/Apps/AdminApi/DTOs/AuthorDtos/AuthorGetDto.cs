using System;

namespace BookAPI.Apps.AdminApi.DTOs.AuthorDtos
{
    public class AuthorGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

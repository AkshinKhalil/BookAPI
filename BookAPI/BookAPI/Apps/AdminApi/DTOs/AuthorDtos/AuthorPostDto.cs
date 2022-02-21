using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookAPI.Apps.AdminApi.DTOs.AuthorDtos
{
    public class AuthorPostDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
    public class AuthorPostDtoValidator : AbstractValidator<AuthorPostDto>
    {
        public AuthorPostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Uzunluq maksimum 50 ola biler");
        }
    }
}

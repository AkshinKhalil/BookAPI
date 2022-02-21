using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookAPI.Apps.AdminApi.DTOs.GenrDtos
{
    public class GenrPostDto
    {
        public string Name { get; set; }
    }
    public class GenrPostDtoValidator : AbstractValidator<GenrPostDto>
    {
        public GenrPostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Uzunluq maksimum 50 ola biler");
        }
    }
}

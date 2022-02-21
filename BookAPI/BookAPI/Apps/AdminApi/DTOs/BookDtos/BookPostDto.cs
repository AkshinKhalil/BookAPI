using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookAPI.Apps.AdminApi.DTOs.BookDtos
{
    public class BookPostDto
    {
        public int GenrId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public bool DisplayStatus { get; set; }
    }
    public class BookPostDtoValidator : AbstractValidator<BookPostDto>
    {
        public BookPostDtoValidator()
        {
            RuleFor(x => x.GenrId).NotNull().GreaterThanOrEqualTo(1);
            RuleFor(x => x.AuthorId).NotNull().GreaterThanOrEqualTo(1);
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Uzunluq maksimum 50 ola biler")
                .NotEmpty().WithMessage("Name mecburidir");
           // RuleFor(x => x.Image).NotEmpty().WithMessage("Image mecburidir");
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(0).WithMessage("SalePrice 0-dan ashagi ola bilmez")
                .NotNull().WithMessage("SalePrice mecburidir");
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0).WithMessage("CostPrice 0-dan ashagi ola bilmez")
                .NotNull().WithMessage("CostPrice mecburidir");
            RuleFor(x => x.DisplayStatus).NotNull().WithMessage("DisplayStatus mecburidir");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.CostPrice > x.SalePrice)
                    context.AddFailure("CostPrice", "Costprice SalePrice-dan boyuk ola bilmez");
            });
        }
    }
}


using AutoMapper;
using BookAPI.Apps.AdminApi.DTOs;
using BookAPI.Apps.AdminApi.DTOs.BookDtos;
using BookAPI.Data.DAL;
using BookAPI.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookAPI.Apps.AdminApi.Controllers
{
    [ApiExplorerSettings(GroupName = "admin_v1")]
    [Route("admin/api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookDbContext bookDbContext, IMapper mapper)
        {
            _context = bookDbContext;
            _mapper = mapper;
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            Book book = _context.Books.Include(x => x.Genr).Include(x => x.Author).ThenInclude(x => x.Books).FirstOrDefault(x => x.id == id && !x.IsDeleted);
            if (book == null) return NotFound();

            BookGetDto bookDto = _mapper.Map<BookGetDto>(book);

            return Ok(bookDto);
        }
        //private BookGetDto MapToBookGetDto(Book book)
        //{
        //    BookGetDto BookDto = new BookGetDto
        //    {
        //        Id = book.id,
        //        CostPrice = book.CostPrice,
        //        SalePrice = book.SalePrice,
        //        Name = book.Name,
        //        DisplayStatus = book.DisplayStatus,
        //        CreatedAt = book.CreatedAt,
        //        ModifiedAt = book.ModifiedAt,
        //        Genr = new GenrInBookGetDto
        //        {
        //            Id = book.GenrId,
        //            Name = book.Genr.Name,
        //            BookCounts = book.Genr.Books.Count
        //        }
        //    };

        //    return BookDto;
        //}
        [Route("")]
        [HttpPost]
        public IActionResult Create(BookPostDto bookPostDto)
        {
            Book book = new Book
            {
                Name = bookPostDto.Name,
                CostPrice = bookPostDto.CostPrice,
                SalePrice = bookPostDto.SalePrice,
                DisplayStatus = bookPostDto.DisplayStatus,
                AuthorId= bookPostDto.AuthorId,
                GenrId= bookPostDto.GenrId,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return StatusCode(201, book);
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAll(int page = 1, string search = null)
        {
            var query = _context.Books.Where(p => !p.IsDeleted);
            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search));
            ListDto<BookListItemDto> listDto = new ListDto<BookListItemDto>
            {
                Items = query.Skip((page - 1) * 8).Take(8).Select(p =>
                    new BookListItemDto
                    {
                        Id = p.id,
                        Name = p.Name,
                        SalePrice = p.SalePrice,
                        CostPrice = p.CostPrice,
                        DisplayStatus = p.DisplayStatus,
                        Genr = new GenrInBookListItemDto
                        {
                            Id = p.GenrId,
                            Name = p.Genr.Name
                        },
                         Author = new AuthorInBookListItemDto
                         {
                             Id = p.AuthorId,
                             Name = p.Author.Name
                         }
                    }).ToList(),
                TotalCount = query.Count()
            };
            return Ok(listDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BookPostDto bookPostDtos)
        {
            Book existProduct = _context.Books.FirstOrDefault(x => x.id == id);
            if (existProduct == null) return NotFound();
            if (existProduct.GenrId != bookPostDtos.GenrId && !_context.Genrs.Any(x => x.id == bookPostDtos.GenrId) &&
            existProduct.AuthorId != bookPostDtos.AuthorId && !_context.Authors.Any(x => x.id == bookPostDtos.AuthorId && !x.IsDeleted))
                return NotFound();

            existProduct.GenrId = bookPostDtos.GenrId;
            existProduct.AuthorId = bookPostDtos.AuthorId;
            existProduct.Name = bookPostDtos.Name;
            existProduct.CostPrice = bookPostDtos.CostPrice;
            existProduct.SalePrice = bookPostDtos.SalePrice;
            existProduct.DisplayStatus = bookPostDtos.DisplayStatus;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(p => p.id == id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult ChangeStatus(int id, bool status)
        {
            Book book = _context.Books.FirstOrDefault(p => p.id == id);
            if (book == null) return NotFound();

            book.DisplayStatus = status;
            _context.SaveChanges();
            return NoContent();
        }
    }
}

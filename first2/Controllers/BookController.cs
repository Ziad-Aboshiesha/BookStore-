using first2.DTOs.BookDTO;
using first2.Models;
using first2.Unit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace first2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //generalrepo<Book> repo;
        unitofwork unit;
        public BookController(unitofwork unit)
        {
            this.unit = unit;
        }
        //public BookController(generalrepo<Book> repo)
        //{
        //    this.repo = repo;
        //}
        [HttpGet]
        public IActionResult getall()
        {
            List<Book> books = unit.Books.getall().ToList();
            if (books.Count > 0)
            {
                List<ShowBookDTO> showbooks = new List<ShowBookDTO>();
                foreach (Book book in books)
                {
                    ShowBookDTO showbook = new ShowBookDTO()
                    {
                        id = book.Id,
                        title = book.Title,
                        description = book.Description,
                        price = book.price,
                        stock = book.stock,
                        author = book.author.Name,
                        category = book.category.Name,
                        date = book.date,
                    };
                    showbooks.Add(showbook);
                }
                return Ok(showbooks);

            }
            else return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            Book item = unit.Books.getbyid(id);
            if (item == null) return NotFound();
            ShowBookDTO book = new ShowBookDTO()
            {
                id = item.Id,
                title = item.Title,
                description = item.Description,
                price = item.price,
                stock = item.stock,
                author = item.author.Name,
                category = item.category.Name,
                date = item.date,
            };
            return Ok(book);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult post(addbookDTO item)
        {
            if (item == null) return NotFound();
            if (ModelState.IsValid)
            {
                Book book = new Book()
                {
                    Title = item.title,
                    Description = item.description,
                    price = item.price,
                    stock = item.stock,
                    author_id = item.author,
                    category_id = item.category,
                    date = item.date,
                };
                unit.Books.add(book);
                unit.Books.save();
                return Ok(book);
            }
            else return BadRequest();

        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult put(EditbookDTO item)
        {
            if (ModelState.IsValid)
            {
                Book book = unit.Books.getbyid(item.id);
                if (book == null) return NotFound();
                book.Title = item.title;
                book.Description = item.description;
                book.price = item.price;
                book.stock = item.stock;
                book.author_id = item.author;
                book.category_id = item.category;
                book.date = item.date;
                unit.Books.update(book);
                unit.Books.save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult delete(int id) 
        {
            //Book book = unit.Books.getbyid(id);
            //if (book == null) return NotFound();
            unit.Books.delete(id);
            unit.Books.save();
            return Ok();
        }

    }
}

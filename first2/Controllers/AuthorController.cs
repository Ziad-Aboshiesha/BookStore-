using first2.Models;
using first2.Unit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using first2.DTOs.AuthorDTO;

namespace first2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class AuthorController : ControllerBase
    {
        unitofwork unit;
        public AuthorController(unitofwork unit) { this.unit = unit; }
        [HttpGet]
        public IActionResult getall()
        {
            return Ok(unit.Authors.getall().ToList());
        }
        [HttpPost]
        public IActionResult addauthor(AddAuthorDTO  a)
        {
            if (a != null)
            {
                Author aa = new Author() { Description = a.Description ,Name = a.Name};
                unit.Authors.add(aa);
                unit.Authors.save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult getbyid(int id) 
        
        {
            Author a = unit.Authors.getbyid(id);
            ShowAuthorDTO show = new ShowAuthorDTO()
            {
                Description = a.Description, Name = a.Name,
            };
            foreach (var item in a.Books)
            {
                show.Books.Add(item.Title);
            }
            return Ok(show);

        }

        [HttpPut("{id}")]
        public IActionResult editauthor(int id , AddAuthorDTO a)
        {
            Author aa = new Author()
            {
                Id = id,
                Name = a.Name,
                Description = a.Description,
            };
            unit.Authors.update(aa);
            unit.Authors.save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteauthor(int id) 
        {
            unit.Authors.delete(id);
            unit.Authors.save();

            return Ok();
        }
    }


}

using first2.DTOs.CategoryDTO;
using first2.DTOs.CategoyryDTO;
using first2.Models;
using first2.Unit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace first2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class CategoryController : ControllerBase
    {
        unitofwork unit;
        public CategoryController(unitofwork unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        public IActionResult getall()
        {
            return Ok(unit.Categories.getall().ToList());
        }
        [HttpPost]
        public IActionResult addcategory(AddCategoryDTO a)
        {
            if (a != null)
            {
                Category aa = new Category() { Description = a.Description, Name = a.Name };
                unit.Categories.add(aa);
                unit.Categories.save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult getbyid(int id)

        {
            Category a = unit.Categories.getbyid(id);
            ShowCategoryDTO show = new ShowCategoryDTO()
            {
                Description = a.Description,
                Name = a.Name,
            };
            foreach (var item in a.Books)
            {
                show.Books.Add(item.Title);
            }
            return Ok(show);

        }

        [HttpPut("{id}")]
        public IActionResult editcategory(int id, AddCategoryDTO a)
        {
            Category aa = new Category()
            {
                Id = id,
                Name = a.Name,
                Description = a.Description,
            };
            unit.Categories.update(aa);
            unit.Categories.save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult deletecategory(int id)
        {
            unit.Categories.delete(id);
            unit.Categories.save();

            return Ok();
        }
    }
    //public BookController(unitofwork unit)
    //{

    //}

}

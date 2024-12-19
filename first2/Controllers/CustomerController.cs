using first2.DTOs.CustomerDTO;
using first2.Models;
using first2.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace first2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        UserManager<IdentityUser> userM { get; set; }
        RoleManager<IdentityRole> roleM { get; set; }
        public CustomerController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userM = userManager;
            this.roleM = roleManager;
        }

        [HttpPost]
        public IActionResult create(AddCustomerDTO s)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer() { address = s.address, name = s.CustomerName, Email = s.EmailAddress, UserName = s.user, PhoneNumber = s.phone };
                IdentityResult r = userM.CreateAsync(customer, s.password).Result;
                if (r.Succeeded)
                {
                    IdentityResult rr = userM.AddToRoleAsync(customer, "CUSTOMER").Result;
                    if (rr.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound(rr.Errors);
                    }
                }
                else
                {
                    return BadRequest(r.Errors);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }


        }
        [HttpPut]
        public IActionResult edit(EditCustomerDTO s)
        {
            if (ModelState.IsValid)
            {
                Customer r = (Customer)userM.FindByIdAsync(s.CustomerId).Result;
                if (r != null)
                {
                    r.PhoneNumber = s.phone;
                    r.address = s.address;
                    r.name = s.CustomerName;
                    IdentityResult rr = userM.UpdateAsync(r).Result;
                    if (rr.Succeeded) return NoContent();
                    else return BadRequest(rr.Errors);
                }
                else
                {
                    return NotFound();
                }
            }
            else return BadRequest(ModelState);
        }
        //[HttpPost("change_password")]
        //public IActionResult changepass(ChangePassCustomer s)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityUser r = userM.FindByIdAsync(s.id).Result;
        //        if (r == null) return BadRequest();
        //        else
        //        {
        //            IdentityResult ir = userM.ChangePasswordAsync(r, s.oldpass, s.newpass).Result;
        //            if (!ir.Succeeded) return BadRequest(ir.Errors);
        //            else return Ok();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }

        //}
        [HttpGet]
        public IActionResult getall()
        {
            var customers = userM.GetUsersInRoleAsync("CUSTOMER").Result.OfType<Customer>().ToList();
            if (customers.Count == 0) return NotFound();
            List<ShowCustomers> cs = new List<ShowCustomers>();
            foreach (var user in customers)
            {
                //Customer item = (Customer) user;
                ShowCustomers s = new ShowCustomers() { email = user.Email, CustomerName = user.name, address = user.address, CustomerId = user.Id, phone = user.PhoneNumber };
                cs.Add(s);
            }
            return Ok(cs);
        }

        [HttpGet("{id}")]
        public IActionResult get(string id)
        {
            var r = (Customer)userM.GetUsersInRoleAsync("CUSTOMER").Result.Where(s=>s.Id == id).FirstOrDefault();
            if (r == null) return NotFound();
            ShowCustomers cs = new ShowCustomers() { CustomerName = r.name, address = r.address, CustomerId = r.Id, email = r.Email, phone = r.PhoneNumber };
            return Ok(cs);
        }
    }
}
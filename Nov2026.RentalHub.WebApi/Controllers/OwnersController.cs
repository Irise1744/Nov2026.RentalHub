using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nov2026.Database.EfAppDbContextModels;
using Nov2026.Mvc.Models;

namespace Nov2026.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public OwnersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetOwners()
        {
            var lst= _db.Owners.ToList();
            return Ok(lst);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult GetOwners(int id)
        {
            var item = _db.Owners.FirstOrDefault(x => x.OwnerId == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateOwners(OwnersCreateRequestMmodel requestMmodel)
        {
            _db.Owners.Add(new Owner
            {
                FirstName = requestMmodel.FirstName.Trim(),
                LastName = requestMmodel.LastName.Trim(),
                Email = requestMmodel.Email.Trim(),
                Phone = requestMmodel.Phone.Trim(),
            });
            int result = _db.SaveChanges();
            string message = result > 0 ? "success" : "failure";
            return Ok(message);
        }

        [HttpPut]
        public IActionResult UpdateOwners(int id, OwnersUpdateRequestMmodel requestModel)
        {
            var item = _db.Owners.FirstOrDefault(x => x.OwnerId == id);
            if (item == null)
            {
                return NotFound();
            }
            item.FirstName = requestModel.FirstName.Trim();
            item.LastName = requestModel.LastName.Trim();
            item.Email = requestModel.Email.Trim();
            item.Phone = requestModel.Phone.Trim();
            
            int result = _db.SaveChanges();
            string message = result > 0 ? "success" : "failure";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwners(int id)
        {
            var item = _db.Owners.FirstOrDefault(x => x.OwnerId == id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Owners.Remove(item);
            
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete success" : "Delete fail";
            return Ok(message);
        }
    }
}

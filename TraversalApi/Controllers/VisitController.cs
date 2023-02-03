using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using TraversalApi.Models;

namespace TraversalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {

        private readonly VisitorContext _context;

        public VisitController(VisitorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult VisitorList()
        {
           var values =  _context.Visitors.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddVisitor(Visitor visitor)
        { 
            _context.Visitors.Add(visitor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            var value = _context.Visitors.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Visitors.Remove(value);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            var value = _context.Find<Visitor>(visitor.VisitorId);
            if (value == null)
            {
                return NotFound();

            }
            else
            {
                value.Name = visitor.Name;
                value.Surname = visitor.Surname;
                value.City = visitor.City;
                value.Mail = visitor.Mail;
                _context.Update(value);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVisitor(int id) 
        {
            var value = _context.Visitors.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }





    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db) { _db = db; }

        public IActionResult Index()
        {
            List<Customer> Customers = _db.Customers.Include(c => c.MembershipType).ToList();
            return View(Customers);
        }

        public IActionResult Create()

        {
            var members = _db.MembershipTypes.ToList();
            ViewBag.MembershipTypeIds = members.Select(m => new SelectListItem()
            {
                Text = m.Id.ToString(),
                Value = m.Id.ToString()
            });

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
           // customer.MembershipType = _db.MembershipTypes.FirstOrDefault(m => m.Id == customer.membershipTypeId);
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}

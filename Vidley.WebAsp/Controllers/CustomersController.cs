using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using Vidley.WebAsp.Models;
using Vidley.WebAsp.ViewModels;

namespace Vidley.WebAsp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        //
        // [Route("Customers/Details/{id}")]
        // public ActionResult Details(int id)
        // {
        //     var customer = _context.Customers.Include(c => c.MembershipType)
        //         .SingleOrDefault(c => c.Id == id);
        //
        //     if (customer is null)
        //     {
        //         return HttpNotFound();
        //     }
        //
        //     return View(customer);
        // }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customerInDb.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer is null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }

   
}
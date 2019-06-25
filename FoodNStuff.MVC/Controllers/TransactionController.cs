using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            var transactionList = _db.Transactions.OrderBy(t => t.Customer.LastName).ThenBy(t=>t.Customer.FirstName).ToList();
            return View(transactionList);
        }
        // Get: Transaction/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "ProductName");

            return View();
        }
        // Post: Transaction/Create
       
        [ValidateAntiForgeryToken]
        public ActionResult Create (Transaction transaction)
        {
            if (ModelState.IsValid && transaction.CustomerID != 0 && transaction.ProductID !=0)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(transaction);
        }
        //Get: Details {id}
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult
                    (HttpStatusCode.BadRequest);
            Transaction transaction = _db.Transactions.Find(id);

            if (transaction == null)
                return HttpNotFound();

            return View(transaction);
        }
        //Get: Transaction Edit {id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult
                (HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(_db.Customers.ToList(), "CustomerID", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products.ToList(), "ProductID", "ProductName");
            return View(transaction);
        }
    }
}
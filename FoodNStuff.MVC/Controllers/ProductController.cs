﻿using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> productList = _db.Products.ToList();
            List<Product> orderedList = productList.OrderBy(prod => prod.ProductName).ToList();
            return View(orderedList);
        }

        //Get: Product/Create
        public ActionResult Create()
        {
            return View();
        }
        //Post: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
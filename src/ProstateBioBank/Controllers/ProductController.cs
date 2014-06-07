﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProstateBioBank.Domain;
using ProstateBioBank.Models;

namespace ProstateBioBank.Controllers
{
    public class ProductController : Controller
    {
        private ProstateBioBankContext db = new ProstateBioBankContext();

        // GET: /Product/
        public async Task<ActionResult> Index()
        {
            return View((await db.Products.ToListAsync()).Select(p => new ProductIndexViewModel()
            {
                AlequotId = p.Alequot.Id,
                BiopsyId = p.Alequot.Biopsy.Id,
                PatientId = p.Alequot.Biopsy.Patient.Id,
                Id = p.Id,
                Location = p.Location,
                Created = p.Created
            }));
        }

        // GET: /Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public async Task<ActionResult> Create()
        {
            var model = new ProductCreateModel();
            await SetReferenceData(model);
            return View(model);
        }

        private async Task SetReferenceData(ProductCreateModel model)
        {
            model.AvailableAlequots = (await db.Alequots.ToListAsync()).Select(a => new SelectListItem() { Text = a.Id, Value = a.Id });
            model.AvailableProductTypes = (await db.ProductTypes.ToListAsync()).Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString() });
        }

        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Created,Location,ProductTypeId,AlequotId")] ProductCreateModel productModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Alequot = db.Alequots.Single(a => a.Id == productModel.AlequotId),
                    ProductType = db.ProductTypes.Single(p => p.Id == productModel.ProductTypeId),
                    Created = productModel.Created,
                    Location = productModel.Location
                };
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            await SetReferenceData(productModel);
            return View(productModel);
        }

        // GET: /Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Created,Location")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: /Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

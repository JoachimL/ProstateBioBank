using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProstateBioBank.Models;
using ProstateBioBank.Services;
using ProstateBioBank.ObjectExtensions;
using ProstateBioBank.ServiceModels;

namespace ProstateBioBank.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStore _productStore;
        private readonly IBiopsyStore _biopsyStore;

        public ProductController(IProductStore productStore, IBiopsyStore biopsyStore)
        {
            _productStore = this.GetOrThrowArgumentNullException(productStore, "productStore");
            _biopsyStore = this.GetOrThrowArgumentNullException(biopsyStore, "biopsyStore");
        }

        // GET: /Product/
        public async Task<ActionResult> Index()
        {
            return View((await _productStore.GetProductsAsync()).Select(p => new ProductIndexViewModel()
            {
                AlequotId = p.AlequotId,
                BiopsyId = p.BiopsyId,
                PatientId = p.PatientId,
                Id = p.Id,
                Location = p.Location,
                Created = p.Created
            }));
        }

        // GET: /Product/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = await _productStore.GetProductByIdAsync(id);
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
            model.AvailableAlequots = (await _biopsyStore.GetAlequotsAsync()).Select(a => new SelectListItem() { Text = a.Id, Value = a.Id });
            model.AvailableProductTypes = (await _productStore.GetProductTypesAsync()).Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString() });
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
                    AlequotId = productModel.AlequotId,
                    ProductTypeId = productModel.ProductTypeId,
                    Created = productModel.Created,
                    Location = productModel.Location
                };
                await _productStore.AddProductAsync(product);
                return RedirectToAction("Index");
            }

            await SetReferenceData(productModel);
            return View(productModel);
        }

        // GET: /Product/Edit/5
        public Task<ActionResult> Edit(int? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var product = await db.Products.FindAsync(id);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> Edit([Bind(Include = "Id,Created,Location")] Product product)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    db.Entry(product).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(product);
        }

        // GET: /Product/Delete/5
        public Task<ActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Product product = await db.Products.FindAsync(id);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _productStore.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
    }
}

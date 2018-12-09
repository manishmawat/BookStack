using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStack.Data;
using BookStack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var results = _db.ProductTypes.ToList();
            return View(results);
        }

        //Get
        public async Task<ActionResult<ProductTypes>> ProductTypeDetails(int productTypeId)
        {
            var productType = await _db.ProductTypes.FindAsync(productTypeId);
            return View(productType);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes producType)
        {
            if(ModelState.IsValid)
            {
                await _db.AddAsync(producType);
                await _db.SaveChangesAsync();
                //return RedirectToAction(nameof(ProductTypeDetails), new { productTypeId = producType.Id });
                return RedirectToAction(nameof(Index));
            }
            return View(producType);
        }

        //Get Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
                return NotFound();
            return View(productType);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int productTypeId,ProductTypes producType)
        {
            if (ModelState.IsValid)
            {
                //await _db.AddAsync(producType);
                _db.ProductTypes.Update(producType);
                await _db.SaveChangesAsync();
                //return RedirectToAction(nameof(ProductTypeDetails), new { productTypeId = producType.Id });
                return RedirectToAction(nameof(Index));
            }
            return View(producType);
        }

        //Get Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
                return NotFound();
            return View(productType);
        }


        //Get Edit
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
                return NotFound();
            return View(productType);
        }

        //POST Delet
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var productTypes = await _db.ProductTypes.FindAsync(Id);
            _db.ProductTypes.Remove(productTypes);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
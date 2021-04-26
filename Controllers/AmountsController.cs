using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChequeSYs.Data;
using ChequeSYs.Models;

namespace ChequeSYs.Controllers
{
    public class AmountsController : Controller
    {
        private readonly ChequeSYsContext _context;

        public AmountsController(ChequeSYsContext context)
        {
            _context = context;
        }

        // GET: Amounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amount.ToListAsync());
        }

        // GET: Amounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amount = await _context.Amount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amount == null)
            {
                return NotFound();
            }

            return View(amount);
        }

        // GET: Amounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,amountNum")] Amount amount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amount);

        }

        // GET: Amounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amount = await _context.Amount.FindAsync(id);
            if (amount == null)
            {
                return NotFound();
            }
            return View(amount);
        }

        // POST: Amounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,amountNum")] Amount amount)
        {
            if (id != amount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmountExists(amount.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(amount);
        }

        // GET: Amounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amount = await _context.Amount
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amount == null)
            {
                return NotFound();
            }

            return View(amount);
        }

        // POST: Amounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amount = await _context.Amount.FindAsync(id);
            _context.Amount.Remove(amount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmountExists(int id)
        {
            return _context.Amount.Any(e => e.ID == id);
        }
    }
}

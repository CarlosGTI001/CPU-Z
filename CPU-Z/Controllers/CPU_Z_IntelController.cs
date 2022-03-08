using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPU_Z.Data;
using CPU_Z.Models;

namespace CPU_Z.Controllers
{
    public class CPU_Z_IntelController : Controller
    {
        private readonly CPU_ZContext _context;

        public CPU_Z_IntelController(CPU_ZContext context)
        {
            _context = context;
        }

        // GET: CPU_Z_Intel
        public async Task<IActionResult> Index()
        {
            return View(await _context.CPU_Z_Intel.ToListAsync());
        }

        // GET: CPU_Z_Intel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU_Z_Intel = await _context.CPU_Z_Intel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPU_Z_Intel == null)
            {
                return NotFound();
            }

            return View(cPU_Z_Intel);
        }

        // GET: CPU_Z_Intel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CPU_Z_Intel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Litografia,Arquitectura,fechaLanzamiento,precioLanzamiento,Socket,Nucleos,Hilos,FrecuenciaBase,FrecuenciaTurbo,RelojBase,MultiplicadorReloj,cacheL1,cacheL2,cacheL3,RamDDR,imgUrl")] CPU_Z_Intel cPU_Z_Intel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cPU_Z_Intel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cPU_Z_Intel);
        }

        // GET: CPU_Z_Intel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU_Z_Intel = await _context.CPU_Z_Intel.FindAsync(id);
            if (cPU_Z_Intel == null)
            {
                return NotFound();
            }
            return View(cPU_Z_Intel);
        }

        // POST: CPU_Z_Intel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Litografia,Arquitectura,fechaLanzamiento,precioLanzamiento,Socket,Nucleos,Hilos,FrecuenciaBase,FrecuenciaTurbo,RelojBase,MultiplicadorReloj,cacheL1,cacheL2,cacheL3,RamDDR,imgUrl")] CPU_Z_Intel cPU_Z_Intel)
        {
            if (id != cPU_Z_Intel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cPU_Z_Intel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPU_Z_IntelExists(cPU_Z_Intel.ID))
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
            return View(cPU_Z_Intel);
        }

        // GET: CPU_Z_Intel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU_Z_Intel = await _context.CPU_Z_Intel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPU_Z_Intel == null)
            {
                return NotFound();
            }

            return View(cPU_Z_Intel);
        }

        // POST: CPU_Z_Intel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cPU_Z_Intel = await _context.CPU_Z_Intel.FindAsync(id);
            _context.CPU_Z_Intel.Remove(cPU_Z_Intel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CPU_Z_IntelExists(int id)
        {
            return _context.CPU_Z_Intel.Any(e => e.ID == id);
        }
    }
}

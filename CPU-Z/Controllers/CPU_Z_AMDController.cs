using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPU_Z.Data;
using CPU_Z.Models;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;


namespace CPU_Z.Controllers
{
    public class CPU_Z_AMDController : Controller
    {
        private readonly CPU_ZContext _context;

        public CPU_Z_AMDController(CPU_ZContext context)
        {
            _context = context;
        }

        // GET: CPU_Z_AMD
        public async Task<IActionResult> Index()
        {
            return View(await _context.CPU_Z_AMD.ToListAsync());
        }

        // GET: CPU_Z_AMD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU_Z_AMD = await _context.CPU_Z_AMD
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPU_Z_AMD == null)
            {
                return NotFound();
            }

            return View(cPU_Z_AMD);
        }

        // GET: CPU_Z_AMD/Create
        

        public IActionResult Create()
        {
            return View();
        }

        // POST: CPU_Z_AMD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Litografia,Arquitectura,fechaLanzamiento,precioLanzamiento,Socket,Nucleos,Hilos,FrecuenciaBase,FrecuenciaTurbo,cacheL1,cacheL2,cacheL3,RamDDR,imgUrl")] CPU_Z_AMD cPU_Z_AMD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cPU_Z_AMD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cPU_Z_AMD);
        }

        // GET: CPU_Z_AMD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU_Z_AMD = await _context.CPU_Z_AMD.FindAsync(id);
            if (cPU_Z_AMD == null)
            {
                return NotFound();
            }
            return View(cPU_Z_AMD);
        }

        // POST: CPU_Z_AMD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Litografia,Arquitectura,fechaLanzamiento,precioLanzamiento,Socket,Nucleos,Hilos,FrecuenciaBase,FrecuenciaTurbo,cacheL1,cacheL2,cacheL3,RamDDR,imgUrl")] CPU_Z_AMD cPU_Z_AMD)
        {
            if (id != cPU_Z_AMD.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cPU_Z_AMD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPU_Z_AMDExists(cPU_Z_AMD.ID))
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
            return View(cPU_Z_AMD);
        }

        // GET: CPU_Z_AMD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cPU_Z_AMD = await _context.CPU_Z_AMD
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cPU_Z_AMD == null)
            {
                return NotFound();
            }

            return View(cPU_Z_AMD);
        }

        // POST: CPU_Z_AMD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cPU_Z_AMD = await _context.CPU_Z_AMD.FindAsync(id);
            _context.CPU_Z_AMD.Remove(cPU_Z_AMD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CPU_Z_AMDExists(int id)
        {
            return _context.CPU_Z_AMD.Any(e => e.ID == id);
        }
    }
}

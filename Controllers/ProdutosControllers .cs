using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using provateste.Models;
using Microsoft.EntityFrameworkCore;
using provateste.Models.Data;


namespace provateste.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoContext _context;

        public ProdutosController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index(string search)
        {
            var produtos = from p in _context.produtos select p;

            if (!string.IsNullOrEmpty(search))
            {
                produtos = produtos.Where(p => p.Nome.Contains(search));
            }

            return View(await produtos.ToListAsync());
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _context.produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _context.produtos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }
        // POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.produtos.FindAsync(id);
            if (produto == null) return NotFound();
            return View(produto);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.produtos.FindAsync(id);
            _context.produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

}

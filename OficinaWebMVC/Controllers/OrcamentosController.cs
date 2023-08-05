using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OficinaWebMVC.Database.Contexto;
using OficinaWebMVC.Database.Entities;
using OficinaWebMVC.Models;

namespace OficinaWebMVC.Controllers
{
    public class OrcamentosController : Controller
    {
        private readonly OficinaDBContexto _context;

        public OrcamentosController(OficinaDBContexto context)
        {
            _context = context;
        }

        // GET: Orcamentos
        public async Task<IActionResult> Index()
        {
            var orcamentos = await _context.Orcamentos.Include(o=> o.Cliente).Include(o=> o.Veiculo).ToListAsync();
            List<OrcamentoModel> orcamentoModel = new List<OrcamentoModel>();

            //var config = await _context.Configuracoes.FirstOrDefaultAsync(a => a.NomeConfiguracao == "PrazoOrcamento");
           foreach (Orcamento o in orcamentos)
            {
                OrcamentoModel model = new()
                {
                    Id = o.Id,
                    Cliente = o.Cliente,
                    Veiculo = o.Veiculo,
                    CpfResponsavel = o.CpfResponsavel,
                    PrazoOrcamento = o.DataPrazoOrcamento,
                    Responsavel = o.Responsavel,
                    StatusOrcamento = o.StatusOrcamento,
                    ValorTotal = o.ValorTotal,
                };
                orcamentoModel.Add(model);
            }
              return _context.Orcamentos != null ? 
                          View(orcamentoModel) :
                          Problem("Entity set 'OficinaDBContexto.Orcamentos'  is null.");
        }

        // GET: Orcamentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // GET: Orcamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orcamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataInicialOrcamento,DataAprovacaoCliente,DataFinalOrcamento,ValorTotal,Responsavel,CpfResponsavel,StatusOrcamento,Id")] Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                orcamento.Id = Guid.NewGuid();
                _context.Add(orcamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orcamento);
        }

        // GET: Orcamentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos.FindAsync(id);
            if (orcamento == null)
            {
                return NotFound();
            }
            return View(orcamento);
        }

        // POST: Orcamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DataInicialOrcamento,DataAprovacaoCliente,DataFinalOrcamento,ValorTotal,Responsavel,CpfResponsavel,StatusOrcamento,Id")] Orcamento orcamento)
        {
            if (id != orcamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoExists(orcamento.Id))
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
            return View(orcamento);
        }

        // GET: Orcamentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Orcamentos == null)
            {
                return NotFound();
            }

            var orcamento = await _context.Orcamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            return View(orcamento);
        }

        // POST: Orcamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Orcamentos == null)
            {
                return Problem("Entity set 'OficinaDBContexto.Orcamentos'  is null.");
            }
            var orcamento = await _context.Orcamentos.FindAsync(id);
            if (orcamento != null)
            {
                _context.Orcamentos.Remove(orcamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoExists(Guid id)
        {
          return (_context.Orcamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

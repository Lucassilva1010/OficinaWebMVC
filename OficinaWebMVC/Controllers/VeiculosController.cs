using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OficinaWebMVC.Database.Contexto;
using OficinaWebMVC.Database.Entities;
using OficinaWebMVC.Enums;
using OficinaWebMVC.Models;

namespace OficinaWebMVC.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly OficinaDBContexto _context;

        public VeiculosController(OficinaDBContexto context)
        {
            _context = context;
        }

        // GET: Veiculos

        public async Task<IActionResult> Index()
        {
            var veiculos = await _context.Veiculo.Include(a=>a.Cliente).ToListAsync();
           
            List<ListaVeiculos> listaVeiculos = new List<ListaVeiculos>();
            
            foreach (Veiculo item in veiculos)
            {
                if (item is Moto moto)
                {
                    listaVeiculos.Add(new ListaVeiculos { Ano = moto.Ano, CodChassi = moto.CodChassi, IdVeiculo = moto.Id, Placa = moto.Placa, PorteMoto = moto.PorteMoto, Cliente = new ClienteModel { Nome = moto.Cliente.Nome, Email = moto.Cliente.Email}, Marca = moto.Marca, Modelo = moto.Modelo });
                }
                if (item is Carro carro)
                {
                    listaVeiculos.Add(new ListaVeiculos { Ano = carro.Ano, CodChassi = carro.CodChassi, IdVeiculo = carro.Id, Placa = carro.Placa, PorteCarro = carro.PorteCarro, Cliente = new ClienteModel {Nome = carro.Cliente.Nome, Email = carro.Cliente.Email }, Marca = carro.Marca, Modelo = carro.Modelo });
                }
            }

              return _context.Veiculo != null ? 
                          View(listaVeiculos) :
                          Problem("Entity set 'OficinaDBContexto.Veiculo'  is null.");


        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Veiculo == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }


            var listaVeiculo = new ListaVeiculos
            {
                Ano = veiculo.Ano,
                CodChassi = veiculo.CodChassi,
                IdVeiculo = veiculo.Id,
                Placa = veiculo.Placa,
                PorteCarro = (veiculo as Carro)?.PorteCarro,
                PorteMoto = (veiculo as Moto)?.PorteMoto,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo
            };



            return View(listaVeiculo);
        }

        // GET: Veiculos/Create
        public async Task<IActionResult> CreateMoto()
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            var selectList = clientes.Select(c => new SelectListItem { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            var selecDefault = new SelectListItem { Text = "Selecione", Value = "0", Selected = true };
            selectList.Add(selecDefault);
            ViewBag.Clientes = selectList;

            return View();
        }
        public async Task<IActionResult> CreateCarro( )
        {
            List<Cliente> clientes = await _context.Clientes.ToListAsync();
            var selectList = clientes.Select(c => new SelectListItem { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            var selecDefault = new SelectListItem { Text = "Selecione", Value = "0", Selected = true };
            selectList.Add(selecDefault);
            ViewBag.Clientes = selectList;
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCarro([Bind("Placa,Ano,CodChassi,PorteCarro,Marca,Modelo,IdCliente")]VeiculoCarroModel veiculoCarroModel )
        {
            if (ModelState.IsValid)
            {
               Carro veiculo = new Carro();
                   
                veiculo.Id = Guid.NewGuid();
                veiculo.Cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == veiculoCarroModel.IdCliente);
                   
                veiculo.Placa = veiculoCarroModel.Placa;
                veiculo.PorteCarro = veiculoCarroModel.PorteCarro;
                veiculo.CodChassi = veiculoCarroModel.CodChassi;
                veiculo.Ano = veiculoCarroModel.Ano;
                veiculo.Marca = veiculoCarroModel.Marca;
                veiculo.Modelo = veiculoCarroModel.Modelo;

                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculoCarroModel);
        }
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMoto([Bind("Placa,Ano,CodChassi,PorteMoto,Marca, Modelo,IdCliente")] VeiculoMotoModel veiculoMotoModel)
        {
            if (ModelState.IsValid)
            {
                Moto veiculoMoto= new Moto();

                veiculoMoto.Id = Guid.NewGuid();
                veiculoMoto.Cliente = await _context.Clientes.FirstOrDefaultAsync(c=> c.Id == veiculoMotoModel.IdCliente);
                veiculoMoto.Placa = veiculoMotoModel.Placa;
                veiculoMoto.PorteMoto = veiculoMotoModel.PorteMoto;
                veiculoMoto.CodChassi = veiculoMotoModel.CodChassi;
                veiculoMoto.Ano = veiculoMotoModel.Ano;
                veiculoMoto.Marca = veiculoMotoModel.Marca;
                veiculoMoto.Modelo = veiculoMotoModel.Modelo;
               
                _context.Add(veiculoMoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculoMotoModel);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Veiculo == null)
            {
                return NotFound();
            }
            

            var veiculo = await _context.Veiculo.FindAsync(id);
        
            if (veiculo == null)
            {
                return NotFound();
            }

            var listaVeiculo = new ListaVeiculos { Ano = veiculo.Ano, CodChassi = veiculo.CodChassi, IdVeiculo = veiculo.Id,
                Placa = veiculo.Placa, PorteCarro = (veiculo as Carro)?.PorteCarro,  PorteMoto = (veiculo  as Moto)?.PorteMoto, Marca = veiculo.Marca, Modelo = veiculo.Modelo};


            return View(listaVeiculo);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Placa,Ano,CodChassi,PorteCarro,PorteMoto,IdVeiculo, Modelo, Marca")] ListaVeiculos listaVeiculo)
        {


            if (id != listaVeiculo.IdVeiculo)
            {
                return NotFound();
            }
           

            if (ModelState.IsValid)
            {
                try
                {
                    var veiculo  = await _context.Veiculo.FirstOrDefaultAsync(i=> i.Id == listaVeiculo.IdVeiculo);
                    if (veiculo == null)
                    {
                        return NotFound();
                    }

                    veiculo.Placa = listaVeiculo.Placa;
                    veiculo.Ano = listaVeiculo.Ano;
                    veiculo.CodChassi = listaVeiculo.CodChassi;
                    veiculo.Marca = listaVeiculo.Marca;
                    veiculo.Modelo = listaVeiculo.Modelo;

                    if (veiculo is Carro carro)
                    {
                        carro.PorteCarro = (PorteCarro)listaVeiculo.PorteCarro!;
                    }
                    if (veiculo is Moto moto)
                    {
                        moto.PorteMoto = (PorteMoto)listaVeiculo.PorteMoto!;
                    }
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(listaVeiculo.IdVeiculo))
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
            return View(listaVeiculo);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Veiculo == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }
            var listaVeiculo = new ListaVeiculos
            {
                Ano = veiculo.Ano,
                CodChassi = veiculo.CodChassi,
                IdVeiculo = veiculo.Id,
                Placa = veiculo.Placa,
                PorteCarro = (veiculo as Carro)?.PorteCarro,
                PorteMoto = (veiculo as Moto)?.PorteMoto,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo
                
            };


            return View(listaVeiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Veiculo == null)
            {
                return Problem("Entity set 'OficinaDBContexto.Veiculo'  is null.");
            }
            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculo.Remove(veiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(Guid id)
        {
          return (_context.Veiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

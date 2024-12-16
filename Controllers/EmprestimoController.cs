using EmprestimoApp.Data;
using EmprestimoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimoApp.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly EmprestimoContext _context;
        public EmprestimoController(EmprestimoContext context) => _context = context;
        public IActionResult Emprestimo()
        {
            IEnumerable<Emprestimo> emprestimos = _context.Emprestimos.ToList();
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Emprestimo emprestimo) 
        {
            if (ModelState.IsValid) 
            {
                _context.Emprestimos.Add(emprestimo);
                _context.SaveChanges();

                TempData["Sucesso"] = "Cadastro realizado com sucesso !";
                return RedirectToAction("Emprestimo");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            var emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimo == null) return NotFound();


            return View(emprestimo);
        }
        [HttpPost]
        public IActionResult Editar(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Update(emprestimo);
                _context.SaveChanges();

                TempData["Aviso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Emprestimo");
            }
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if(id==null || id==0) return NotFound();
            var _emprestimo = _context.Emprestimos.FirstOrDefault(x=>x.Id == id);
            if(_emprestimo == null) return NotFound();

            return View(_emprestimo);
        }
        [HttpPost]
        public IActionResult Excluir(Emprestimo emprestimo)
        {
            if (emprestimo == null) return NotFound();

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();

            TempData["Danger"] = "Remoção realizada com sucesso!";

            return RedirectToAction("Emprestimo");
        }

        private DataTable GetDados()
        {
            DataTable data = new DataTable();
            data.TableName = "Dados de emprestimos";

            data.Columns.Add("Recebedor", typeof(string));
            data.Columns.Add("Fornecedor", typeof (string));
            data.Columns.Add("Livro",typeof (string));
            data.Columns.Add("DataEmprestimo", typeof(DateTime));

            var dados = _context.Emprestimos.ToList();
            if (dados.Count > 0) 
            {
                dados.ForEach(x =>
                data.Rows.Add(x.Recebedor, x.Fornecedor, x.Livro, x.DataEmprestimo));
            }
            return data;
        }

        public IActionResult Exportar()
        {
            var dados = GetDados();

            
            return Ok();
        }
    }
}

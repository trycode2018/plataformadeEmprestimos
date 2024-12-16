using EmprestimoApp.Data;
using EmprestimoApp.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post(Emprestimo emprestimo) 
        {
            if (ModelState.IsValid) 
            {
                _context.Emprestimos.Add(emprestimo);
                _context.SaveChanges();
                return RedirectToAction("Emprestimo");
            }
            return View();
        }
    }
}

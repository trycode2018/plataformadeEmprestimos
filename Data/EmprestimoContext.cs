using EmprestimoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoApp.Data
{
    public class EmprestimoContext(DbContextOptions<EmprestimoContext> options) :DbContext(options)
    {
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EmprestimoApp.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do fornecedor")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage ="Digite o nome da pessoa que esta a emprestar")]
        public string Recebedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do livro")]
        public string Livro { get; set; }
        [Required(ErrorMessage = "Selecione a data de emprestimo")]
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;


    }
}

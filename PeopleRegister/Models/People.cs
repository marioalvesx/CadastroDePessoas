using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRegister.Models
{
    public class People
    {
        private int id;
        private string nome;
        private string telefone;

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome precisa ter entre 3 e 100 caracteres.")]
        public string Nome { get => nome; set => nome = value; }

        [Required(ErrorMessage = "Telefone é obrigatório.")]
        [StringLength(100, MinimumLength = 9, ErrorMessage = "Nome precisa ter no mínimo 9 caracteres.")]
        public string Telefone { get => telefone; set => telefone = value; }
    }
}

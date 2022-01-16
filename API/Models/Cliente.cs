using System;


namespace API.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

        public int Cidadeid { get; set; }

        public Cidade Cidade { get; set; }




    }
}

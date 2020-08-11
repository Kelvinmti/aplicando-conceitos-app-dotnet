using System;
using System.Collections.Generic;

namespace GerFin.ApplicationCore.Entity
{
    public class Receita
    {
        public int ReceitaId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool? Recebido { get; set; }
        public DateTime? DataRecebido { get; set; }
        public bool? Recorrente { get; set; }

        public bool IsValid() 
        {
           return !string.IsNullOrEmpty(Descricao) && Valor > 0; 
        }
    }
}

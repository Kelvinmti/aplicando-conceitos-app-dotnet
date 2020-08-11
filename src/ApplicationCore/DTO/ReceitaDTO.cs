using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace GerFin.ApplicationCore.DTO
{
    public class ReceitaDTO
    {
        public int ReceitaId { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo valor é obrigatório.")]
        public decimal Valor { get; set; }
        public bool? Recebido { get; set; }
        public DateTime? DataRecebido { get; set; }
        public bool? Recorrente { get; set; }

        public string ValorFormatado()
        {
            return Valor.ToString("C2", CultureInfo.CurrentCulture);
        }
    }
}

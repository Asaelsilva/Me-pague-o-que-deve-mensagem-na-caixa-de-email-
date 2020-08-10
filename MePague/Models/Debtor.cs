using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MePague.Models
{
    public class Debtor
    {

        [DisplayName("Seu nome")]
        public string Name { get; set; }

        [DisplayName("Mensagem")]
        public string Message { get; set; }

        [DisplayName("valor")]
        public string Totaldebt { get; set; }

        [DisplayName("Email do caloteiro(a)")]
        public string Email { get; set; }
    }
}
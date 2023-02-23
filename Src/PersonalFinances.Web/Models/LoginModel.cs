using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Web.Models
{
    public class LoginModel
    {
        [DisplayName("Email")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public int Login { get; set; }
        
        [DisplayName("Senha")]
        [Required(ErrorMessage ="The Password is Required")]
        public int Password { get; set; }
    }
}
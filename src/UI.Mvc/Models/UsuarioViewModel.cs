using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Mvc.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

    }
}
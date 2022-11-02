﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CooperativaTres.Models
{
    public class Usuario
    {
        private int usuarioId { get; set; }
        private String apellido { get; set; }
        private String nombre { get; set; }
        private String email { get; set; }
        private String password { get; set; }
        private DateTime fechaDeNacimiento { get; set; }
        private List<Entrada> entradas { get; set; }
    }
}
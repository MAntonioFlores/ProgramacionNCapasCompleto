﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public ML.Pais Pais { get; set; }
        public List<ML.Estado> Estados { get; set; }
    }
}

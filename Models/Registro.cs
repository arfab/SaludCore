using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaludCore.Models
{
    public class Registro
    {

        public string errorDesc = "";

        public int id { get; set; }

        public int paciente_id { get; set; }

        public string fecha { get; set; }

        public string hora { get; set; }

        public int comida_id { get; set; }

        public string comida { get; set; }

        public string descripcion { get; set; }

    }
}

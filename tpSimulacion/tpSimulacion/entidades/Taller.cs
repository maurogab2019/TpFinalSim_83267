using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpSimulacion.entidades
{
    public class Taller
    {
        public int numeroTaller { get; set; }
        public int tiempoReparacion { get; set; }
        public int finReparacion { get; set; }

        public string estado { get; set; } = "L";

        public Patrulla patrulla { get; set; }


        public int InicioOcio { get; set; } = 0;

        public int FinOcio { get; set; }


        public void Reparando(Taller taller)
        {
            taller.estado = "Rep";
        }


        public void LiberarTaller(Taller taller)
        {
            taller.estado = "L";
        }
    }
}

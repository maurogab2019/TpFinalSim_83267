using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpSimulacion.entidades
{
    public class Patrulla
    {
        public int numeroPatrulla { get; set; }
        public string estado { get; set; } = "D";

        public int proximaLlegadaReparación { get; set; }

        public double RndPrimerRotura { get; set; }

        public int tiempoProximaRotura { get; set; }

        public int InicioReparacion { get; set; }

        public int FinReparacion { get; set; }

        public int CantidadReparaciones { get; set; }


        public void Repararndo(Patrulla grua)
        {
            grua.estado = "S.R";
        }

        public void EsperarEnCola(Patrulla grua)
        {
            grua.estado = "E.C";
        }

        public void Trabajando(Patrulla grua)
        {
            grua.estado = "D";
        }



        public bool hayDisponibilidadTaller(List<Taller> listaTaller)
        {
            var bandera = false;
            for (var i = 0; i < 8; i++)
            {
                if (listaTaller[i].estado == "L")
                {
                    bandera = true;
                    break;
                }
            }
            return bandera;
        }

    }
}

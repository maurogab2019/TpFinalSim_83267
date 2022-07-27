using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tpSimulacion.entidades;

namespace tpSimulacion
{
    public partial class TpSIM : Form
    {
        public TpSIM()
        {
            InitializeComponent();
            label2.Visible = false;
            txtN.Text = "100000";
            txtMin.Text = "1";
            txtMax.Text = "4";
            txtCantDiasReparacion.Text = "20";
            txtMinUniformePrimerLLegada.Text = "1";
            txtMaxUniformeprimerLLegada.Text = "20";
            dgvTabla.AllowUserToAddRows = false;
            dgvTabla.Visible = false;
        }

        public int devolverTiempoPrimeraRotura(double RND,int minimoUniforme,int maximoUniforme)
        {
            var tiempoNuevaRotura = (int)Math.Truncate(minimoUniforme + (RND * (maximoUniforme - minimoUniforme + 1)));
            return tiempoNuevaRotura;

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

        public Taller traerTallerLibre(List<Taller> listaTaller)
        {
            var  taller = new Taller();
            for (var i = 0; i < 8; i++)
            {
                if (listaTaller[i].estado == "L")
                {
                    taller = listaTaller[i];
                    break;
                }
            }
            return taller;
        }

        public void mostrarTabla(Registro registro, List<Taller> listaTaller, List<Patrulla> listaGruas )
        {
            var fila2 = new string[]
            {
                            registro.reloj.ToString(),
                            registro.evento.ToString(),
                            registro.RndTiempoReparacion.ToString(),
                            registro.tiempoReparacion.ToString(),


                            listaTaller[0].finReparacion.ToString(),
                            listaTaller[1].finReparacion.ToString(),
                            listaTaller[2].finReparacion.ToString(),
                            listaTaller[3].finReparacion.ToString(),
                            listaTaller[4].finReparacion.ToString(),
                            listaTaller[5].finReparacion.ToString(),
                            listaTaller[6].finReparacion.ToString(),
                            listaTaller[7].finReparacion.ToString(),


                            listaTaller[0].estado == "Rep" ? listaTaller[0].estado.ToString()+"("+(listaTaller[0].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L"+" |"+ listaTaller[0].InicioOcio.ToString(), 
                            listaTaller[1].estado == "Rep" ? listaTaller[1].estado.ToString()+"("+(listaTaller[1].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[1].InicioOcio.ToString(),
                            listaTaller[2].estado == "Rep" ? listaTaller[2].estado.ToString()+"("+(listaTaller[2].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L"+" |"+ listaTaller[2].InicioOcio.ToString(), 
                            listaTaller[3].estado == "Rep" ? listaTaller[3].estado.ToString()+"("+(listaTaller[3].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[3].InicioOcio.ToString(),
                            listaTaller[4].estado == "Rep" ? listaTaller[4].estado.ToString()+"("+(listaTaller[4].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[4].InicioOcio.ToString(),
                            listaTaller[5].estado == "Rep" ? listaTaller[5].estado.ToString()+"("+(listaTaller[5].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[5].InicioOcio.ToString(),
                            listaTaller[6].estado == "Rep" ? listaTaller[6].estado.ToString()+"("+(listaTaller[6].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[6].InicioOcio.ToString(),
                            listaTaller[7].estado == "Rep" ? listaTaller[7].estado.ToString()+"("+(listaTaller[7].patrulla.numeroPatrulla+ 1).ToString()+ ")" : "L" +" |"+ listaTaller[7].InicioOcio.ToString(),
                            registro.cantidadPatrullasCola.ToString(),
                            registro.AcumuladorTiemposReparacion.ToString(),
                            registro.ContadorPatrullasReparadas.ToString(),
                            registro.PromedioTiempoReparacion.ToString(),
                            registro.tiempoMaximoReparacion.ToString(),
                            registro.cantidadMaximaEnCola.ToString(),
                            registro.cantidadGruasDisponibles.ToString(),
                            registro.promedioGruasDisponibles.ToString(),
                            //registro.tiempoOciosoCapacidades.ToString(),
                            registro.PromedioDiasOciosos.ToString(),
                            registro.AcumuladortiempoOciosoCapacidades.ToString(),
                            registro.MaximoReparacionPorGrua.ToString(),
                            registro.tiempoProxRotura.ToString(),
                            listaGruas[0].proximaLlegadaReparación.ToString() + "|" + listaGruas[0].estado.ToString(), 
                            listaGruas[1].proximaLlegadaReparación.ToString() + "|" + listaGruas[1].estado.ToString(),
                            listaGruas[2].proximaLlegadaReparación.ToString() + "|" + listaGruas[2].estado.ToString(),
                            listaGruas[3].proximaLlegadaReparación.ToString() + "|" + listaGruas[3].estado.ToString(),
                            listaGruas[4].proximaLlegadaReparación.ToString() + "|" + listaGruas[4].estado.ToString(),
                            listaGruas[5].proximaLlegadaReparación.ToString() + "|" + listaGruas[5].estado.ToString(),
                            listaGruas[6].proximaLlegadaReparación.ToString() + "|" + listaGruas[6].estado.ToString(),
                            listaGruas[7].proximaLlegadaReparación.ToString() + "|" + listaGruas[7].estado.ToString(),
                            listaGruas[8].proximaLlegadaReparación.ToString() + "|" + listaGruas[8].estado.ToString(),
                            listaGruas[9].proximaLlegadaReparación.ToString() + "|" + listaGruas[9].estado.ToString(),
                            listaGruas[10].proximaLlegadaReparación.ToString() + "|" + listaGruas[10].estado.ToString(),
                            listaGruas[11].proximaLlegadaReparación.ToString() + "|" + listaGruas[11].estado.ToString(),
                            listaGruas[12].proximaLlegadaReparación.ToString() + "|" + listaGruas[12].estado.ToString(),
                            listaGruas[13].proximaLlegadaReparación.ToString() + "|" + listaGruas[13].estado.ToString(),
                            listaGruas[14].proximaLlegadaReparación.ToString() + "|" + listaGruas[14].estado.ToString(),
                            listaGruas[15].proximaLlegadaReparación.ToString() + "|" + listaGruas[15].estado.ToString(),
                            listaGruas[16].proximaLlegadaReparación.ToString() + "|" + listaGruas[16].estado.ToString(),
                            listaGruas[17].proximaLlegadaReparación.ToString() + "|" + listaGruas[17].estado.ToString(),
                            listaGruas[18].proximaLlegadaReparación.ToString() + "|" + listaGruas[18].estado.ToString(),
                            listaGruas[19].proximaLlegadaReparación.ToString() + "|" + listaGruas[19].estado.ToString(),
                            listaGruas[20].proximaLlegadaReparación.ToString() + "|" + listaGruas[20].estado.ToString(),
                            listaGruas[21].proximaLlegadaReparación.ToString() + "|" + listaGruas[21].estado.ToString(),
                            listaGruas[22].proximaLlegadaReparación.ToString() + "|" + listaGruas[22].estado.ToString(),
                            listaGruas[23].proximaLlegadaReparación.ToString() + "|" + listaGruas[23].estado.ToString(),
                            listaGruas[24].proximaLlegadaReparación.ToString() + "|" + listaGruas[24].estado.ToString(),
                            listaGruas[25].proximaLlegadaReparación.ToString() + "|" + listaGruas[25].estado.ToString(),
                            listaGruas[26].proximaLlegadaReparación.ToString() + "|" + listaGruas[26].estado.ToString(),
                            listaGruas[27].proximaLlegadaReparación.ToString() + "|" + listaGruas[27].estado.ToString(),
                            listaGruas[28].proximaLlegadaReparación.ToString() + "|" + listaGruas[28].estado.ToString(),
                            listaGruas[29].proximaLlegadaReparación.ToString() + "|" + listaGruas[29].estado.ToString(),
                            listaGruas[30].proximaLlegadaReparación.ToString() + "|" + listaGruas[30].estado.ToString(),
                            listaGruas[31].proximaLlegadaReparación.ToString() + "|" + listaGruas[31].estado.ToString(),
                            listaGruas[32].proximaLlegadaReparación.ToString() + "|" + listaGruas[32].estado.ToString(),
                            listaGruas[33].proximaLlegadaReparación.ToString() + "|" + listaGruas[33].estado.ToString(),
                            listaGruas[34].proximaLlegadaReparación.ToString() + "|" + listaGruas[34].estado.ToString(),
                            listaGruas[35].proximaLlegadaReparación.ToString() + "|" + listaGruas[35].estado.ToString(),
                            listaGruas[36].proximaLlegadaReparación.ToString() + "|" + listaGruas[36].estado.ToString(),
                            listaGruas[37].proximaLlegadaReparación.ToString() + "|" + listaGruas[37].estado.ToString(),
                            listaGruas[38].proximaLlegadaReparación.ToString() + "|" + listaGruas[38].estado.ToString(),
                            listaGruas[39].proximaLlegadaReparación.ToString() + "|" + listaGruas[39].estado.ToString(),
                            listaGruas[40].proximaLlegadaReparación.ToString() + "|" + listaGruas[40].estado.ToString(),
                            listaGruas[41].proximaLlegadaReparación.ToString() + "|" + listaGruas[41].estado.ToString(),
                            listaGruas[42].proximaLlegadaReparación.ToString() + "|" + listaGruas[42].estado.ToString(),
                            listaGruas[43].proximaLlegadaReparación.ToString() + "|" + listaGruas[43].estado.ToString(),
                            listaGruas[44].proximaLlegadaReparación.ToString() + "|" + listaGruas[44].estado.ToString(),
                            listaGruas[45].proximaLlegadaReparación.ToString() + "|" + listaGruas[45].estado.ToString(),
                            listaGruas[46].proximaLlegadaReparación.ToString() + "|" + listaGruas[46].estado.ToString(),
                            listaGruas[47].proximaLlegadaReparación.ToString() + "|" + listaGruas[47].estado.ToString(),
                            listaGruas[48].proximaLlegadaReparación.ToString() + "|" + listaGruas[48].estado.ToString(),
                            listaGruas[49].proximaLlegadaReparación.ToString() + "|" + listaGruas[49].estado.ToString(),
                            listaGruas[50].proximaLlegadaReparación.ToString() + "|" + listaGruas[50].estado.ToString(),
                            listaGruas[51].proximaLlegadaReparación.ToString() + "|" + listaGruas[51].estado.ToString(),
                            listaGruas[52].proximaLlegadaReparación.ToString() + "|" + listaGruas[52].estado.ToString(),
                            listaGruas[53].proximaLlegadaReparación.ToString() + "|" + listaGruas[53].estado.ToString(),
                            listaGruas[54].proximaLlegadaReparación.ToString() + "|" + listaGruas[54].estado.ToString(),
                            listaGruas[55].proximaLlegadaReparación.ToString() + "|" + listaGruas[55].estado.ToString(),
                            listaGruas[56].proximaLlegadaReparación.ToString() + "|" + listaGruas[56].estado.ToString(),
                            listaGruas[57].proximaLlegadaReparación.ToString() + "|" + listaGruas[57].estado.ToString(),
                            listaGruas[58].proximaLlegadaReparación.ToString() + "|" + listaGruas[58].estado.ToString(),
                            listaGruas[59].proximaLlegadaReparación.ToString() + "|" + listaGruas[59].estado.ToString(),
                            listaGruas[60].proximaLlegadaReparación.ToString() + "|" + listaGruas[60].estado.ToString(),
                            listaGruas[61].proximaLlegadaReparación.ToString() + "|" + listaGruas[61].estado.ToString(),
                            listaGruas[62].proximaLlegadaReparación.ToString() + "|" + listaGruas[62].estado.ToString(),
                            listaGruas[63].proximaLlegadaReparación.ToString() + "|" + listaGruas[63].estado.ToString(),
                            listaGruas[64].proximaLlegadaReparación.ToString() + "|" + listaGruas[64].estado.ToString(),
                            listaGruas[65].proximaLlegadaReparación.ToString() + "|" + listaGruas[65].estado.ToString(),
                            listaGruas[66].proximaLlegadaReparación.ToString() + "|" + listaGruas[66].estado.ToString(),
                            listaGruas[67].proximaLlegadaReparación.ToString() + "|" + listaGruas[67].estado.ToString(),
                            listaGruas[68].proximaLlegadaReparación.ToString() + "|" + listaGruas[68].estado.ToString(),
                            listaGruas[69].proximaLlegadaReparación.ToString() + "|" + listaGruas[69].estado.ToString(),
                            listaGruas[70].proximaLlegadaReparación.ToString() + "|" + listaGruas[70].estado.ToString(),
                            listaGruas[71].proximaLlegadaReparación.ToString() + "|" + listaGruas[71].estado.ToString(),
                            listaGruas[72].proximaLlegadaReparación.ToString() + "|" + listaGruas[72].estado.ToString(),
                            listaGruas[73].proximaLlegadaReparación.ToString() + "|" + listaGruas[73].estado.ToString(),
                            listaGruas[74].proximaLlegadaReparación.ToString() + "|" + listaGruas[74].estado.ToString(),
                            listaGruas[75].proximaLlegadaReparación.ToString() + "|" + listaGruas[75].estado.ToString(),
                            listaGruas[76].proximaLlegadaReparación.ToString() + "|" + listaGruas[76].estado.ToString(),
                            listaGruas[77].proximaLlegadaReparación.ToString() + "|" + listaGruas[77].estado.ToString(),
                            listaGruas[78].proximaLlegadaReparación.ToString() + "|" + listaGruas[78].estado.ToString(),
                            listaGruas[79].proximaLlegadaReparación.ToString() + "|" + listaGruas[79].estado.ToString(),
                            listaGruas[80].proximaLlegadaReparación.ToString() + "|" + listaGruas[80].estado.ToString(),
                            listaGruas[81].proximaLlegadaReparación.ToString() + "|" + listaGruas[81].estado.ToString(),
                            listaGruas[82].proximaLlegadaReparación.ToString() + "|" + listaGruas[82].estado.ToString(),
                            listaGruas[83].proximaLlegadaReparación.ToString() + "|" + listaGruas[83].estado.ToString(),
                            listaGruas[84].proximaLlegadaReparación.ToString() + "|" + listaGruas[84].estado.ToString(),
                            listaGruas[85].proximaLlegadaReparación.ToString() + "|" + listaGruas[85].estado.ToString(),
                            listaGruas[86].proximaLlegadaReparación.ToString() + "|" + listaGruas[86].estado.ToString(),
                            listaGruas[87].proximaLlegadaReparación.ToString() + "|" + listaGruas[87].estado.ToString(),
                            listaGruas[88].proximaLlegadaReparación.ToString() + "|" + listaGruas[88].estado.ToString(),
                            listaGruas[89].proximaLlegadaReparación.ToString() + "|" + listaGruas[89].estado.ToString(),
                            listaGruas[90].proximaLlegadaReparación.ToString() + "|" + listaGruas[90].estado.ToString(),
                            listaGruas[91].proximaLlegadaReparación.ToString() + "|" + listaGruas[91].estado.ToString(),
                            listaGruas[92].proximaLlegadaReparación.ToString() + "|" + listaGruas[92].estado.ToString(),
                            listaGruas[93].proximaLlegadaReparación.ToString() + "|" + listaGruas[93].estado.ToString(),
                            listaGruas[94].proximaLlegadaReparación.ToString() + "|" + listaGruas[94].estado.ToString(),
                            listaGruas[95].proximaLlegadaReparación.ToString() + "|" + listaGruas[95].estado.ToString(),
                            listaGruas[96].proximaLlegadaReparación.ToString() + "|" + listaGruas[96].estado.ToString(),
                            listaGruas[97].proximaLlegadaReparación.ToString() + "|" + listaGruas[97].estado.ToString(),
                            listaGruas[98].proximaLlegadaReparación.ToString() + "|" + listaGruas[98].estado.ToString(),
                            listaGruas[99].proximaLlegadaReparación.ToString() + "|" + listaGruas[99].estado.ToString(),
                            listaGruas[100].proximaLlegadaReparación.ToString() + "|" + listaGruas[100].estado.ToString(),
                            listaGruas[101].proximaLlegadaReparación.ToString() + "|" + listaGruas[101].estado.ToString(),
                            listaGruas[102].proximaLlegadaReparación.ToString() + "|" + listaGruas[102].estado.ToString(),
                            listaGruas[103].proximaLlegadaReparación.ToString() + "|" + listaGruas[103].estado.ToString(),
                            listaGruas[104].proximaLlegadaReparación.ToString() + "|" + listaGruas[104].estado.ToString(),
                            listaGruas[105].proximaLlegadaReparación.ToString() + "|" + listaGruas[105].estado.ToString(),
                            listaGruas[106].proximaLlegadaReparación.ToString() + "|" + listaGruas[106].estado.ToString(),
                            listaGruas[107].proximaLlegadaReparación.ToString() + "|" + listaGruas[107].estado.ToString(),
                            listaGruas[108].proximaLlegadaReparación.ToString() + "|" + listaGruas[108].estado.ToString(),
                            listaGruas[109].proximaLlegadaReparación.ToString() + "|" + listaGruas[109].estado.ToString(),
                            listaGruas[110].proximaLlegadaReparación.ToString() + "|" + listaGruas[110].estado.ToString(),
                            listaGruas[111].proximaLlegadaReparación.ToString() + "|" + listaGruas[111].estado.ToString(),
                            listaGruas[112].proximaLlegadaReparación.ToString() + "|" + listaGruas[112].estado.ToString(),
                            listaGruas[113].proximaLlegadaReparación.ToString() + "|" + listaGruas[113].estado.ToString(),
                            listaGruas[114].proximaLlegadaReparación.ToString() + "|" + listaGruas[114].estado.ToString(),
                            listaGruas[115].proximaLlegadaReparación.ToString() + "|" + listaGruas[115].estado.ToString(),
                            listaGruas[116].proximaLlegadaReparación.ToString() + "|" + listaGruas[116].estado.ToString(),
                            listaGruas[117].proximaLlegadaReparación.ToString() + "|" + listaGruas[117].estado.ToString(),
                            listaGruas[118].proximaLlegadaReparación.ToString() + "|" + listaGruas[118].estado.ToString(),
                            listaGruas[119].proximaLlegadaReparación.ToString() + "|" + listaGruas[119].estado.ToString(),




            };       
            dgvTabla.Rows.Add(fila2);

        }

        //dar posibilidad de ingresar ese 1 y 4, es decir los extremos de la distriubiocn uniforme
        public int calcularTiempoReparacion(double numeroRND1, int uniformeMinimo, int uniformeMaximo)
        {
            var tiempoReparacion =(int)Math.Truncate(uniformeMinimo + (numeroRND1 * (uniformeMaximo - uniformeMinimo + 1 )));
            return tiempoReparacion;
        }


        private void botonSimular_Click(object sender, EventArgs e)
        {
            txtMax.Enabled = false;
            txtMin.Enabled = false;
            txtMaxUniformeprimerLLegada.Enabled = false;
            txtMinUniformePrimerLLegada.Enabled = false;
            txtCantDiasReparacion.Enabled = false;

            //sacar esto despues
            var time = DateTime.Now;
            dgvTabla.Visible = false;
            dgvTabla.Rows.Clear();

            Int64 Iteraciones = 0;
            Int64 desde = 0;

            if (txtN.Text == "" || txtDesde.Text == "")
            {
                MessageBox.Show( "Ingrese un valor");
            }
            else
            {
                 Iteraciones = Convert.ToInt64(txtN.Text);
                 desde = Convert.ToInt64(txtDesde.Text);
            }


            var uniformeMinimo = Convert.ToInt32(txtMin.Text);

            var uniformeMaximo = Convert.ToInt32(txtMax.Text);

            var uniformeMinimoPrimerLlegada = Convert.ToInt32(txtMinUniformePrimerLLegada.Text);

            var uniformeMaximoPrimerLlegada = Convert.ToInt32(txtMaxUniformeprimerLLegada.Text);


            var cadaCuantoDiasReparacion = Convert.ToInt32(txtCantDiasReparacion.Text);

            // Validacion


            var registro = new Registro();
            registro.evento = "Inicializacion";
            registro.tiempoProxRotura = cadaCuantoDiasReparacion;


            // sacamos antes del for todas las proximas roturas y debemos mostrarlo
            
            var listaGruas = new List<Patrulla>();
            for (int i = 0; i < 120; i++)
            {
                listaGruas.Add(new Patrulla());
                //listaProximasLlgadas.Add(0);
            }

            var listaTaller = new List<Taller>();

            for (int i = 0; i < 8; i++)
            {
                var taller = new Taller();
                taller.numeroTaller = i;
                listaTaller.Add(taller);

            }
            
            List<Patrulla> colaGruasEsperando = new List<Patrulla>();
            Random random1 = new Random();

            // saco las primeras roturas de las patrullas
            for (var i = 0; i < listaGruas.Count; i++)
            {
                double numeroRND = random1.NextDouble();

                listaGruas[i].numeroPatrulla = i;
                
                listaGruas[i].RndPrimerRotura = Math.Truncate(numeroRND * 1000) / 1000; ;
                listaGruas[i].tiempoProximaRotura = devolverTiempoPrimeraRotura(numeroRND,uniformeMinimoPrimerLlegada,uniformeMaximoPrimerLlegada);
                listaGruas[i].proximaLlegadaReparación = registro.reloj + listaGruas[i].tiempoProximaRotura;
                

            }

            registro.cantidadGruasDisponibles = 120;

            //muestro la primera tabla
            mostrarTablaInicio(registro, listaTaller, listaGruas);
            //aca arranca las iteraciones

            var maximoReparacionPatrulla = 0;



            // INICIO ITERACIONES *************************************************************************************
            for (var j = 0; j < Iteraciones; j++)
            {
                var minimoLLegadaPatrulla = 9999999;
                var PatrullaProximaLlegada = new Patrulla(); 
                
                
                for (var i = 0; i < 120; i++)
                {
                    if (minimoLLegadaPatrulla > listaGruas[i].proximaLlegadaReparación && listaGruas[i].estado == "D")
                    {
                        minimoLLegadaPatrulla = listaGruas[i].proximaLlegadaReparación;
                        PatrullaProximaLlegada = listaGruas[i];
                    }
                    if(listaGruas[i].CantidadReparaciones > maximoReparacionPatrulla)
                    {
                        maximoReparacionPatrulla = listaGruas[i].CantidadReparaciones;
                        registro.MaximoReparacionPorGrua = maximoReparacionPatrulla;
                    }
                }

                var minimoFinReparacion = 999999999;
                var ban = false;
                for (var i = 0; i < 8; i++)
                {
                    if (listaTaller[i].estado == "Rep")
                    {
                        if (minimoFinReparacion > listaTaller[i].finReparacion)
                        {
                            minimoFinReparacion = listaTaller[i].finReparacion;
                        }
                        ban = true;
                    }
                }
                



                //pregunto cual es el proximo evento, lo del 99999999 es por el caso que todas las patrullas esten en cola ..
                if(minimoLLegadaPatrulla < minimoFinReparacion || ban == false && minimoLLegadaPatrulla != 9999999)
                {
                    registro.reloj = minimoLLegadaPatrulla;
                    registro.evento = "Lleg Patrulla " + (PatrullaProximaLlegada.numeroPatrulla + 1).ToString();

                    bool hayDisponibleTaller = PatrullaProximaLlegada.hayDisponibilidadTaller(listaTaller);

                    if (hayDisponibleTaller)
                    {
                        //traigo el taller libre
                        var tallerLibre = traerTallerLibre(listaTaller);
                        //cambio el estado del taller y la grua 
                        tallerLibre.Reparando(tallerLibre);

                        // defino el fin ocio y calculo el tiempo que estuve libre y lo acumulo
                        tallerLibre.FinOcio = registro.reloj;
                        registro.AcumuladortiempoOciosoCapacidades += tallerLibre.FinOcio - tallerLibre.InicioOcio;



                        // inicio atencion

                        PatrullaProximaLlegada.InicioReparacion = registro.reloj;
                        //cambio de estado
                        PatrullaProximaLlegada.Repararndo(PatrullaProximaLlegada);

                        //asigno la grua al taller
                        tallerLibre.patrulla = PatrullaProximaLlegada;

                        double numeroRND1 = random1.NextDouble();
                        //calculo el tiempo de reparacion y fin de reparacion
                        tallerLibre.tiempoReparacion = calcularTiempoReparacion(numeroRND1, uniformeMinimo, uniformeMaximo);
                        registro.tiempoReparacion = tallerLibre.tiempoReparacion;
                        registro.RndTiempoReparacion = Math.Truncate(numeroRND1 * 1000) / 1000;
                        tallerLibre.finReparacion = registro.reloj + tallerLibre.tiempoReparacion;
                        //actualizo el taller en la lista
                        listaTaller[tallerLibre.numeroTaller] = tallerLibre;

                        //actualizo evento nombre
                        registro.evento += " y va a T(" + (tallerLibre.numeroTaller + 1).ToString() + ")";
                    }
                    else
                    {
                        PatrullaProximaLlegada.InicioReparacion = registro.reloj;
                        colaGruasEsperando.Add(PatrullaProximaLlegada);
                        PatrullaProximaLlegada.EsperarEnCola(PatrullaProximaLlegada);
                        registro.evento += " A cola";
                        //registro.cantidadGruasCola = colaGruasEsperando.Count();
                    }
                }

                //FIN REPARACION
                else
                {

                    var taller =new Taller();
                    for (var i = 0; i < 8; i++)
                    {
                        if (listaTaller[i].estado == "Rep" && listaTaller[i].finReparacion == minimoFinReparacion)
                        {
                            taller = listaTaller[i];                        
                        }
                    }

                    registro.reloj = minimoFinReparacion;
                    registro.evento = "Fin R taller " + (taller.numeroTaller + 1).ToString() +" (P" + (taller.patrulla.numeroPatrulla + 1).ToString() + ")";
                    
                    //ACTUALIZO LA PROXIMA LLEGADA A REPARACION DE LA PATRULLA ..........................
                    taller.patrulla.proximaLlegadaReparación = registro.reloj + cadaCuantoDiasReparacion;

                    //actualizo el estado de la grua a trabajando o disponible y sumo una reparacion a la grua
                    taller.patrulla.Trabajando(taller.patrulla);
                    taller.patrulla.CantidadReparaciones += 1;



                    //saco el fin reparacion grua para poder calcular el acumulador tiempos de reparacion
                    taller.patrulla.FinReparacion = registro.reloj;

                    //metrica para ver el maximo tiempo de reparacion *************
                    var maximo = taller.patrulla.FinReparacion - taller.patrulla.InicioReparacion;

                    if(maximo > registro.tiempoMaximoReparacion) { 
                        registro.tiempoMaximoReparacion = maximo;
                    }
                    //*****************************
                    //metricas promedio de tiempo en reparar una grua ****************************
                    registro.ContadorPatrullasReparadas += 1;
                    registro.AcumuladorTiemposReparacion += taller.patrulla.FinReparacion - taller.patrulla.InicioReparacion;

                    var promedio = ((double)registro.AcumuladorTiemposReparacion / (double)registro.ContadorPatrullasReparadas);
                   
                    registro.PromedioTiempoReparacion = Math.Truncate(promedio * 1000) / 1000;
                    //********************************************************

                    
                    //hace falta actualizar la lista
                    listaGruas[taller.patrulla.numeroPatrulla] = taller.patrulla; 

                    if(colaGruasEsperando.Count == 0)
                    {
                        taller.LiberarTaller(taller);
                        taller.InicioOcio = registro.reloj;
                        listaTaller[taller.numeroTaller] = taller;
                    }
                    else
                    {
                        var PatrullaSaleCola = colaGruasEsperando[0];


                        registro.cantidadPatrullasCola = colaGruasEsperando.Count();
                        taller.patrulla = PatrullaSaleCola;

                        //estado a reparar el taller
                        taller.Reparando(taller);
                        taller.patrulla.Repararndo(taller.patrulla);

                        //taller.grua.InicioReparacion = registro.reloj; aca no va porque ya ingreso a reparacion,estaba esperando
                        double numeroRND2 = random1.NextDouble();
                        //calculo el tiempo de reparacion y fin de reparacion
                        taller.tiempoReparacion = calcularTiempoReparacion(numeroRND2,uniformeMinimo,uniformeMaximo);

                        registro.tiempoReparacion = taller.tiempoReparacion;
                        registro.RndTiempoReparacion = Math.Truncate(numeroRND2 * 1000) / 1000;

                        taller.finReparacion = registro.reloj + taller.tiempoReparacion;

                        registro.evento += " Entra a Rep P " + (taller.patrulla.numeroPatrulla + 1).ToString(); 
                        //actualizo el taller en la lista

                        //lo saco de la cola
                        colaGruasEsperando.Remove(colaGruasEsperando[0]);

                    }


                }
                //cantidad patrullas en cola
                registro.cantidadPatrullasCola = colaGruasEsperando.Count();

                // 5) metrica cantidad maxima en cola **********
                if (registro.cantidadMaximaEnCola < registro.cantidadPatrullasCola)
                {
                    registro.cantidadMaximaEnCola = registro.cantidadPatrullasCola;
                }
                //*********************

                // 1) metrica cantidad y promedio de gruas disponibles *************
                int cantidadPatrullasDisponibles = 0;
                for (var i = 0; i < 120; i++)
                {
                    if (listaGruas[i].estado == "D")
                    {
                        cantidadPatrullasDisponibles++;
                    }
                }
                registro.cantidadGruasDisponibles = cantidadPatrullasDisponibles;
                var promedioGruaDispo = (double)cantidadPatrullasDisponibles / 120;
                registro.promedioGruasDisponibles = Math.Truncate(promedioGruaDispo * 1000) / 1000;

                //***********************************

                //metrica 4) PROMEDIO TIEMPO OCIOSO

                var DiasTotalSimulacion = registro.reloj - 0;

                var promedioDiasOciososs = (double)registro.AcumuladortiempoOciosoCapacidades / (double)DiasTotalSimulacion;
                registro.PromedioDiasOciosos = Math.Truncate(promedioDiasOciososs * 100000) / 100000;




                if ( j >= desde &&  j <= (desde + 400)  )
                {
                    mostrarTabla(registro, listaTaller, listaGruas);
                    
                }


            }




            for (var i = 0; i < 8; i++)
            {
                if (listaTaller[i].estado == "L")
                {
                    listaTaller[i].FinOcio = registro.reloj;
                    registro.AcumuladortiempoOciosoCapacidades += listaTaller[i].FinOcio - listaTaller[i].InicioOcio;

                }
            }




            mostrarTabla(registro, listaTaller, listaGruas);
            
            
            var diferenciaTiempo = DateTime.Now - time;
            //sacar esto despues
            //label2.Text = diferenciaTiempo.ToString();

            dgvTabla.EnableHeadersVisualStyles = false;


            dgvTabla.Rows[dgvTabla.RowCount - 1].Cells[23].Style.BackColor = Color.Red;
            dgvTabla.Rows[dgvTabla.RowCount - 1].Cells[24].Style.BackColor = Color.Red;
            dgvTabla.Rows[dgvTabla.RowCount - 1].Cells[25].Style.BackColor = Color.Red;
            dgvTabla.Rows[dgvTabla.RowCount - 1].Cells[27].Style.BackColor = Color.Red;
            dgvTabla.Rows[dgvTabla.RowCount - 1].Cells[28].Style.BackColor = Color.Red;

            

            dgvTabla.Columns[23].HeaderCell.Style.BackColor = Color.Red;
            dgvTabla.Columns[24].HeaderCell.Style.BackColor = Color.Red;
            dgvTabla.Columns[25].HeaderCell.Style.BackColor = Color.Red;
            dgvTabla.Columns[27].HeaderCell.Style.BackColor = Color.Red;
            dgvTabla.Columns[28].HeaderCell.Style.BackColor = Color.Red;

            labelNro1.Text = "1)Promedio patrullas disponibles: " + registro.promedioGruasDisponibles.ToString(); 
            labelNro2.Text ="2)Dias máximos de reparación de una patrulla: " + registro.tiempoMaximoReparacion.ToString();
            labelNro3.Text = "3)Promedio de días de reparacion patrulla: " + registro.PromedioTiempoReparacion.ToString();   
            labelNro4.Text = "4)Promedio y acumulador tiempo ocioso del taller: " + registro.PromedioDiasOciosos.ToString() +" | "+registro.AcumuladortiempoOciosoCapacidades.ToString();
            labelNro5.Text = "5)Cantidad maxima patrullas en cola: " + registro.cantidadMaximaEnCola.ToString();
            if (txtN.Text != "" && txtDesde.Text != "")
            {
                dgvTabla.Visible = true;
            }
            
        }











        public void mostrarTablaInicio(Registro registro, List<Taller> listaTaller, List<Patrulla> listaGruas)
        {
            var fila2 = new string[]
            {
                            registro.reloj.ToString(),
                            registro.evento.ToString(),
                            registro.RndTiempoReparacion.ToString(),
                            registro.tiempoReparacion.ToString(),


                            listaTaller[0].finReparacion.ToString(),
                            listaTaller[1].finReparacion.ToString(),
                            listaTaller[2].finReparacion.ToString(),
                            listaTaller[3].finReparacion.ToString(),
                            listaTaller[4].finReparacion.ToString(),
                            listaTaller[5].finReparacion.ToString(),
                            listaTaller[6].finReparacion.ToString(),
                            listaTaller[7].finReparacion.ToString(),


                            listaTaller[0].estado == "Rep" ? listaTaller[0].estado.ToString()+"("+(listaTaller[0].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L"+" |"+ listaTaller[0].InicioOcio.ToString(),
                            listaTaller[1].estado == "Rep" ? listaTaller[1].estado.ToString()+"("+(listaTaller[1].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[1].InicioOcio.ToString(),
                            listaTaller[2].estado == "Rep" ? listaTaller[2].estado.ToString()+"("+(listaTaller[2].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L"+" |"+ listaTaller[2].InicioOcio.ToString(),
                            listaTaller[3].estado == "Rep" ? listaTaller[3].estado.ToString()+"("+(listaTaller[3].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[3].InicioOcio.ToString(),
                            listaTaller[4].estado == "Rep" ? listaTaller[4].estado.ToString()+"("+(listaTaller[4].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[4].InicioOcio.ToString(),
                            listaTaller[5].estado == "Rep" ? listaTaller[5].estado.ToString()+"("+(listaTaller[5].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[5].InicioOcio.ToString(),
                            listaTaller[6].estado == "Rep" ? listaTaller[6].estado.ToString()+"("+(listaTaller[6].patrulla.numeroPatrulla + 1).ToString()+ ")" : "L" +" |"+ listaTaller[6].InicioOcio.ToString(),
                            listaTaller[7].estado == "Rep" ? listaTaller[7].estado.ToString()+"("+(listaTaller[7].patrulla.numeroPatrulla+ 1).ToString()+ ")" : "L" +" |"+ listaTaller[7].InicioOcio.ToString(),
                            registro.cantidadPatrullasCola.ToString(),
                            registro.AcumuladorTiemposReparacion.ToString(),
                            registro.ContadorPatrullasReparadas.ToString(),
                            registro.PromedioTiempoReparacion.ToString(),
                            registro.tiempoMaximoReparacion.ToString(),
                            registro.cantidadMaximaEnCola.ToString(),
                            registro.cantidadGruasDisponibles.ToString(),
                            registro.promedioGruasDisponibles.ToString(),
                            //registro.tiempoOciosoCapacidades.ToString(),
                            registro.PromedioDiasOciosos.ToString(),
                            registro.AcumuladortiempoOciosoCapacidades.ToString(),
                            registro.MaximoReparacionPorGrua.ToString(),
                            registro.tiempoProxRotura.ToString(),
                            listaGruas[0].RndPrimerRotura.ToString() + "|" + listaGruas[0].tiempoProximaRotura + "|"  + listaGruas[0].proximaLlegadaReparación.ToString() + "-" + listaGruas[0].estado.ToString(),
                            listaGruas[1].RndPrimerRotura.ToString() + "|" + listaGruas[1].tiempoProximaRotura + "|" +listaGruas[1].proximaLlegadaReparación.ToString() + "-" + listaGruas[1].estado.ToString(),
                            listaGruas[2].RndPrimerRotura.ToString() + "|" + listaGruas[2].tiempoProximaRotura + "|"  +listaGruas[2].proximaLlegadaReparación.ToString() + "-" + listaGruas[2].estado.ToString(),
                            listaGruas[3].RndPrimerRotura.ToString() + "|" + listaGruas[3].tiempoProximaRotura + "|"  +listaGruas[3].proximaLlegadaReparación.ToString() + "-" + listaGruas[3].estado.ToString(),
                            listaGruas[4].RndPrimerRotura.ToString() + "|" + listaGruas[4].tiempoProximaRotura + "|"  +listaGruas[4].proximaLlegadaReparación.ToString() + "-" + listaGruas[4].estado.ToString(),
                            listaGruas[5].RndPrimerRotura.ToString() +"|" + listaGruas[5].tiempoProximaRotura + "|"  +listaGruas[5].proximaLlegadaReparación.ToString() + "-" + listaGruas[5].estado.ToString(),
                            listaGruas[6].RndPrimerRotura.ToString() + "|" + listaGruas[6].tiempoProximaRotura + "|"  +listaGruas[6].proximaLlegadaReparación.ToString() + "-" + listaGruas[6].estado.ToString(),
                            listaGruas[7].RndPrimerRotura.ToString() + "|" + listaGruas[7].tiempoProximaRotura + "|"  +listaGruas[7].proximaLlegadaReparación.ToString() + "-" + listaGruas[7].estado.ToString(),
                            listaGruas[8].RndPrimerRotura.ToString() + "|" + listaGruas[8].tiempoProximaRotura + "|"  +listaGruas[8].proximaLlegadaReparación.ToString() + "-" + listaGruas[8].estado.ToString(),
                            listaGruas[9].RndPrimerRotura.ToString() + "|" + listaGruas[9].tiempoProximaRotura + "|"  +listaGruas[9].proximaLlegadaReparación.ToString() + "-" + listaGruas[9].estado.ToString(),
                            listaGruas[10].RndPrimerRotura.ToString() + "|" + listaGruas[10].tiempoProximaRotura + "|"  +listaGruas[10].proximaLlegadaReparación.ToString() + "-" + listaGruas[10].estado.ToString(),
                            listaGruas[11].RndPrimerRotura.ToString() + "|" + listaGruas[11].tiempoProximaRotura + "|"  +listaGruas[11].proximaLlegadaReparación.ToString() + "-" + listaGruas[11].estado.ToString(),
                            listaGruas[12].RndPrimerRotura.ToString() + "|" + listaGruas[12].tiempoProximaRotura + "|"  +listaGruas[12].proximaLlegadaReparación.ToString() + "-" + listaGruas[12].estado.ToString(),
                            listaGruas[13].RndPrimerRotura.ToString() +"|" + listaGruas[13].tiempoProximaRotura + "|"  +listaGruas[13].proximaLlegadaReparación.ToString() + "-" + listaGruas[13].estado.ToString(),
                            listaGruas[14].RndPrimerRotura.ToString() + "|" + listaGruas[14].tiempoProximaRotura + "|"  +listaGruas[14].proximaLlegadaReparación.ToString() + "-" + listaGruas[14].estado.ToString(),
                            listaGruas[15].RndPrimerRotura.ToString() + "|" + listaGruas[15].tiempoProximaRotura + "|"  +listaGruas[15].proximaLlegadaReparación.ToString() + "-" + listaGruas[15].estado.ToString(),
                            listaGruas[16].RndPrimerRotura.ToString() + "|" + listaGruas[16].tiempoProximaRotura + "|"  +listaGruas[16].proximaLlegadaReparación.ToString() + "-" + listaGruas[16].estado.ToString(),
                            listaGruas[17].RndPrimerRotura.ToString() + "|" + listaGruas[17].tiempoProximaRotura + "|"  +listaGruas[17].proximaLlegadaReparación.ToString() + "-" + listaGruas[17].estado.ToString(),
                            listaGruas[18].RndPrimerRotura.ToString() + "|" + listaGruas[18].tiempoProximaRotura + "|"  +listaGruas[18].proximaLlegadaReparación.ToString() + "-" + listaGruas[18].estado.ToString(),
                            listaGruas[19].RndPrimerRotura.ToString() + "|" + listaGruas[19].tiempoProximaRotura + "|"  +listaGruas[19].proximaLlegadaReparación.ToString() + "-" + listaGruas[19].estado.ToString(),
                            listaGruas[20].RndPrimerRotura.ToString() + "|" + listaGruas[20].tiempoProximaRotura + "|"  +listaGruas[20].proximaLlegadaReparación.ToString() + "-" + listaGruas[20].estado.ToString(),
                            listaGruas[21].RndPrimerRotura.ToString() + "|" + listaGruas[21].tiempoProximaRotura + "|"  +listaGruas[21].proximaLlegadaReparación.ToString() + "-" + listaGruas[21].estado.ToString(),
                            listaGruas[22].RndPrimerRotura.ToString() + "|" + listaGruas[22].tiempoProximaRotura + "|"  +listaGruas[22].proximaLlegadaReparación.ToString() + "-" + listaGruas[22].estado.ToString(),
                            listaGruas[23].RndPrimerRotura.ToString() + "|" + listaGruas[23].tiempoProximaRotura + "|"  +listaGruas[23].proximaLlegadaReparación.ToString() + "-" + listaGruas[23].estado.ToString(),
                            listaGruas[24].RndPrimerRotura.ToString() + "|" + listaGruas[24].tiempoProximaRotura + "|"  +listaGruas[24].proximaLlegadaReparación.ToString() + "-" + listaGruas[24].estado.ToString(),
                            listaGruas[25].RndPrimerRotura.ToString() + "|" + listaGruas[25].tiempoProximaRotura + "|"  +listaGruas[25].proximaLlegadaReparación.ToString() + "-" + listaGruas[25].estado.ToString(),
                            listaGruas[26].RndPrimerRotura.ToString() + "|" + listaGruas[26].tiempoProximaRotura + "|"  +listaGruas[26].proximaLlegadaReparación.ToString() + "-" + listaGruas[26].estado.ToString(),
                            listaGruas[27].RndPrimerRotura.ToString() + "|" + listaGruas[27].tiempoProximaRotura + "|"  +listaGruas[27].proximaLlegadaReparación.ToString() + "-" + listaGruas[27].estado.ToString(),
                            listaGruas[28].RndPrimerRotura.ToString() + "|" + listaGruas[28].tiempoProximaRotura + "|"  +listaGruas[28].proximaLlegadaReparación.ToString() + "-" + listaGruas[28].estado.ToString(),
                            listaGruas[29].RndPrimerRotura.ToString() + "|" + listaGruas[29].tiempoProximaRotura + "|"  +listaGruas[29].proximaLlegadaReparación.ToString() + "-" + listaGruas[29].estado.ToString(),
                            listaGruas[30].RndPrimerRotura.ToString() + "|" + listaGruas[30].tiempoProximaRotura + "|"  +listaGruas[30].proximaLlegadaReparación.ToString() + "-" + listaGruas[30].estado.ToString(),
                            listaGruas[31].RndPrimerRotura.ToString() + "|" + listaGruas[31].tiempoProximaRotura + "|"  +listaGruas[31].proximaLlegadaReparación.ToString() + "-" + listaGruas[31].estado.ToString(),
                            listaGruas[32].RndPrimerRotura.ToString() + "|" + listaGruas[32].tiempoProximaRotura + "|"  +listaGruas[32].proximaLlegadaReparación.ToString() + "-" + listaGruas[32].estado.ToString(),
                            listaGruas[33].RndPrimerRotura.ToString() + "|" + listaGruas[33].tiempoProximaRotura + "|"  +listaGruas[33].proximaLlegadaReparación.ToString() + "-" + listaGruas[33].estado.ToString(),
                            listaGruas[34].RndPrimerRotura.ToString() + "|" + listaGruas[34].tiempoProximaRotura + "|"  +listaGruas[34].proximaLlegadaReparación.ToString() + "-" + listaGruas[34].estado.ToString(),
                            listaGruas[35].RndPrimerRotura.ToString() + "|" + listaGruas[35].tiempoProximaRotura + "|"  +listaGruas[35].proximaLlegadaReparación.ToString() + "-" + listaGruas[35].estado.ToString(),
                            listaGruas[36].RndPrimerRotura.ToString() + "|" + listaGruas[36].tiempoProximaRotura + "|"  +listaGruas[36].proximaLlegadaReparación.ToString() + "-" + listaGruas[36].estado.ToString(),
                            listaGruas[37].RndPrimerRotura.ToString() + "|" + listaGruas[37].tiempoProximaRotura + "|"  +listaGruas[37].proximaLlegadaReparación.ToString() + "-" + listaGruas[37].estado.ToString(),
                            listaGruas[38].RndPrimerRotura.ToString() + "|" + listaGruas[38].tiempoProximaRotura + "|"  +listaGruas[38].proximaLlegadaReparación.ToString() + "-" + listaGruas[38].estado.ToString(),
                            listaGruas[39].RndPrimerRotura.ToString() + "|" + listaGruas[39].tiempoProximaRotura + "|"  +listaGruas[39].proximaLlegadaReparación.ToString() + "-" + listaGruas[39].estado.ToString(),
                            listaGruas[40].RndPrimerRotura.ToString() + "|" + listaGruas[40].tiempoProximaRotura + "|"  +listaGruas[40].proximaLlegadaReparación.ToString() + "-" + listaGruas[40].estado.ToString(),
                            listaGruas[41].RndPrimerRotura.ToString() + "|" + listaGruas[41].tiempoProximaRotura + "|"  +listaGruas[41].proximaLlegadaReparación.ToString() + "-" + listaGruas[41].estado.ToString(),
                            listaGruas[42].RndPrimerRotura.ToString() + "|" + listaGruas[42].tiempoProximaRotura + "|"  +listaGruas[42].proximaLlegadaReparación.ToString() + "-" + listaGruas[42].estado.ToString(),
                            listaGruas[43].RndPrimerRotura.ToString() + "|" + listaGruas[43].tiempoProximaRotura + "|"  +listaGruas[43].proximaLlegadaReparación.ToString() + "-" + listaGruas[43].estado.ToString(),
                            listaGruas[44].RndPrimerRotura.ToString() + "|" + listaGruas[44].tiempoProximaRotura + "|"  +listaGruas[44].proximaLlegadaReparación.ToString() + "-" + listaGruas[44].estado.ToString(),
                            listaGruas[45].RndPrimerRotura.ToString() + "|" + listaGruas[45].tiempoProximaRotura + "|"  +listaGruas[45].proximaLlegadaReparación.ToString() + "-" + listaGruas[45].estado.ToString(),
                            listaGruas[46].RndPrimerRotura.ToString() +"|" + listaGruas[46].tiempoProximaRotura + "|"  +listaGruas[46].proximaLlegadaReparación.ToString() + "-" + listaGruas[46].estado.ToString(),
                            listaGruas[47].RndPrimerRotura.ToString() + "|" + listaGruas[47].tiempoProximaRotura + "|"  +listaGruas[47].proximaLlegadaReparación.ToString() + "-" + listaGruas[47].estado.ToString(),
                            listaGruas[48].RndPrimerRotura.ToString() + "|" + listaGruas[48].tiempoProximaRotura + "|"  +listaGruas[48].proximaLlegadaReparación.ToString() + "-" + listaGruas[48].estado.ToString(),
                            listaGruas[49].RndPrimerRotura.ToString() + "|" + listaGruas[49].tiempoProximaRotura + "|"  +listaGruas[49].proximaLlegadaReparación.ToString() + "-" + listaGruas[49].estado.ToString(),
                            listaGruas[50].RndPrimerRotura.ToString() + "|" + listaGruas[50].tiempoProximaRotura + "|"  +listaGruas[50].proximaLlegadaReparación.ToString() + "-" + listaGruas[50].estado.ToString(),
                            listaGruas[51].RndPrimerRotura.ToString() + "|" + listaGruas[51].tiempoProximaRotura + "|"  +listaGruas[51].proximaLlegadaReparación.ToString() + "-" + listaGruas[51].estado.ToString(),
                            listaGruas[52].RndPrimerRotura.ToString() + "|" + listaGruas[52].tiempoProximaRotura + "|"  +listaGruas[52].proximaLlegadaReparación.ToString() + "-" + listaGruas[52].estado.ToString(),
                            listaGruas[53].RndPrimerRotura.ToString() + "|" + listaGruas[53].tiempoProximaRotura + "|"  +listaGruas[53].proximaLlegadaReparación.ToString() + "-" + listaGruas[53].estado.ToString(),
                            listaGruas[54].RndPrimerRotura.ToString() + "|" + listaGruas[54].tiempoProximaRotura + "|"  +listaGruas[54].proximaLlegadaReparación.ToString() + "-" + listaGruas[54].estado.ToString(),
                            listaGruas[55].RndPrimerRotura.ToString() + "|" + listaGruas[55].tiempoProximaRotura + "|"  +listaGruas[55].proximaLlegadaReparación.ToString() + "-" + listaGruas[55].estado.ToString(),
                            listaGruas[56].RndPrimerRotura.ToString() + "|" + listaGruas[56].tiempoProximaRotura + "|"  +listaGruas[56].proximaLlegadaReparación.ToString() + "-" + listaGruas[56].estado.ToString(),
                            listaGruas[57].RndPrimerRotura.ToString() + "|" + listaGruas[57].tiempoProximaRotura + "|"  +listaGruas[57].proximaLlegadaReparación.ToString() + "-" + listaGruas[57].estado.ToString(),
                            listaGruas[58].RndPrimerRotura.ToString() + "|" + listaGruas[58].tiempoProximaRotura + "|"  +listaGruas[58].proximaLlegadaReparación.ToString() + "-" + listaGruas[58].estado.ToString(),
                            listaGruas[59].RndPrimerRotura.ToString() + "|" + listaGruas[59].tiempoProximaRotura + "|"  +listaGruas[59].proximaLlegadaReparación.ToString() + "-" + listaGruas[59].estado.ToString(),
                            listaGruas[60].RndPrimerRotura.ToString() + "|" + listaGruas[60].tiempoProximaRotura + "|"  +listaGruas[60].proximaLlegadaReparación.ToString() + "-" + listaGruas[60].estado.ToString(),
                            listaGruas[61].RndPrimerRotura.ToString() + "|" + listaGruas[61].tiempoProximaRotura + "|" +listaGruas[61].proximaLlegadaReparación.ToString() + "-" + listaGruas[61].estado.ToString(),
                            listaGruas[62].RndPrimerRotura.ToString() + "|" + listaGruas[62].tiempoProximaRotura + "|" +listaGruas[62].proximaLlegadaReparación.ToString() + "-" + listaGruas[62].estado.ToString(),
                            listaGruas[63].RndPrimerRotura.ToString() + "|" + listaGruas[63].tiempoProximaRotura + "|" +listaGruas[63].proximaLlegadaReparación.ToString() + "-" + listaGruas[63].estado.ToString(),
                            listaGruas[64].RndPrimerRotura.ToString() + "|" + listaGruas[64].tiempoProximaRotura + "|" +listaGruas[64].proximaLlegadaReparación.ToString() + "-" + listaGruas[64].estado.ToString(),
                            listaGruas[65].RndPrimerRotura.ToString() + "|" + listaGruas[65].tiempoProximaRotura + "|" +listaGruas[65].proximaLlegadaReparación.ToString() + "-" + listaGruas[65].estado.ToString(),
                            listaGruas[66].RndPrimerRotura.ToString() + "|" + listaGruas[66].tiempoProximaRotura + "|" +listaGruas[66].proximaLlegadaReparación.ToString() + "-" + listaGruas[66].estado.ToString(),
                            listaGruas[67].RndPrimerRotura.ToString() + "|" + listaGruas[67].tiempoProximaRotura + "|" +listaGruas[67].proximaLlegadaReparación.ToString() + "-" + listaGruas[67].estado.ToString(),
                            listaGruas[68].RndPrimerRotura.ToString() + "|" + listaGruas[68].tiempoProximaRotura + "|" +listaGruas[68].proximaLlegadaReparación.ToString() + "-" + listaGruas[68].estado.ToString(),
                            listaGruas[69].RndPrimerRotura.ToString() + "|" + listaGruas[69].tiempoProximaRotura + "|" +listaGruas[69].proximaLlegadaReparación.ToString() + "-" + listaGruas[69].estado.ToString(),
                            listaGruas[70].RndPrimerRotura.ToString() + "|" + listaGruas[70].tiempoProximaRotura + "|" +listaGruas[70].proximaLlegadaReparación.ToString() + "-" + listaGruas[70].estado.ToString(),
                            listaGruas[71].RndPrimerRotura.ToString() + "|" + listaGruas[71].tiempoProximaRotura + "|" +listaGruas[71].proximaLlegadaReparación.ToString() + "-" + listaGruas[71].estado.ToString(),
                            listaGruas[72].RndPrimerRotura.ToString() + "|" + listaGruas[72].tiempoProximaRotura + "|" +listaGruas[72].proximaLlegadaReparación.ToString() + "-" + listaGruas[72].estado.ToString(),
                            listaGruas[73].RndPrimerRotura.ToString() + "|" + listaGruas[73].tiempoProximaRotura + "|" +listaGruas[73].proximaLlegadaReparación.ToString() + "-" + listaGruas[73].estado.ToString(),
                            listaGruas[74].RndPrimerRotura.ToString() + "|" + listaGruas[74].tiempoProximaRotura + "|" +listaGruas[74].proximaLlegadaReparación.ToString() + "-" + listaGruas[74].estado.ToString(),
                            listaGruas[75].RndPrimerRotura.ToString() + "|" + listaGruas[75].tiempoProximaRotura + "|" +listaGruas[75].proximaLlegadaReparación.ToString() + "-" + listaGruas[75].estado.ToString(),
                            listaGruas[76].RndPrimerRotura.ToString() + "|" + listaGruas[76].tiempoProximaRotura + "|" +listaGruas[76].proximaLlegadaReparación.ToString() + "-" + listaGruas[76].estado.ToString(),
                            listaGruas[77].RndPrimerRotura.ToString() + "|" + listaGruas[77].tiempoProximaRotura + "|" +listaGruas[77].proximaLlegadaReparación.ToString() + "-" + listaGruas[77].estado.ToString(),
                            listaGruas[78].RndPrimerRotura.ToString() + "|" + listaGruas[78].tiempoProximaRotura + "|" +listaGruas[78].proximaLlegadaReparación.ToString() + "-" + listaGruas[78].estado.ToString(),
                            listaGruas[79].RndPrimerRotura.ToString() + "|" + listaGruas[79].tiempoProximaRotura + "|" +listaGruas[79].proximaLlegadaReparación.ToString() + "-" + listaGruas[79].estado.ToString(),
                            listaGruas[80].RndPrimerRotura.ToString() + "|" + listaGruas[80].tiempoProximaRotura + "|" +listaGruas[80].proximaLlegadaReparación.ToString() + "-" + listaGruas[80].estado.ToString(),
                            listaGruas[81].RndPrimerRotura.ToString() + "|" + listaGruas[81].tiempoProximaRotura + "|" +listaGruas[81].proximaLlegadaReparación.ToString() + "-" + listaGruas[81].estado.ToString(),
                            listaGruas[82].RndPrimerRotura.ToString() + "|" + listaGruas[82].tiempoProximaRotura + "|" +listaGruas[82].proximaLlegadaReparación.ToString() + "-" + listaGruas[82].estado.ToString(),
                            listaGruas[83].RndPrimerRotura.ToString() + "|" + listaGruas[83].tiempoProximaRotura + "|" +listaGruas[83].proximaLlegadaReparación.ToString() + "-" + listaGruas[83].estado.ToString(),
                            listaGruas[84].RndPrimerRotura.ToString() + "|" + listaGruas[84].tiempoProximaRotura + "|" +listaGruas[84].proximaLlegadaReparación.ToString() + "-" + listaGruas[84].estado.ToString(),
                            listaGruas[85].RndPrimerRotura.ToString() + "|" + listaGruas[85].tiempoProximaRotura + "|" +listaGruas[85].proximaLlegadaReparación.ToString() + "-" + listaGruas[85].estado.ToString(),
                            listaGruas[86].RndPrimerRotura.ToString() + "|" + listaGruas[86].tiempoProximaRotura + "|" +listaGruas[86].proximaLlegadaReparación.ToString() + "-" + listaGruas[86].estado.ToString(),
                            listaGruas[87].RndPrimerRotura.ToString() + "|" + listaGruas[87].tiempoProximaRotura + "|" +listaGruas[87].proximaLlegadaReparación.ToString() + "-" + listaGruas[87].estado.ToString(),
                            listaGruas[88].RndPrimerRotura.ToString() + "|" + listaGruas[88].tiempoProximaRotura + "|" +listaGruas[88].proximaLlegadaReparación.ToString() + "-" + listaGruas[88].estado.ToString(),
                            listaGruas[89].RndPrimerRotura.ToString() + "|" + listaGruas[89].tiempoProximaRotura + "|" +listaGruas[89].proximaLlegadaReparación.ToString() + "-" + listaGruas[89].estado.ToString(),
                            listaGruas[90].RndPrimerRotura.ToString() + "|" + listaGruas[90].tiempoProximaRotura + "|" +listaGruas[90].proximaLlegadaReparación.ToString() + "-" + listaGruas[90].estado.ToString(),
                            listaGruas[91].RndPrimerRotura.ToString() + "|" + listaGruas[91].tiempoProximaRotura + "|" +listaGruas[91].proximaLlegadaReparación.ToString() + "-" + listaGruas[91].estado.ToString(),
                            listaGruas[92].RndPrimerRotura.ToString() + "|" + listaGruas[92].tiempoProximaRotura + "|" +listaGruas[92].proximaLlegadaReparación.ToString() + "-" + listaGruas[92].estado.ToString(),
                            listaGruas[93].RndPrimerRotura.ToString() + "|" + listaGruas[93].tiempoProximaRotura + "|" +listaGruas[93].proximaLlegadaReparación.ToString() + "-" + listaGruas[93].estado.ToString(),
                            listaGruas[94].RndPrimerRotura.ToString() + "|" + listaGruas[94].tiempoProximaRotura + "|" +listaGruas[94].proximaLlegadaReparación.ToString() + "-" + listaGruas[94].estado.ToString(),
                            listaGruas[95].RndPrimerRotura.ToString() + "|" + listaGruas[95].tiempoProximaRotura + "|" +listaGruas[95].proximaLlegadaReparación.ToString() + "-" + listaGruas[95].estado.ToString(),
                            listaGruas[96].RndPrimerRotura.ToString() + "|" + listaGruas[96].tiempoProximaRotura + "|" +listaGruas[96].proximaLlegadaReparación.ToString() + "-" + listaGruas[96].estado.ToString(),
                            listaGruas[97].RndPrimerRotura.ToString() + "|" + listaGruas[97].tiempoProximaRotura + "|" +listaGruas[97].proximaLlegadaReparación.ToString() + "-" + listaGruas[97].estado.ToString(),
                            listaGruas[98].RndPrimerRotura.ToString() + "|" + listaGruas[98].tiempoProximaRotura + "|" +listaGruas[98].proximaLlegadaReparación.ToString() + "-" + listaGruas[98].estado.ToString(),
                            listaGruas[99].RndPrimerRotura.ToString() + "|" + listaGruas[99].tiempoProximaRotura + "|" +listaGruas[99].proximaLlegadaReparación.ToString() + "-" + listaGruas[99].estado.ToString(),
                            listaGruas[100].RndPrimerRotura.ToString() + "|" + listaGruas[100].tiempoProximaRotura + "|" +listaGruas[100].proximaLlegadaReparación.ToString() + "-" + listaGruas[100].estado.ToString(),
                            listaGruas[101].RndPrimerRotura.ToString() + "|" + listaGruas[101].tiempoProximaRotura + "|" +listaGruas[101].proximaLlegadaReparación.ToString() + "-" + listaGruas[101].estado.ToString(),
                            listaGruas[102].RndPrimerRotura.ToString() + "|" + listaGruas[102].tiempoProximaRotura + "|" +listaGruas[102].proximaLlegadaReparación.ToString() + "-" + listaGruas[102].estado.ToString(),
                            listaGruas[103].RndPrimerRotura.ToString() + "|" + listaGruas[103].tiempoProximaRotura + "|" +listaGruas[103].proximaLlegadaReparación.ToString() + "-" + listaGruas[103].estado.ToString(),
                            listaGruas[104].RndPrimerRotura.ToString() + "|" + listaGruas[104].tiempoProximaRotura + "|" +listaGruas[104].proximaLlegadaReparación.ToString() + "-" + listaGruas[104].estado.ToString(),
                            listaGruas[105].RndPrimerRotura.ToString() + "|" + listaGruas[105].tiempoProximaRotura + "|" +listaGruas[105].proximaLlegadaReparación.ToString() + "-" + listaGruas[105].estado.ToString(),
                            listaGruas[106].RndPrimerRotura.ToString() + "|" + listaGruas[106].tiempoProximaRotura + "|" +listaGruas[106].proximaLlegadaReparación.ToString() + "-" + listaGruas[106].estado.ToString(),
                            listaGruas[107].RndPrimerRotura.ToString() + "|" + listaGruas[107].tiempoProximaRotura + "|" +listaGruas[107].proximaLlegadaReparación.ToString() + "-" + listaGruas[107].estado.ToString(),
                            listaGruas[108].RndPrimerRotura.ToString() + "|" + listaGruas[108].tiempoProximaRotura + "|" +listaGruas[108].proximaLlegadaReparación.ToString() + "-" + listaGruas[108].estado.ToString(),
                            listaGruas[109].RndPrimerRotura.ToString() + "|" + listaGruas[109].tiempoProximaRotura + "|" +listaGruas[109].proximaLlegadaReparación.ToString() + "-" + listaGruas[109].estado.ToString(),
                            listaGruas[110].RndPrimerRotura.ToString() + "|" + listaGruas[110].tiempoProximaRotura + "|" +listaGruas[110].proximaLlegadaReparación.ToString() + "-" + listaGruas[110].estado.ToString(),
                            listaGruas[111].RndPrimerRotura.ToString() + "|" + listaGruas[111].tiempoProximaRotura + "|" +listaGruas[111].proximaLlegadaReparación.ToString() + "-" + listaGruas[111].estado.ToString(),
                            listaGruas[112].RndPrimerRotura.ToString() + "|" + listaGruas[112].tiempoProximaRotura + "|" +listaGruas[112].proximaLlegadaReparación.ToString() + "-" + listaGruas[112].estado.ToString(),
                            listaGruas[113].RndPrimerRotura.ToString() + "|" + listaGruas[113].tiempoProximaRotura + "|" +listaGruas[113].proximaLlegadaReparación.ToString() + "-" + listaGruas[113].estado.ToString(),
                            listaGruas[114].RndPrimerRotura.ToString() + "|" + listaGruas[114].tiempoProximaRotura + "|" +listaGruas[114].proximaLlegadaReparación.ToString() + "-" + listaGruas[114].estado.ToString(),
                            listaGruas[115].RndPrimerRotura.ToString() + "|" + listaGruas[115].tiempoProximaRotura + "|" +listaGruas[115].proximaLlegadaReparación.ToString() + "-" + listaGruas[115].estado.ToString(),
                            listaGruas[116].RndPrimerRotura.ToString() + "|" + listaGruas[116].tiempoProximaRotura + "|" +listaGruas[116].proximaLlegadaReparación.ToString() + "-" + listaGruas[116].estado.ToString(),
                            listaGruas[117].RndPrimerRotura.ToString() + "|" + listaGruas[117].tiempoProximaRotura + "|" +listaGruas[117].proximaLlegadaReparación.ToString() + "-" + listaGruas[117].estado.ToString(),
                            listaGruas[118].RndPrimerRotura.ToString() + "|" + listaGruas[118].tiempoProximaRotura + "|" +listaGruas[118].proximaLlegadaReparación.ToString() + "-" + listaGruas[118].estado.ToString(),
                            listaGruas[119].RndPrimerRotura.ToString() + "|" + listaGruas[119].tiempoProximaRotura + "|" +listaGruas[119].proximaLlegadaReparación.ToString() + "-" + listaGruas[119].estado.ToString(),

            };
            dgvTabla.Rows.Add(fila2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            txtMaxUniformeprimerLLegada.Enabled = true;
            txtMinUniformePrimerLLegada.Enabled = true;
            //txtCantDiasReparacion.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            txtCantDiasReparacion.Enabled=true;
        }
    }

}

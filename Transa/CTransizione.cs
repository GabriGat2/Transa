using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transa
{
    public class CTransizione
    {
        /// <summary>
        /// Transizione
        /// </summary>
        protected string transizione;
        public string Transizione { get => transizione; set => SetTransizione( value); }
        /// <summary>
        /// Transizione scomposta in campi
        /// </summary>
        protected string[] CampiTransizione = null;
        /// <summary>
        /// Numero delle colonne della transizione
        /// </summary>
        protected virtual int NumColonneTransizione { get => 7; }
        /// <summary>
        /// Stati della transizione
        /// </summary>
        public enum EStatoTransizione
        {
            Vuota,                  // 0
            Nuova,                  // 1
            Selezionata,            // 2               
            Analizzata,             // 3   
            Assegnata,              // 4
            NonAssegnata,           // 5
        };
        /// <summary>
        /// Stato della transizione
        /// </summary>
        protected EStatoTransizione stato;
        public EStatoTransizione Stato { get => stato; set => stato = value; }
        /// <summary>
        /// Colonne della transizione
        /// </summary>
        private enum EColonneTransizione
        {
            Data,                   // 0                       
            Addebito,               // 1               
            Accredito,              // 2   
            Rimborso,               // 3
            SpesaBea,               // 4
            Istruzioni,             // 5
            Causale,                // 6
        };
        /// <summary>
        /// Rende la colonna della causale
        /// </summary>
        protected virtual int ColonnaCausale { get => (int) EColonneTransizione.Causale;  }
        /// <summary>
        /// Rende il valore della causale
        /// </summary>
        public virtual string Causale { get => GetCausale(); }
        protected virtual string GetCausale ()
        {
            if (Scomponibile())
                return CampiTransizione[(int)EColonneTransizione.Causale];
            else
                return "???";
        }
        /// <summary>
        /// Rende il valore della data dell'operazione
        /// </summary>
        public virtual DateTime Data { get => GetData(); }
        protected virtual DateTime GetData()
        {
            if (! Scomponibile())
                return new DateTime(1959, 9, 1);

            // Scompone la data
            string[] campiData = CampiTransizione[(int)EColonneTransizione.Data].Split('/');
            if (campiData.Length == 3)
                return new DateTime(Convert.ToInt32(campiData[2]), Convert.ToInt32(campiData[1]), Convert.ToInt32(campiData[0]));
            else
                return new DateTime(1959, 9, 2);
        }

        /// <summary>
        /// Rende il valore dell'operazione
        /// </summary>
        public virtual double Valore { get => GetValore(); }

        protected virtual double GetValore()
        {
            if (!Scomponibile())
                return 0.0;

            // Verifica che non siano entrambi diversi da 0
            if (Addebito > 0.0 && Accredito > 0.0)
                return 0;

            if (Addebito > 0.0)
                return (Addebito * -1.0);
            else
                return (Accredito );
        }
        /// <summary>
        /// Rende il valore dell'operazione in formato stringa
        /// </summary>
        public string sValore { get => GetValore().ToString("#0.00"); }
        /// <summary>
        /// Rende il valore dell'operazione in formato stringa negato
        /// </summary>
        public string snValore { get => (GetValore() * -1.0).ToString("#0.00"); }
        /// <summary>
        /// Valore del valore in formato string con simbolo
        /// </summary>
        public string ssValore(string simbolo) { return sValore + " " + simbolo; }
        /// <summary>
        /// Valore del valore negato in formato string con simbolo
        /// </summary>
        public string ssnValore(string simbolo) { return snValore + " " + simbolo; }


        /// <summary>
        /// Valore dell'accredito
        /// </summary>
        public virtual double Accredito { get => GetAccredito();}
        protected virtual double GetAccredito()
        {
            if (!Scomponibile())
                return 0.0;

            // Estrae accredito
            return ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Accredito]);
        }
        /// <summary>
        /// Valore dell'accredito in formato string
        /// </summary>
        public string sAccredito { get => GetAccredito().ToString("#0.00"); }
        /// <summary>
        /// Valore dell'accredito negato in formato string
        /// </summary>
        public string snAccredito { get => (GetAccredito() * -1.0).ToString("#0.00"); }
        /// <summary>
        /// Valore dell'Accredito in formato string con simbolo
        /// </summary>
        public string ssAccredito(string simbolo) { return sAccredito +" " + simbolo; }
        /// <summary>
        /// Valore dell'Accredito negato in formato string con simbolo
        /// </summary>
        public string ssnAccredito(string simbolo) { return snAccredito +" " + simbolo; }


        /// <summary>
        /// Valore dell'addebito
        /// </summary>
        public virtual double Addebito { get => GetAddebito(); }
        protected virtual double GetAddebito()
        {
            if (!Scomponibile())
                return 0.0;

            // Estrae accredito
            return ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Addebito]);
        }
        /// <summary>
        /// Valore dell'addebito in formato string
        /// </summary>
        public string sAddebito { get => GetAddebito().ToString("#0.00"); }
        /// <summary>
        /// Valore dell'addebito negato in formato string
        /// </summary>
        public string snAddebito { get => (GetAddebito() * -1.0).ToString("#0.00"); }
        /// <summary>
        /// Valore dell'addebito in formato string con simbolo
        /// </summary>
        public string ssAddebito (string simbolo) { return sAddebito + " " + simbolo; }
        /// <summary>
        /// Valore dell'addebito negato in formato string con simbolo
        /// </summary>
        public string ssnAddebito(string simbolo) { return snAddebito + " " + simbolo; }


        /// <summary>
        /// Costruttore
        /// </summary>
        public CTransizione ()
        {
            CampiTransizione = null;
            stato = EStatoTransizione.Vuota;
        }
        /// <summary>
        /// assegna la transizione
        /// </summary>
        /// <param name="transizione"></param>
        public void SetTransizione(string value)
        {
            // assegna la transizione
            transizione = value;

            // verifica il contenuto della transizione
            if ((transizione == null) || (transizione.Length == 0))
                stato = EStatoTransizione.Vuota;
            else
            {
                // scompone i campi della transizione
                ScomponeTransizione();

                // cambia lo stato della transizione
                if (Scomponibile())
                    stato = EStatoTransizione.Selezionata;
                else
                    stato = EStatoTransizione.Vuota;
            }
        }
        /// <summary>
        /// Scompone la transione
        /// </summary>
        protected void ScomponeTransizione()
        {
            // Svuota i campi della transizione
            CampiTransizione = null;
            
            // scompone i campi
            string[] campi = transizione.Split(';');

            // verifica che ci sia un numero di campi minimo
            if (campi.Length < NumColonneTransizione)
            {
                return;
            }

            // ricompone il campo della causale
            string causale = campi[ColonnaCausale];
            for (int i = ColonnaCausale + 1; i < campi.Length; i++)
            {
                causale += ",";
                causale += campi[i];
            }

            // Genera i campi della transizione
            CampiTransizione = new string[NumColonneTransizione];

            // compone i campi da restituire
            for (int i = 0; i < CampiTransizione.Length - 1; i++)
            {
                CampiTransizione[i] = campi[i];
            }

            // aggiunge il campo causale
            CampiTransizione[ColonnaCausale] = causale;
        }
        /// <summary>
        /// Verifica che la transizione esiste
        /// </summary>
        /// <returns></returns>
        public bool Esiste()
        {
            return !string.IsNullOrEmpty(transizione);
        }
        /// <summary>
        /// Verifica se la transizione può essere scomposta
        /// </summary>
        /// <returns></returns>
        public bool Scomponibile()
        {
            if (Esiste())
                return CampiTransizione != null;
            else
                return false;
        }
        /// <summary>
        /// Rende lo stato in formato stringa
        /// </summary>
        /// <returns></returns>
        public string GetStato()
        {
            return stato.ToString();

        }
        /// <summary>
        /// Rende la data impostato nel fomato anno, mese, giorno
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DataAMG(string data)
        {
            string[] campiData = data.Split('/');

            string dataAMG = campiData[2] + '/' + campiData[1] + '/' + campiData[0];

            return dataAMG;
        }
        /// <summary>
        /// Nega il valore di una stringa
        /// </summary>
        /// <param name="valore"></param>
        /// <returns></returns>
        public string NegaValore(string valore)
        {
            // converte in double
            double dValore = ConvertAG.ToDouble0(valore);
            // nega il valore
            dValore *= -1;
            return dValore.ToString("#0.00");
        }
        /// <summary>
        /// Rende il conto sorgente, se non esiste rende null
        /// </summary>
        /// <returns></returns>
        public virtual string GetContoSorgente()
        {
            // Analizza spesa Bea
            string conto = CampiTransizione[(int)EColonneTransizione.SpesaBea];

            if (conto != null)
            {
                switch (conto.ToLower())
                {

                    case "spese beatrice":
                        return "Uscite:O:Spese Beatrice";
                    case "prestiti & rimborsi":
                        return "Uscite:O:Spese Beatrice:Prestiti & Rimborsi";
                    case "ristorante":
                        return "Uscite:O:Spese Beatrice:Ristorante";
                    case "spesemisteriose":
                        return "Uscite:O:Spese Beatrice:SpeseMisteriose";
                    case "vacanze":
                        return "Uscite:O:Spese Beatrice:Vacanze";
                    case "varie":
                        return "Uscite:O:Spese Beatrice:Varie";
                    default:
                        if (conto.Length == 0)
                            break;
                        else
                        {
                            var result3 = MessageBox.Show(conto,
                                "Questo conto non è gestito!!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return null;
                        }
                        break;
                }
            }

            // Analizza istruzione Bea Bea
            conto = CampiTransizione[(int)EColonneTransizione.Istruzioni];

            if (conto != null)
            {
                switch (conto.ToLower())
                {

                    case "beatrice":
                        return "Uscite:O:Istruzione:Beatrice";

                    case "cancelleria":
                        return "Uscite:O:Istruzione:Beatrice:Cancelleria";

                    case "corsi":
                        return "Uscite:O:Istruzione:Beatrice:Corsi";

                    case "escursioni":
                        return "Uscite:O:Istruzione:Beatrice:Escursioni";

                    case "eventi":
                        return "Uscite:O:Istruzione:Beatrice:Eventi";

                    case "lezioniLezioni":
                        return "Uscite:O:Istruzione:Beatrice:LezioniLezioni";

                    case "libri":
                        return "Uscite:O:Istruzione:Beatrice:Libri";

                    case "mensa":
                        return "Uscite:O:Istruzione:Beatrice:Mensa";

                    case "patente":
                        return "Uscite:O:Istruzione:Beatrice:Patente";

                    case "tasse":
                        return "Uscite:O:Istruzione:Beatrice:Tasse";

                    case "test università":
                        return "Uscite:O:Istruzione:Beatrice:Test Università";

                    case "trasporti":
                        return "Uscite:O:Istruzione:Beatrice:Trasporti";

                    case "università":
                        return "Uscite:O:Istruzione:Beatrice:Università";

                    case "varie":
                        return "Uscite:O:Istruzione:Beatrice:Varie";

                    case "banca":
                        return "Uscite:O:Banca:OUT_BancoPosta-BG,OUT_BancoPosta-BG";


                    default:
                        if (conto.Length == 0)
                            break;
                        else
                        {
                            var result3 = MessageBox.Show(conto,
                                "Questo conto non è gestito!!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return null;
                        }
                        break;
                }
                return null;
            }
            return null;
        }
        /// <summary>
        /// Rende il conto destinazione, se non esiste rende null
        /// </summary>
        /// <returns></returns>
        public virtual string GetContoDestinazione()
        {
            // Analizza spesa Bea
            string conto = CampiTransizione[(int)EColonneTransizione.Rimborso];

            if (conto != null)
            {
                if (conto.Length == 0)
                    return "Attivita:AttivitaCorrenti:BancoPosta-BG";

                switch (conto.ToLower())
                {

                    case "rimborso":
                        return "Attivita:AttivitaCorrenti:BancoPosta-BG:BG_Rimborso";
                    default:
                        if (conto.Length == 0)
                            break;
                        else
                        {
                            var result3 = MessageBox.Show(conto,
                                "Questo conto non è gestito!!!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return null;
                        }
                        break;
                }
            }
            return null;
        }
    }
}






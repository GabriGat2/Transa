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
        public virtual string Valore { get => GetValore(); }
        protected virtual string GetValore()
        {
            if (!Scomponibile())
                return "Non disponibile";

            // Estrae addebito
            double addebito = ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Addebito]);

            // Estrae accredito
            double accredito = ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Accredito]);

            // Verifica che non siano entrambi diversi da 0
            if (addebito > 0.0 && accredito > 0.0)
                return "Conflitto";

            if (addebito > 0.0)
                return (addebito * -1.0).ToString();
            else
                return (accredito ).ToString();
        }



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

            // scompone i campi della transizione
            ScomponeTransizione();

            // cambia lo stato della transizione
            if (Scomponibile())
                stato = EStatoTransizione.Selezionata;
            else
                stato = EStatoTransizione.Vuota;
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
            for (int i = ColonnaCausale; i < campi.Length; i++)
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


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transa
{
    public class CTransizione_BP25 : CTransizione
    {
        /// <summary>
        /// Numero delle colonne della transizione
        /// </summary>
        protected override int NumColonneTransizione { get => 5; }

        /// <summary>
        /// Colonne della transizione
        /// </summary>
        private enum EColonneTransizione
        {
            DataContabile,          // 0
            DataValuta,             // 1
            Addebito,               // 2               
            Accredito,              // 3   
            Causale,                // 4
        };
        /// <summary>
        /// Rende la colonna della causale
        /// </summary>
        protected override int ColonnaCausale { get => (int)EColonneTransizione.Causale; }
        /// <summary>
        /// Rende il valore della causale
        /// </summary>
        public override string Causale { get => GetCausale(); }
        protected override string GetCausale()
        {
            if (Scomponibile())
                return CampiTransizione[(int)EColonneTransizione.Causale];
            else
                return "???";
        }

        /// <summary>
        /// Rende il valore della data dell'operazione
        /// </summary>
        public override DateTime Data { get => GetData(); }
        protected override DateTime GetData()
        {
            if (!Scomponibile())
                return new DateTime(1959, 9, 1);

            // Scompone la data
            string[] campiData = CampiTransizione[(int)EColonneTransizione.DataContabile].Split('/');
            if (campiData.Length == 3)
                return new DateTime(Convert.ToInt32(campiData[2]), Convert.ToInt32(campiData[1]), Convert.ToInt32(campiData[0]));
            else
                return new DateTime(1959, 9, 2);
        }

        ///// <summary>
        ///// Rende il valore dell'operazione
        ///// </summary>
        //public override string Valore { get => GetValore(); }
        //protected override string GetValore()
        //{
        //    if (!Scomponibile())
        //        return "Non disponibile";

        //    // Estrae addebito
        //    double addebito = ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Addebito]);

        //    // Estrae accredito
        //    double accredito = ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Accredito]);

        //    // Verifica che non siano entrambi diversi da 0
        //    if (addebito > 0.0 && accredito > 0.0)
        //        return "Conflitto";

        //    if (addebito > 0.0)
        //        return (addebito * -1.0).ToString();
        //    else
        //        return (accredito).ToString();
        //}


        /// <summary>
        /// Rende il valore dell'operazione
        /// </summary>
        public override double Valore { get => GetValore(); }

        protected override double GetValore()
        {
            if (!Scomponibile())
                return 0.0;

            // Verifica che non siano entrambi diversi da 0
            if (Addebito > 0.0 && Accredito > 0.0)
                return 0;

            if (Addebito > 0.0)
                return (Addebito * -1.0);
            else
                return (Accredito);
        }


        /// <summary>
        /// Valore dell'accredito
        /// </summary>
        public override double Accredito { get => GetAccredito(); }
        protected override double GetAccredito()
        {
            if (!Scomponibile())
                return 0.0;

            // Estrae accredito
            return ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Accredito]);
        }


        /// <summary>
        /// Valore dell'addebito
        /// </summary>
        public override double Addebito { get => GetAddebito(); }
        protected override double GetAddebito()
        {
            if (!Scomponibile())
                return 0.0;

            // Estrae accredito
            return ConvertAG.ToDouble0(CampiTransizione[(int)EColonneTransizione.Addebito]);
        }

        /// <summary>
        /// Rende il conto sorgente, se non esiste rende null
        /// </summary>
        /// <returns></returns>
        public override string GetContoSorgente()
        {
            return null;
        }
        /// <summary>
        /// Rende il conto destinazione, se non esiste rende null
        /// </summary>
        /// <returns></returns>
        public override string GetContoDestinazione()
        {
            return null;
        }
    }
}

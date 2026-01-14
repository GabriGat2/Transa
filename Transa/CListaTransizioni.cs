using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transa
{
    public class CListaTransizioni
    {
        /// <summary>
        /// Lista delle transizioni 
        /// </summary>
        protected List<string> transizioni = new List<string>();
        /// <summary>
        /// Indice della transizione attiva
        /// </summary>
        private int indice;
        public int Indice { get => indice; }
        /// <summary>
        /// Numero delle transioni
        /// </summary>
        public int NumeroTransizioni { get => transizioni.Count;}
        /// <summary>
        /// Costruttore
        /// </summary>
        public CListaTransizioni()
        {

        }
        /// <summary>
        /// Inizializza la classe
        /// </summary>
        public void Clear()
        {
            transizioni.Clear();
            indice = 0;
        }
        /// <summary>
        ///  Rende la transizione selezionata
        /// </summary>
        /// <returns></returns>
        public string Get ()
        {
            return transizioni[Indice];
        }
        /// <summary>
        /// Rende la prossima trasizione
        /// </summary>
        /// <returns></returns>
        public string Next()
        {
            // incrementa indice
            indice++;
            // verifica il valore di indice
            if (Indice >= transizioni.Count)
            {
                indice = transizioni.Count - 1;
                return null;
            }
            else
                return transizioni[Indice];
        }
        /// <summary>
        /// Aggiunge una transizione
        /// </summary>
        /// <param name="transizione"></param>
        public void Add(string transizione)
        {
            transizioni.Add(transizione);
        }
    }
}

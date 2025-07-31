using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Transa
{
    public class CConto
    {
        /// <summary>
        /// Stati del conto
        /// </summary>
        public enum EStatoConto
        {
            Vuoto,                  // 0
            Invalido,               // 1               
            Valido,                 // 3   
        };
        /// <summary>
        /// Stato della transizione
        /// </summary>
        protected EStatoConto stato;
        public EStatoConto Stato { get => stato; set => stato = value; }
        /// <summary>
        /// Nome del conto
        /// </summary>
        private string nome = "";
        public string Nome { get => nome; set => AssegnaNomeConto(value); }

        /// <summary>
        /// Casella di testo associata
        /// </summary>
        private System.Windows.Forms.TextBox TextBoxConto;


        /// <summary>
        /// Costruttore
        /// </summary>
        //public CConto()
        //{            
        //    // Annulla la casella di testo del conto
        //    TextBoxConto = null;

        //    Inizializza();
        //}
        /// <summary>
        /// Costruttore
        /// </summary>
        public CConto(ref System.Windows.Forms.TextBox textBoxConto)
        {
            // Assegna la casella di testo del conto
            TextBoxConto = textBoxConto;

            Inizializza();
        }
        /// <summary>
        /// Inizializzazione
        /// </summary>
        public void Inizializza()
        {
            // inizializza il nome del conto
            Vuota();
        }
        /// <summary>
        /// Assegna il nome del conto 
        /// </summary>
        private void AssegnaNomeConto (string nomeConto)
        {
            // verifica che la stringa nomeConto non sia nulla
            if ((nomeConto == null) || (nomeConto.Length == 0)) 
            {
                Vuota();
            }
            else
            {
                // verifica se il nome del conto è lecito
                string[] campiConto = nomeConto.Split(':');
                if (campiConto.Length <= 0)
                {
                    Vuota();
                }
                else
                {
                    // assegna il nome del conto
                    nome = nomeConto;

                    // valida il nome del conto
                    stato = EStatoConto.Valido;
                }
            }

            // Aggiorna la casella di testo del conto
            AggiornaCasella();
        }
        /// <summary>
        /// Invalida lo stato del conto
        /// </summary>
        public void Vuota()
        {
            // Azzera il nome del conto
            nome = "";

            // assegna lo stato del conto del conto
            stato = EStatoConto.Vuoto;

            // Aggiorna la casella di testo del conto
            AggiornaCasella();
        }
        /// <summary>
        /// Invalida lo stato del conto
        /// </summary>
        public void Invalida()
        {
            // VerificationException se può invalidare il conto
            if (stato == EStatoConto.Valido)
            {
                // valida il nome del conto
                stato = EStatoConto.Invalido;
            }

            // Aggiorna la casella di testo del conto
            AggiornaCasella();
        }
        /// <summary>
        /// Valida lo stato del conto
        /// </summary>
        public void Valida()
        {
            // VerificationException se può validare il conto
            if (stato == EStatoConto.Invalido)
            {
                // valida il nome del conto
                stato = EStatoConto.Valido;
            }

            // Aggiorna la casella di testo del conto
            AggiornaCasella();
        }
        /// <summary>
        /// Rende true se il conto è valido
        /// </summary>
        public bool EValido()
        {
            // verifica che il conto è valido
            return (stato == EStatoConto.Valido);
        }
        /// <summary>
        /// Aggiorna la casella di testo del conto
        /// </summary
        private void AggiornaCasella()
        {
            // verifica che la casella di testo sia assegnata
            if (TextBoxConto == null)
                return;



            // assegna il nome del conto alla casella di testo
            TextBoxConto.Text = Nome;

            // colora la casella di testo
            switch (stato)
            {
                case EStatoConto.Vuoto:
                    TextBoxConto.BackColor = System.Drawing.Color.Orange;
                    break;

                case EStatoConto.Invalido:
                    TextBoxConto.BackColor = System.Drawing.Color.Yellow;
                    break;

                case EStatoConto.Valido:
                    TextBoxConto.BackColor = System.Drawing.Color.LightGreen;
                    break;

                default:
                    TextBoxConto.BackColor = System.Drawing.Color.Red;
                    break;
            }
        }
    }
}

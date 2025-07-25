using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transa
{
    public partial class FormFileBea: Form
    {
        /// <summary>
        /// Oggetto che contiene tutti i dati e le strutture comuni
        /// </summary>
        public LData lData;
        
        /// <summary>
        /// Lista delle transizioni 
        /// </summary>
        protected CListaTransizioni transizioni = new CListaTransizioni();
        /// <summary>
        /// Transizione attiva
        /// </summary>
        protected CTransizione transizione = new CTransizione();
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="rLdata"></param>
        public FormFileBea(ref LData rLdata)
        {
            // Asssegna l'oggeto per la gestione dei dati comuni
            lData = rLdata;

            // Azzera la lista delle transizioni
            transizioni.Clear();

            InitializeComponent();
        }
        /// <summary>
        /// Seleziona il file delle trasizioni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNomeFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxNomeFile.Text = openFileDialog1.FileName;
            }
        }
        /// <summary>
        /// Legge il file delle transizioni
        /// </summary>
        /// <param name="fileName"></param>
        private void LeggeFileTransizioni(string fileName)
        {
            try
            {
                // azzera la lista delle transizioni
                transizioni.Clear();

                // Apre il file delle transizioni
                var sr = new StreamReader(fileName);

                // loop di lettura del file delle transizioni
                bool run = true;
                string line;
                while (run)
                {
                    line = sr.ReadLine();
                    if (line == null)
                        run = false;
                    else
                    {
                        // aggiunge la linea letta alla lista delle transizioni
                        transizioni.Add(line);
                    }
                }

                // Assegna la transione
                transizione.Transizione = transizioni.Get();

                // stampa la transizione attiva
                textBoxLinea.Text = transizione.Transizione;
             }
            catch (SecurityException ex)
            {
                // azzera la lista dei conti
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
        /// <summary>
        /// Legge il file delle transizioni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butApri_Click(object sender, EventArgs e)
        {
            LeggeFileTransizioni(textBoxNomeFile.Text);
        }
        /// <summary>
        /// Analizza la linea selezionata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalizza_Click(object sender, EventArgs e)
        {
            richTextBoxLinee2.Clear();

            // Controlla se la transizione può essere scomposta
            if (!transizione.Scomponibile())
            {
                richTextBoxLinee2.AppendText("La transizione non può essere scomposta !!!");
                return;
            }


            // assegna causale operazione
            textDescrizioneOperazione.Text = "TR: " + transizione.Causale;

            // assegna data
            dateTimeOperazione.Value = transizione.Data;

            // Assegna il valore dell'operazione
            textValoreOperazione.Text = transizione.Valore;



        }
        /// <summary>
        ///  Seleziona la prossima transizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNext_Click(object sender, EventArgs e)
        {
            // Assegna la transione
            transizione.Transizione = transizioni.Next();

            // verifica se la transizione esiste
            if (transizione.Esiste())
                textBoxLinea.Text = transizione.Transizione;
            else
                textBoxLinea.Text = "!!! TUTTE LE TRANSIZIONI SONO STATE ESAMINATE";
        }
    }
}

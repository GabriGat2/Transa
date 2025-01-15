using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Transa
{
    public partial class FormGstStrConti : Form
    {
        /// <summary>
        /// Oggetto che contiene tutti i dati e le strutture comuni
        /// </summary>
        public LData lData;
        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="rLdata"></param>
        public FormGstStrConti(ref LData rLdata)
        {
            lData = rLdata;
            InitializeComponent();
            Inizializzazione();
            LocalUpdateForm();
        }
        /// <summary>
        /// Inizializzazione
        /// </summary>
        private void Inizializzazione()
        {
            // carica la combobox selezione conti 
            for (int i = 0; i < lData.TipoConti.Count(); i++)
            {
                // carica i conti sulla combo box
                comboBoxTipoConti.Items.Add(lData.TipoConti[i]);
            }
            comboBoxTipoConti.SelectedIndex = 0;
        }
        /// <summary>
        /// Seleziona e carica la struttura del conto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ReadingFileStructureAccounts(openFileDialog1.FileName);
            }
        }
        /// <summary>
        /// Legge e decodifica il file della struttura dei conti
        /// </summary>
        private void ReadingFileStructureAccounts(string fileName)
        {
            try
            {
                var sr = new StreamReader(fileName);

                // Segnala conti NonOk
                lData.ContiOk = false;

                // salva il nome del file della struttura dei conti
                lData.fileNameConti = fileName;

                // stampa il nome del file dei conti
                StampaNomefileConti();

                // Azzera la lista dei conti disponibili
                lData.conti.Clear();
                lData.contiAttivita.Clear();
                lData.contiAttivitaBase.Clear();
                lData.contiCapitali.Clear();
                lData.contiCapitaliBase.Clear();
                lData.contiCapitaliBaseIniziale.Clear();
                lData.contiCapitaliBaseFinale.Clear();

                bool run = true;
                string line;
                while (run)
                {
                    line = sr.ReadLine();
                    if (line == null)
                        run = false;
                    else
                    {
                        // separa gli elementi che compongono la stringa
                        string[] campi = line.Split(',');

                        // Analizza il tipo di riga
                        switch (campi[0])
                        {
                            case "ASSET":
                            case "CASH":
                            case "BANK":
                            case "LIABILITY":
                            case "INCOME":
                            case "EXPENSE":
                            case "EQUITY":
                            case "TRADING":
                                // aggiunte il conto ientificato alla lista dei conti
                                lData.conti.Add(campi[1]);

                                // seleziona il funzione del tipo
                                SelezionaConto(campi[1]);

                                // stampa il conto identificato
                                richTextBoxStrConti.AppendText(lData.conti[lData.conti.Count - 1]);
                                richTextBoxStrConti.AppendText("\n");
                                break;

                            default:
                                break;
                        }

                    }
                }

                // Segnala conti Ok
                lData.ContiOk = true;

                // Aggiorna i dati del form
                LocalUpdateForm();

            }
            catch (SecurityException ex)
            {
                // azzera la lista dei conti
                lData.conti.Clear();
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
        /// <summary>
        /// Legge e decodifica il file della struttura dei conti poi,
        /// analizza il campo0 e genera il file con il tipo di conti
        /// </summary>
        private void DEBUG_ReadingFileStructureAccounts(string fileName)
        {
            try
            {
                List<string> campo0 = new List<string>();
                List<string> tipoCampo0 = new List<string>();

                //String[] campo0 = null;

                var sr = new StreamReader(fileName);

                //SetText(sr.ReadToEnd());

                bool run = true;
                string line;
                while (run)
                {
                    line = sr.ReadLine();
                    if (line == null)
                        run = false;
                    else
                    {
                        // separa gli elementi che compongono la stringa
                        string[] campi = line.Split(',');

                        // crea la lista dei campi 0 e la stampa
                        campo0.Add(campi[0]);
                        richTextBoxStrConti.AppendText(campo0[campo0.Count - 1]);
                        richTextBoxStrConti.AppendText("\n");
                    }
                }
                // Salva il file dei campi0
                DEBUG_SalvaFileTesto(ref campo0);

                // estrae i tipi di campo0
                for (int i = 0; i < campo0.Count - 1; i++)
                {
                    if (!tipoCampo0.Contains(campo0[i]))
                        tipoCampo0.Add(campo0[i]);
                }
                    
                // salva i file con i tipi di campi0
                DEBUG_SalvaFileTesto(ref tipoCampo0);

            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
        /// <summary>
        /// Salva le transizione nel file specificato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DEBUG_SalvaFileTesto(ref List<string> campo0)
        {
            //Stream myStream;
            saveFileDialog1debug.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1debug.FilterIndex = 1;
            saveFileDialog1debug.RestoreDirectory = true;

            if (saveFileDialog1debug.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1debug.FileName;
                string fileName = saveFileDialog1debug.InitialDirectory;

                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    for (int i = 0; i < (campo0.Count); i++)
                    {
                        outputFile.WriteLine(campo0[i]);
                    }
                }
            }
        }
        /// <summary>
        /// Update del form
        /// </summary>
        private void LocalUpdateForm()
        {
            // azzera gli oggetti di visualizzazione
            comboBoxConti.Items.Clear();
            richTextBoxStrConti.Clear();

            // Aggiorna la lisra dei conti visualizzata
            switch (comboBoxTipoConti.SelectedItem)
            {
                case "All":
                    AggiornaTipoConto(lData.conti);
                    break;
                case "Attivita":
                    AggiornaTipoConto(lData.contiAttivita);
                    break;
                case "AttivitaBase":
                    AggiornaTipoConto(lData.contiAttivitaBase);
                    break;
                case "Capitali":
                    AggiornaTipoConto(lData.contiCapitali);
                    break;
                case "CapitaliBase":
                    AggiornaTipoConto(lData.contiCapitaliBase);
                    break;
                case "CapitaliBaseIniziale":
                    AggiornaTipoConto(lData.contiCapitaliBaseIniziale);
                    break;
                case "CapitaliBaseFinale":
                    AggiornaTipoConto(lData.contiCapitaliBaseFinale);
                    break;
                default:
                    AggiornaTipoConto(lData.conti);
                    break;
            }

            // stampa il nome del file dei conti
            StampaNomefileConti();

        }
        /// <summary>
        /// Attiva la visualizzazione della lista di conti indicati
        /// </summary>
        /// <param name="conti"></param>
        private void AggiornaTipoConto(List<string> conti)
        {
            // stampa e carica i conti sulla combo box 
            for (int i = 0; i < conti.Count; i++)
            {
                // carica i conti sulla combo box
                comboBoxConti.Items.Add(conti[i]);

                // stampa la lista dei conti
                richTextBoxStrConti.AppendText(conti[i]);
                richTextBoxStrConti.AppendText("\n");
            }
            if (conti.Count > 1)
                comboBoxConti.SelectedIndex = 0;

            // stampa il numero di conti gestiti
            textBoxNumeroConti.Text = conti.Count.ToString();
        }
        /// <summary>
        /// Stamapa colora il nome file dei conti
        /// </summary>
        private void StampaNomefileConti()
        {
            // stampa il nome dei file della struttura dei conti conti
            textBoxFileNameConti.Text = lData.fileNameConti;
            if (lData.ContiOk)
            {
                textBoxNumeroConti.BackColor = Color.LightGreen;
            }
            else
            {
                textBoxNumeroConti.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Seleziona il tipo di conto
        /// </summary>
        /// <param name="conto"></param>
        private void SelezionaConto(string conto)
        {
            // Scompone il conto
            string[] subConti = conto.Split(':');

            try
            {
                switch (subConti[0])
                {
                    case "Attivita":
                        // aggiunte il conto ientificato alla lista dei conti
                        lData.contiAttivita.Add(conto);
                        // seleziona il conto base
                        if (subConti.Length <= 3)
                            lData.contiAttivitaBase.Add(conto);
                        break;
                    case "Capitali":
                        lData.contiCapitali.Add(conto);
                        // seleziona il conto base
                        if (subConti.Length <= 4)
                        {
                            lData.contiCapitaliBase.Add(conto);
                            // selezione capitale iniziale e finale
                            if (subConti.Length > 1)
                            {
                                if (subConti[1] == "Iniziale")
                                    lData.contiCapitaliBaseIniziale.Add(conto);
                                if (subConti[1] == "Finale")
                                    lData.contiCapitaliBaseFinale.Add(conto);
                            }
                        }
                        break;
                    default:
                        break;

                }

            }
            catch (Exception e)
            {
                ;
            }

        }
        /// <summary>
        /// La selezione del tipo di conti è cambiata percui aggiorna la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipoConti_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalUpdateForm();
        }
    }
}

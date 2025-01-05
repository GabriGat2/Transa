using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transa
{
    public partial class FormNewOperation : Form
    {
        /// <summary>
        /// Oggetto che contiene tutti i dati e le strutture comuni
        /// </summary>
        public LData lData;
        /// <summary>
        /// tipo di sezione di conto
        /// </summary>
        private enum SezioneConto
        {
            ContoCompleto,
            ContoBase
        }
        /// <summary>
        /// indice per prelevare operazioni dalla tabella sorgente
        /// </summary>
        private int GetIndexSorgente = 0;
        /// <summary>
        /// indice per prelevare operazioni dalla tabella destinazione
        /// </summary>
        private int GetIndexDestinazione = 0;

        /// <summary>
        /// Costruttore
        /// </summary>
        /// <param name="rLdata"></param>
        public FormNewOperation(ref LData rLdata)
        {
            lData = rLdata;
            InitializeComponent();
            Inizializzazione();
            LocalUpdate();
            Debug_Inizializzazione();
        }
        /// <summary>
        /// Inizializzazione caselle base
        /// </summary>\
        private void Inizializzazione()
        {
            // inizializza le conmbo box per la selezione del tipo di operazione
            comboBoxTipoOperazioneSorgente.Items.Clear();
            comboBoxTipoOperazioneDestinazione.Items.Clear();
            for (int i = 0; i < lData.TipoOperazione.Length; i++)
            {
                comboBoxTipoOperazioneSorgente.Items.Add(lData.TipoOperazione[i]);
                comboBoxTipoOperazioneDestinazione.Items.Add(lData.TipoOperazione[i]);
            }
            comboBoxTipoOperazioneSorgente.SelectedIndex = 0;
            comboBoxTipoOperazioneDestinazione.SelectedIndex = 0;
        }
        /// <summary>
        /// DEBUG: inizializzazione caselle base
        /// </summary>
        private void Debug_Inizializzazione()
        {
            textDescrizioneOperazione.Text = "Operazione di prova";
            textValoreOperazione.Text = "1200,45";
            textDataOperazione.Text = "10/01/2025";

            textNotaSorgente.Text = "Prelievo da: ";

            textNotaDestinazione.Text = "Depositato in: ";


        }
        /// <summary>
        /// Aggiorna la tabella delle operazioni sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiornaSorgente_Click(object sender, EventArgs e)
        {
            string[] subOperazione = new string[3];


            // controlla se è una operazione singola o complessa
            if (!radioOperazioneSorgenteMultipla.Checked)
            {
                subOperazione[0] = textNotaSorgente.Text;
                subOperazione[1] = GetContoSorgente(SezioneConto.ContoCompleto);
                subOperazione[2] = "";

                dataGridViewSorgenteOperazione.Rows.Add(subOperazione);
            }
            else
            {
                // estrae il top di operazione selezionata
                string TipoOperazione = comboBoxTipoOperazioneSorgente.Text;

                switch (TipoOperazione)
                {
                    case "Single":
                        break;
                    case "Cnt":
                    case "Dep":
                        AggiornaSorgenteMultipla();
                        break;
                    case "Open":
                        OperazioneOpen(true);
                        break;
                    case "Close":
                        //OperazioneOpen(true);
                        break;
                    default:
                        break;

                }    


                //AggiornaSorgenteMultipla();
            }

            // Aggiorna i totalizzatori
            AggiornaTotalizzatoriSorgente();
        }
        /// <summary>
        /// Aggiorna la tabella sorgente con i sottoconti multipli
        /// </summary>
        private void AggiornaSorgenteMultipla()
        {
            // svuota la tabella
            int nRows = dataGridViewSorgenteOperazione.Rows.Count - 2;
            for (int i = nRows; i >= 0; i--)
            {
                dataGridViewSorgenteOperazione.Rows.RemoveAt(i);
            }

            string[] subOperazione = new string[3];
            string contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
            string contoSorgenteBase = GetContoSorgente(SezioneConto.ContoBase);

            // Aggiunge il sottoconto origine
            subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = "10";
            dataGridViewSorgenteOperazione.Rows.Add(subOperazione);

            switch (comboBoxTipoOperazioneSorgente.Text)
            { 
                case "Cnt":
                    // Aggiunge il sottoconto base
                    subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Cnt";
                    subOperazione[1] = contoSorgenteCompleto + ":Cnt";
                    subOperazione[2] = "20";
                    dataGridViewSorgenteOperazione.Rows.Add(subOperazione);

                    // aggiunge i sottoconti
                    for (int i = 0; i < lData.ContiMultipli.Length; i++)
                    {
                        subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Cnt:Cnt-" + lData.ContiMultipli[i]; 
                        subOperazione[1] = contoSorgenteCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                        subOperazione[2] = (100 * (i+1)).ToString();
                        dataGridViewSorgenteOperazione.Rows.Add(subOperazione);
                    }
                    break;

                case "Dep":
                    // Aggiunge il conto base
                    subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Dep";
                    subOperazione[1] = contoSorgenteCompleto + ":Dep";
                    subOperazione[2] = "30";
                    dataGridViewSorgenteOperazione.Rows.Add(subOperazione);

                    // aggiunge i sottoconti
                    for (int i = 0; i < lData.ContiMultipli.Length; i++)
                    {
                        subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Dep:Dep-" + lData.ContiMultipli[i];
                        subOperazione[1] = contoSorgenteCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                        subOperazione[2] = (100 * (i+1)).ToString();
                        dataGridViewSorgenteOperazione.Rows.Add(subOperazione);
                    }
                    break;

                default:
                    DialogResult = MessageBox.Show("Selezionare il sottoconto oppure deselezionare Operazione multipla",
                                                   "Non è selezionato il sottoconto",
                                                   MessageBoxButtons.OKCancel);

                    break;
            }
        }

        private void butAggiornaDestinazione_Click(object sender, EventArgs e)
        {
            string[] subOperazione = new string[3];


            // controlla se è una operazione singola o complessa
            if (!radioOperazioneDestinazioneMultipla.Checked)
            {
                subOperazione[0] = textNotaDestinazione.Text;
                subOperazione[1] = GetContoDestinazione(SezioneConto.ContoCompleto);
                subOperazione[2] = "";

                dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);
            }
            else
            {
                // estrae il top di operazione selezionata
                string TipoOperazione = comboBoxTipoOperazioneSorgente.Text;

                switch (TipoOperazione)
                {
                    case "Single":
                        break;
                    case "Cnt":
                    case "Dep":
                        AggiornaDestinazioneMultipla();
                        break;
                    case "Open":
                        OperazioneOpen(false);
                        break;
                    case "Close":
                        //OperazioneOpen(true);
                        break;
                    default:
                        break;

                }
                    //AggiornaDestinazioneMultipla();
            }

            // Aggiorna i totalizzatori
            AggiornaTotalizzatoriDestinazione();
        }

        private void AggiornaDestinazioneMultipla()
        {
            // svuota la tabella
            int nRows = dataGridViewDestinazioneOperazione.Rows.Count - 2;
            for (int i = nRows; i >= 0; i--)
            {
                dataGridViewDestinazioneOperazione.Rows.RemoveAt(i);
            }

            string[] subOperazione = new string[3];
            string contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);
            string contoDestinazioneBase = GetContoDestinazione(SezioneConto.ContoBase);


            // Aggiunge il sottoconto origine
            subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = "10";
            dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);

            switch (comboBoxTipoOperazioneDestinazione.Text)
            {
                case "Cnt":
                    // Aggiunge il sottoconto base
                    subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Cnt";
                    subOperazione[1] = contoDestinazioneCompleto + ":Cnt";
                    subOperazione[2] = "20";
                    dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);

                    // aggiunge i sottoconti
                    for (int i = 0; i < lData.ContiMultipli.Length; i++)
                    {
                        subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                        subOperazione[1] = contoDestinazioneCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i]; ;
                        subOperazione[2] = (100 * (i+1)).ToString();
                        dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);
                    }
                    break;

                case "Dep":
                    // Aggiunge il conto base
                    subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Dep";
                    subOperazione[1] = contoDestinazioneCompleto + ":Dep";
                    subOperazione[2] = "20";
                    dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);

                    // aggiunge i sottoconti
                    for (int i = 0; i < lData.ContiMultipli.Length; i++)
                    {
                        subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Dep:Dep-" + lData.ContiMultipli[i];
                        subOperazione[1] = contoDestinazioneCompleto + ":Dep:Dep-" + lData.ContiMultipli[i]; ;
                        subOperazione[2] = (100 * (i+1)).ToString();
                    dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);
                    }
                    break;

                default:
                    DialogResult = MessageBox.Show("Selezionare il sottoconto oppure deselezionare Operazione multipla",
                                                   "Non è selezionato il sottoconto",
                                                   MessageBoxButtons.OKCancel);

                    break;
            }
        }

        /// <summary>
        /// Operazione open:
        /// Sorgente preleva da un conto solo
        /// Destinazione va su più conti
        /// </summary>
        /// <param name="src"></param>
        private void OperazioneOpen(bool src)
        {
            if (src)
            {
                // Operazione OPEN da sorgente
                //==================================================================

                // svuota la tabella
                int nRows = dataGridViewSorgenteOperazione.Rows.Count - 2;
                for (int i = nRows; i >= 0; i--)
                {
                    dataGridViewSorgenteOperazione.Rows.RemoveAt(i);
                }

                string[] subOperazione = new string[3];
                string contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
                string contoSorgenteBase = GetContoSorgente(SezioneConto.ContoBase);

                // Aggiunge il sottoconto base
                subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase;
                subOperazione[1] = contoSorgenteCompleto;
                subOperazione[2] = "10";
                dataGridViewSorgenteOperazione.Rows.Add(subOperazione);

                // Aggiunge operazioni per famiglia "Cnt"
                // =====================================================================
                // Aggiunge il sottoconto Cnt ...
                subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Cnt";
                subOperazione[1] = contoSorgenteCompleto;
                subOperazione[2] = "20";
                dataGridViewSorgenteOperazione.Rows.Add(subOperazione);

                // aggiunge i sottoconti
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoSorgenteCompleto;
                    subOperazione[2] = (100 * (i + 1)).ToString();
                    dataGridViewSorgenteOperazione.Rows.Add(subOperazione);
                }

                // Aggiunge operazioni per famiglia "Dep"
                // =====================================================================
                // Aggiunge il conto base Dep
                subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Dep";
                subOperazione[1] = contoSorgenteCompleto;
                subOperazione[2] = "30";
                dataGridViewSorgenteOperazione.Rows.Add(subOperazione);

                // aggiunge i sottoconti
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoSorgenteCompleto;
                    subOperazione[2] = (100 * (i + 1)).ToString();
                    dataGridViewSorgenteOperazione.Rows.Add(subOperazione);
                }
            }
            else
            {
                // Operazione OPEN da destinazione
                //==================================================================

                // svuota la tabella
                int nRows = dataGridViewDestinazioneOperazione.Rows.Count - 2;
                for (int i = nRows; i >= 0; i--)
                {
                    dataGridViewDestinazioneOperazione.Rows.RemoveAt(i);
                }

                string[] subOperazione = new string[3];
                string contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);
                string contoDestinazioneBase = GetContoDestinazione(SezioneConto.ContoBase);

                // Aggiunge il sottoconto base
                subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase;
                subOperazione[1] = contoDestinazioneCompleto;
                subOperazione[2] = "10";
                dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);

                // Aggiunge operazioni per famiglia "Cnt"
                // =====================================================================
                // Aggiunge il sottoconto Cnt ...
                subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Cnt";
                subOperazione[1] = contoDestinazioneCompleto + ":Cnt";
                subOperazione[2] = "20";
                dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);

                // aggiunge i sottoconti
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoDestinazioneCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[2] = (100 * (i + 1)).ToString();
                    dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);
                }

                // Aggiunge operazioni per famiglia "Dep"
                // =====================================================================
                // Aggiunge il conto base Dep
                subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Dep";
                subOperazione[1] = contoDestinazioneCompleto;
                subOperazione[2] = "30";
                dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);

                // aggiunge i sottoconti
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoDestinazioneCompleto + ":Dep:Dep-" + lData.ContiMultipli[i]; 
                    subOperazione[2] = (100 * (i + 1)).ToString();
                    dataGridViewDestinazioneOperazione.Rows.Add(subOperazione);
                }
            }
            
        }

        /// <summary>
        /// Il valore di una cella sorgente è cambiato, viene ricalcolato il totale dei valori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSorgenteOperazione_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AggiornaTotalizzatoriSorgente();

            //// aggiorna il totale dei valori
            //double totale = 0;
            //for (int i = 0; i < dataGridViewSorgenteOperazione.Rows.Count; i++)
            //{
            //    if (dataGridViewSorgenteOperazione.Columns.Count>= 2)
            //        if (dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value != null)
            //        {
                        
            //            totale += Convert.ToDouble(dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString());
            //        }
            //}
            //textTotaleValoreSorgente.Text = totale.ToString();

            //// aggiuona il delta valore rispetto al valore dell'operazione
            //try
            //{
            //    textDeltaValoreSorgente.Text = (Convert.ToDouble(textValoreOperazione.Text) - totale).ToString();
            //}
            //catch(Exception e1)
            //{
            //    textDeltaValoreSorgente.Text = "???";
            //}
        }
        /// <summary>
        /// Aggiorna i totalizzatori della sorgente
        /// </summary>
        private void AggiornaTotalizzatoriSorgente()
        {
            // aggiorna il totale dei valori
            double totale = 0;
            for (int i = 0; i < dataGridViewSorgenteOperazione.Rows.Count; i++)
            {
                if (dataGridViewSorgenteOperazione.Columns.Count >= 2)
                    if (dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value != null)
                    {
                        //totale += Convert.ToDouble(dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString());
                        totale += ConvertAG.ToDouble0(dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString());
                    }
            }
            textTotaleValoreSorgente.Text = totale.ToString();

            // aggiuona il delta valore rispetto al valore dell'operazione
            try
            {
                textDeltaValoreSorgente.Text = (Convert.ToDouble(textValoreOperazione.Text) - totale).ToString();
            }
            catch (Exception e1)
            {
                textDeltaValoreSorgente.Text = "???";
            }
        }
        /// <summary>
        /// Il valore di una cella destinazione è cambiato, viene ricalcolato il totale dei valori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDestinazioneOperazione_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AggiornaTotalizzatoriDestinazione();
            //// aggiorna il totale dei valori
            //double totale = 0;
            //for (int i = 0; i < dataGridViewDestinazioneOperazione.Rows.Count; i++)
            //{
            //    if (dataGridViewDestinazioneOperazione.Columns.Count >= 2)
            //        if (dataGridViewDestinazioneOperazione.Rows[i].Cells[2].Value != null)
            //        {

            //            totale += Convert.ToDouble(dataGridViewDestinazioneOperazione.Rows[i].Cells[2].Value.ToString());
            //        }
            //}
            //textTotaleValoreDestinazione.Text = totale.ToString();

            //// aggiuona il delta valore rispetto al valore dell'operazione
            //try
            //{
            //    textDeltaValoreDestinazione.Text = (Convert.ToDouble(textValoreOperazione.Text) - totale).ToString();
            //}
            //catch (Exception e1)
            //{
            //    textDeltaValoreDestinazione.Text = "???";
            //}
        }
        /// <summary>
        /// Aggiorna i totalizzatori della destinazione
        /// </summary>
        private void AggiornaTotalizzatoriDestinazione()
        {
            // aggiorna il totale dei valori
            double totale = 0;
            for (int i = 0; i < dataGridViewDestinazioneOperazione.Rows.Count; i++)
            {
                if (dataGridViewDestinazioneOperazione.Columns.Count >= 2)
                    if (dataGridViewDestinazioneOperazione.Rows[i].Cells[2].Value != null)
                    {

                        totale += ConvertAG.ToDouble0(dataGridViewDestinazioneOperazione.Rows[i].Cells[2].Value.ToString());
                    }
            }
            textTotaleValoreDestinazione.Text = totale.ToString();

            // aggiuona il delta valore rispetto al valore dell'operazione
            try
            {
                textDeltaValoreDestinazione.Text = (Convert.ToDouble(textValoreOperazione.Text) - totale).ToString();
            }
            catch (Exception e1)
            {
                textDeltaValoreDestinazione.Text = "???";
            }
        }
        /// <summary>
        /// Genera una transizione esaminando la tabella sorgente
        /// GetIndexSorgente è incrementato automaticamente
        /// </summary>
        /// <param name="start"> = True azzera GetIndexSorgente </param>
        /// <returns></returns>
        public string [] GetNextSourceOperation(bool start = false)
        {
            if (start)
                GetIndexSorgente = 0;
            else
                GetIndexSorgente++;

            if (GetIndexSorgente < (dataGridViewSorgenteOperazione.Rows.Count - 1))
            {
                string[] campi = new string[lData.NameColumnsTransition.Length];


                campi[0] = textDataOperazione.Text;                             //  0 "Data",
                campi[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];      //  1 "ID transazione",
                campi[2] = lData.FilteredCellValuesOfTheTrasizioneLine[2];      //  2 "Numero",

                campi[3] = "== € " + textValoreOperazione.Text + " == " + textDescrizioneOperazione.Text;  //  3 "Descrizione",

                campi[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campi[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campi[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campi[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",

                campi[8] = dataGridViewSorgenteOperazione.Rows[GetIndexSorgente].Cells[0].Value.ToString(); //  8 "Promemoria",
                campi[9] = dataGridViewSorgenteOperazione.Rows[GetIndexSorgente].Cells[1].Value.ToString(); //  9 "Nome completo del conto",

                string[] porzioniConto = dataGridViewSorgenteOperazione.Rows[GetIndexSorgente].Cells[1].Value.ToString().Split(':');
                campi[10] = porzioniConto[porzioniConto.Length - 1]; // 10 "Nome del conto",

                string valore = "-" + dataGridViewSorgenteOperazione.Rows[GetIndexSorgente].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campi[11] = valoreSimb;                                         // 11 "Importo con Simb",
                campi[12] = valore;                                             // 12 "Importo Num.",
                campi[13] = valoreSimb;                                         // 13 "Valore con Simb",
                campi[14] = valore;                                             // 14 "Valore Num.",

                campi[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];    // 15 "Riconcilia",
                campi[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];    // 16 "Data di riconciliazione",
                campi[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];    // 17 "Tasso/Prezzo"

                return campi;
            }
            else
                return null;
        }
        /// <summary>
        /// Genera una transizione esaminando la tabella destinazione
        /// GetIndexDestinazione è incrementato automaticamente
        /// </summary>
        /// <param name="start"> = True azzera GetIndexDestinazione </param>
        /// <returns></returns>
        public string[] GetNextDestinationOperation(bool start = false)
        {
            if (start)
                GetIndexDestinazione = 0;
            else
                GetIndexDestinazione++;

            if (GetIndexDestinazione < (dataGridViewDestinazioneOperazione.Rows.Count - 1))
            {
                string[] campi = new string[lData.NameColumnsTransition.Length];


                campi[0] = textDataOperazione.Text;                             //  0 "Data",
                campi[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];      //  1 "ID transazione",
                campi[2] = lData.FilteredCellValuesOfTheTrasizioneLine[2];      //  2 "Numero",

                campi[3] = "== € " + textValoreOperazione.Text + " == " + textDescrizioneOperazione.Text;  //  3 "Descrizione",

                campi[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campi[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campi[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campi[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",

                campi[8] = dataGridViewDestinazioneOperazione.Rows[GetIndexDestinazione].Cells[0].Value.ToString(); //  8 "Promemoria",
                campi[9] = dataGridViewDestinazioneOperazione.Rows[GetIndexDestinazione].Cells[1].Value.ToString(); //  9 "Nome completo del conto",

                string[] porzioniConto = dataGridViewDestinazioneOperazione.Rows[GetIndexDestinazione].Cells[1].Value.ToString().Split(':');
                campi[10] = porzioniConto[porzioniConto.Length - 1]; // 10 "Nome del conto",

                string valore = dataGridViewDestinazioneOperazione.Rows[GetIndexDestinazione].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campi[11] = valoreSimb;                                         // 11 "Importo con Simb",
                campi[12] = valore;                                             // 12 "Importo Num.",
                campi[13] = valoreSimb;                                         // 13 "Valore con Simb",
                campi[14] = valore;                                             // 14 "Valore Num.",

                campi[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];    // 15 "Riconcilia",
                campi[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];    // 16 "Data di riconciliazione",
                campi[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];    // 17 "Tasso/Prezzo"

                return campi;
            }
            else
                return null;
        }
        /// <summary>
        /// aggiorna il form
        /// </summary>
        private void LocalUpdate()
        {
            // carica i conti sulle combo box 
            for (int i = 0; i < lData.conti.Count; i++)
            {
                comboBoxContoSorgente.Items.Add(lData.conti[i]);
                comboBoxContoDestinazione.Items.Add(lData.conti[i]);
            }

            AggiornaTotalizzatoriSorgente();
            AggiornaTotalizzatoriDestinazione();
        }
        /// <summary>
        /// Rende la porzione di conto sorgente richiesta
        /// </summary>
        /// <returns></returns>
        private string GetContoSorgente(SezioneConto sezione)
        {
            return GetPorzioneConto(sezione, ref comboBoxContoSorgente);
        }
        /// <summary>
        /// Rende la porzione di conto destinazione richiesta
        /// </summary>
        /// <param name="sezione"></param>
        /// <returns></returns>
        private string GetContoDestinazione(SezioneConto sezione)
        {
            return GetPorzioneConto(sezione, ref comboBoxContoDestinazione);
        }
        /// <summary>
        /// Rende la porzione di conto richiesta
        /// </summary>
        /// <param name="sezione"></param>
        /// <param name="comboBoxConto"></param>
        /// <returns></returns>
        private string GetPorzioneConto(SezioneConto sezione, ref ComboBox comboBoxConto)
        {
            // Controlla se c'è un conto selezionato
            if (comboBoxConto.SelectedItem == null)
            {
                return "???";
            }

            // estrae il conto selezionato
            string contoCompleto = comboBoxConto.SelectedItem.ToString(); 
            string contoReso = "???";
            string[] porzioniConto;

            switch (sezione)
            {
                case SezioneConto.ContoCompleto:
                    contoReso = contoCompleto;
                    break;

                case SezioneConto.ContoBase:
                    porzioniConto = contoCompleto.Split(':');
                    if (porzioniConto.Length >= 2)
                        contoReso = porzioniConto[2];
                    break;

                default:
                    break;

            }

            return contoReso;
        }
        /// <summary>
        /// Il valore complessivo del conto è cambiato, 
        /// aggiuorna i tolalizzatori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textValoreOperazione_TextChanged(object sender, EventArgs e)
        {
            AggiornaTotalizzatoriSorgente();
            AggiornaTotalizzatoriDestinazione();
        }
    }
}

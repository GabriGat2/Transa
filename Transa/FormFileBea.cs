using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Transa
{
    public partial class FormFileBea: Form
    {
        /// <summary>
        /// Operazione in corso
        /// </summary>
        private bool lOperazioneValida = false;
        /// <summary>
        /// Operazione in corso
        /// </summary>
        public bool OperazioneValida { get => lOperazioneValida; }

        /// <summary>
        /// Operazione inizializzata
        /// </summary>
        private bool lOperazioneInizializata = false;
        /// <summary>
        /// Operazione inizializzata
        /// </summary>
        public bool OperazioneInizializata { get => lOperazioneInizializata; }

        /// <summary>
        /// Griglia delle transizioni per GNUCaSH
        /// </summary>
        private DataGridView transactionDataGridView;        
        public DataGridView TransactionDataGridView { get => transactionDataGridView; set => transactionDataGridView = value; }

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
        protected CTransizione transizione = new CTransizione_BP25();


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
        /// Inizializzazione caselle base
        /// </summary>\
        private void Inizializzazione()
        {
            // Resetta operazione valida
            lOperazioneValida = false;

            // Azzera la lista delle transizioni
            transizioni.Clear();
        }
        /// <summary>
        /// Azzera tutti idati della classe
        /// </summary>
        public void AzzeraTutto()
        {
            Inizializzazione();
            //SvuotaTabella(ref dataGridViewSorgenteOperazione);
            //SvuotaTabella(ref dataGridViewDestinazioneOperazione);
            //GValori.AzzeraTutto();
            lOperazioneInizializata = false; // true;
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
                LeggeFileTransizioni(textBoxNomeFile.Text);
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
        /// Analizza la linea selezionata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalizza_Click(object sender, EventArgs e)
        {
            bool reso = GestioneNuovaTrasizione(false, true);   
        }
        /// <summary>
        ///  Seleziona la prossima transizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNext_Click(object sender, EventArgs e)
        {
            bool reso = GestioneNuovaTrasizione(true, false);
        }
        private void AggiornaStatoTrasione()
        {
            labelStatoTranzizione.Text = transizione.GetStato();
        }
        /// <summary>
        /// Gestione nuova Transizione
        /// </summary>
        /// <param name="next"></param>
        /// <param name="analizza"></param>
        /// <returns></returns>
        private bool GestioneNuovaTrasizione(bool next, bool analizza)
        {
            bool reso = GestioneNuovaTrasizione2(next, analizza);
            AggiornaStatoTrasione();
            return reso;
        }
        /// <summary>
        /// Gestione nuova Transizione
        /// </summary>
        /// <param name="next"></param>
        /// <param name="analizza"></param>
        private bool GestioneNuovaTrasizione2(bool next, bool analizza)
        {
            // controlla se deve estrarre una nuova transizione
            if (next)
            {
                // Analizza lo stato della transizione
                LData.ETransaErrore esito = LData.ETransaErrore.E0000_OK;
                if (transizione.Stato == CTransizione.EStatoTransizione.Selezionata)
                    esito = LData.ETransaErrore.E1202_TransizioneSelezionata;
                else if (transizione.Stato == CTransizione.EStatoTransizione.Analizzata)
                    esito = LData.ETransaErrore.E1203_TransizioneAnalizzata;

                if (esito != LData.ETransaErrore.E0000_OK)
                {
                    string messaggio2 = "Vuoi cancellare la trasizione in corso?";
                    if (!lData.StampaMessaggioErrore(esito, messaggio2))
                        return false;
                }

                // Assegna la transione
                transizione.Transizione = transizioni.Next();

                // Assegna al numero dell'operazioe l'Indice della trasizione
                textNumOperazione.Text = transizioni.Indice.ToString();

                // verifica se la transizione esiste
                if (transizione.Esiste())
                    textBoxLinea.Text = transizione.Transizione;
                else
                {
                    textBoxLinea.Text = "!!! TUTTE LE TRANSIZIONI SONO STATE ESAMINATE";
                    return false;
                }

                // cambia lo stato della transizione
                transizione.Stato = CTransizione.EStatoTransizione.Selezionata;
            }

            // controlla se deve analizzare un nuova transizione
            if (analizza)
            {
                if (transizione.Stato != CTransizione.EStatoTransizione.Selezionata)
                {
                    string messaggio2 = "Non ci sono transizioni selezionate!";
                    LData.ETransaErrore esito = LData.ETransaErrore.E1202_TransizioneSelezionata;
                    lData.StampaMessaggioErrore(esito, messaggio2);
                    return false;
                }

                // azzera i commenti
                richTextBoxLinee.Clear();

                // Controlla se la transizione può essere scomposta
                if (!transizione.Scomponibile())
                {
                    richTextBoxLinee.AppendText("La transizione non può essere scomposta !!!");
                    return false;
                }


                // assegna causale operazione
                textDescrizioneOperazione.Text = "TR: " + transizione.Causale;

                // assegna data
                dateTimeOperazione.Value = transizione.Data;

                // Assegna il valore dell'operazione
                textValoreOperazione.Text = transizione.Valore;


                // cambia lo stato della transizione
                transizione.Stato = CTransizione.EStatoTransizione.Analizzata;

                return true;
            }

            return true;
        }

        /// <summary>
        /// Aggiorna l'albero sorgente
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AggiornaAlberoSorgente()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;
            List<string> contiSorgente;
            string[] campiPath;

            // inizia aggiornamento
            treeViewSorgente.BeginUpdate();

            // Azzera Tree view
            treeViewSorgente.Nodes.Clear();


            // ================================================================
            // contiSpeseBeatrice

            // Assegna gruppo conto
            contiSorgente = lData.contiSpeseBeatrice;

            // verifica che esista almeno un nodo
            if (contiSorgente.Count == 0)
                return GstErrori.EErrore.E0001_NOK;

            // Aggiunge il primo nodo
            campiPath = contiSorgente[0].Split(':');
            TreeNode nodoG1 = new TreeNode("Spese Beatrice");
            treeViewSorgente.Nodes.Add(nodoG1);

            for (int i = 0; i < contiSorgente.Count; i++)
            {
                AggiungeNodo(ref nodoG1, contiSorgente[i], 2);
            }

            // ================================================================
            // contiSpeseIstruzionwBeatrice

            // Assegna gruppo conto
            contiSorgente = lData.contiSpeseIstruzioneBeatrice;

            // verifica che esista almeno un nodo
            if (contiSorgente.Count == 0)
                return GstErrori.EErrore.E0001_NOK;

            // Aggiunge il primo nodo
            campiPath = contiSorgente[0].Split(':');
            TreeNode nodoG2 = new TreeNode("Spese Istruzione Beatrice");
            treeViewSorgente.Nodes.Add(nodoG2);
            TreeNode nodoG3 = new TreeNode("Beatrice");
            nodoG2.Nodes.Add(nodoG3);

            for (int i = 0; i < contiSorgente.Count; i++)
            {
                AggiungeNodo(ref nodoG3, contiSorgente[i], 3);
            }


            // ========================================================================
            // Conti Uscite

            // Assegna gruppo conto
            contiSorgente = lData.contiUscite;

            // verifica che esista almeno un nodo
            if (contiSorgente.Count == 0)
                return GstErrori.EErrore.E0001_NOK;

            // Aggiunge il primo nodo
            campiPath = contiSorgente[0].Split(':');
            TreeNode nodo = new TreeNode(campiPath[0]);
            treeViewSorgente.Nodes.Add(nodo);

            for (int i = 0; i < contiSorgente.Count; i++)
            {
                AggiungeNodo(ref nodo, contiSorgente[i], 0);
            }

            // ================================================================


            // termina aggiornamnto
            treeViewSorgente.EndUpdate();

            return esito;
        }
        /// <summary>
        /// Aggiorna l'albero sorgente
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore AggiornaAlberoDestinazione()
        {
            GstErrori.EErrore esito = GstErrori.EErrore.E0000_OK;

            // inizia aggiornamnto
            treeViewDestinazione.BeginUpdate();

            // Azzeera Tree view
            treeViewDestinazione.Nodes.Clear();

            // Assegna gruppo conto
            List<string> contiDestinazione = lData.contiBancoPostaBG;

            // verifica che esista almeno un nodo
            if (contiDestinazione.Count == 0)
                return GstErrori.EErrore.E0001_NOK;

            // Aggiunge il primo nodo
            string[] campiPath = contiDestinazione[0].Split(':');
            TreeNode nodo = new TreeNode(campiPath[0]);
            treeViewDestinazione.Nodes.Add(nodo);

            for (int i = 0; i < contiDestinazione.Count; i++)
            {
                AggiungeNodo(ref nodo, contiDestinazione[i], 0);
            }

            // termina aggiornamnto
            treeViewDestinazione.EndUpdate();

            return esito;
        }
        /// <summary>
        /// Istruzioni eseguiti al caricamaneto del form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFileBea_Load(object sender, EventArgs e)
        {
            // Aggiorna l'arbero dei conti sorgenti
            AggiornaAlberoSorgente();
            // Aggiorna l'arbero dei conti destinazione
            AggiornaAlberoDestinazione();
        }
        /// <summary>
        /// Seleziona conto sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewSorgente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EstraeTagSorgente();
        }
        /// <summary>
        /// Estrae il tag dal treeViewSorgente che contiente il path del conmto
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore EstraeTagSorgente()
        {
            // recuprea il nodo selezionato
            TreeNode nodo = treeViewSorgente.SelectedNode;
            if (nodo == null)
                return GstErrori.EErrore.E0001_NOK;

            // recupera l'ID del nodo
            if (nodo.Tag == null)
                return GstErrori.EErrore.E0001_NOK;
            string PathConto = (string)nodo.Tag;

            // stampa i dati completi dell'identita del conto selezionato
            textBoxContoSorgente.Text = PathConto;

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Aggiunge un nodo
        /// </summary>
        /// <param name="nodo"></param>
        /// <param name="path"></param>
        /// <param name="indice"></param>
        /// <returns></returns>
        private GstErrori.EErrore AggiungeNodo(ref TreeNode nodo, string path, int indice)
        {
            // compone il path
            string[] campiPath = path.Split(':');

            // controlla se ha analizzato tutta la catena
            if (indice + 1 >= campiPath.Length)
                return GstErrori.EErrore.E0000_OK;

            // analizza il nome del nodo corrente
            if (nodo.Text != campiPath[indice])
                return GstErrori.EErrore.E0001_NOK;

            // nodo figlio
            TreeNode nodoFiglio;

            // Nome del nome figlio
            string nomeFiglio = campiPath[indice + 1];

            // estra i numero dei nodi figlio
            int numeroNodi = nodo.GetNodeCount(false);

            // analizza i nodi figlio
            for (int i = 0; i < numeroNodi; i++)
            {
                // Estra un nodo figlio
                nodoFiglio = nodo.Nodes[i];

                // Verifica il nome del nodo
                if (nodoFiglio.Text == campiPath[indice + 1])
                {
                    // aggiunge nodo
                    return AggiungeNodo(ref nodoFiglio, path, indice + 1);
                }
            }

            // se arriva qui significa: il nodo figlio non esiste

            // Crea Il nodo figlio
            nodoFiglio = new TreeNode(campiPath[indice + 1]);
            nodoFiglio.Tag = path;
            nodo.Nodes.Add(nodoFiglio);
            return AggiungeNodo(ref nodoFiglio, path, indice + 1);
        }
        /// <summary>
        /// Seleziona conto destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewDestinazione_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EstraeTagDestinazione();
        }
        /// <summary>
        /// Estrae il tag dal treeViewDestinazione che contiente il path del conto
        /// </summary>
        /// <returns></returns>
        private GstErrori.EErrore EstraeTagDestinazione()
        {
            // recuprea il nodo selezionato
            TreeNode nodo = treeViewDestinazione.SelectedNode;
            if (nodo == null)
                return GstErrori.EErrore.E0001_NOK;

            // recupera l'ID del nodo
            if (nodo.Tag == null)
                return GstErrori.EErrore.E0001_NOK;
            string PathConto = (string)nodo.Tag;

            // stampa i dati completi dell'identita del conto selezionato
            textBoxContoDestinazione.Text = PathConto;

            return GstErrori.EErrore.E0000_OK;
        }
        /// <summary>
        /// Genera tutte le transizioni che formano un operazione 
        /// </summary>
        /// <param name="start"> = Inizia una nuova estrazione </param>
        /// <returns></returns>
        public uint GetTransiction(ref DataGridView transactionDataGrid)
        {
            GeneraTransizioniBancoPosta25(ref transactionDataGrid);


            //// Estrae il tipo di operazione 
            //string tipoDiOperazione = comboBoxTipoOperazione.Text;

            //// Esegue l'operazione richiesta
            //switch (tipoDiOperazione)
            //{
            //    case "Transition":
            //    case "TitoloAcquisto":
            //    case "TitoloRimborso":
            //    case "Interessi":
            //        GeneraTransizioni(ref transactionDataGrid, ref dataGridViewSorgenteOperazione, true);
            //        GeneraTransizioni(ref transactionDataGrid, ref dataGridViewDestinazioneOperazione, false);
            //        break;

            //    case "Trasferimento":
            //        GeneraTransizioni(ref transactionDataGrid, ref dataGridViewSorgenteOperazione, true, true);
            //        GeneraTransizioni(ref transactionDataGrid, ref dataGridViewDestinazioneOperazione, false, true); ;
            //        break;

            //    case "Open":
            //        GeneraTransizioniOpen(ref transactionDataGrid);
            //        break;
            //    case "Close":
            //        GeneraTransizioniClose(ref transactionDataGrid);
            //        break;
            //    case "ZipSplit":
            //    case "Split":
            //    case "Zip":
            //        GeneraTransizioniSplit(ref transactionDataGrid);
            //        break;

            //    default:
            //        break;
            //}

            return 0;
        }
        ///// <summary>
        ///// Rende la data impostato nel fomato anno, mese, giorno
        ///// </summary>
        ///// <returns></returns>
        //private string DataAMG()
        //{
        //    string[] campiData = dateTimeOperazione.Text.Split('/');

        //    string dataAMG = campiData[2] + '/' + campiData[1] + '/' + campiData[0];

        //    return dataAMG;
        //}
        ///// <summary>
        ///// Nega il valore di una stringa
        ///// </summary>
        ///// <param name="stringaIn"></param>
        ///// <returns></returns>
        //private string NegaValore(string stringaIn)
        //{
        //    // converte in double
        //    double valore = ConvertAG.ToDouble0(stringaIn);
        //    // nega il valore
        //    valore *= -1;
        //    return valore.ToString("#0.00");
        //}
        /// <summary>
        /// Open genera un transizione per ogni conto:
        /// da conto sorgente
        /// a gruppo conti destinazione
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public void GeneraTransizioniBancoPosta25(ref DataGridView transactionDataGrid)
        {
            //// verifica che le tabelle sorgente e destinazione contengano lo stesso numero di transizioni
            //int nTransizioniSorgente = dataGridViewSorgenteOperazione.Rows.Count - 1;
            //int nTransizioniDestinazione = dataGridViewDestinazioneOperazione.Rows.Count - 1;
            //if (nTransizioniSorgente != nTransizioniDestinazione)
            //{
            //    string messaggio2 = "Lunghezza tabSorgente     = " + nTransizioniSorgente.ToString() + "\n" +
            //                        "Lunghezza tabDestinazione = " + nTransizioniDestinazione.ToString();

            //    LData.ETransaErrore esito = LData.ETransaErrore.E1007_LaDimensioniDelleTabelleSorgenteEDestinazioneSonoDiverse;

            //    lData.StampaMessaggioErrore(esito, messaggio2);
            //    return;
            //}

            // compone nome operazione parziale
            string nomeOperazione = textDescrizioneOperazione.Text;

            // Recupera il numero dell'operazione
            int numOperazione = Convert.ToInt32(textNumOperazione.Text);

            for (int i = 0; i < 1; i++)
            {
                // crea la stringa campi
                string[] campiS = new string[lData.NameColumnsTransition.Length];
                string[] campiD = new string[lData.NameColumnsTransition.Length];

                campiS[0] = transizione.DataAMG(transizione.Data.ToShortDateString());   //  0 "Data",
                campiD[0] = campiS[0];

                campiS[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];     //  1 "ID transazione",
                campiD[1] = campiS[1];

                campiS[2] = (numOperazione + i).ToString(); //lData.FilteredCellValuesOfTheTrasizioneLine[2];      //  2 "Numero",
                campiD[2] = campiS[2];

                campiS[3] = nomeOperazione + "===" + textValoreOperazione;  //  3 "Descrizione",
                campiD[3] = campiS[3];

                campiS[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campiD[4] = campiS[4];

                campiS[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campiD[5] = campiS[5];

                campiS[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campiD[6] = campiS[6];

                campiS[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",
                campiD[7] = campiS[7];

                campiS[8] = "Spesa";                                             //  8 "Promemoria",
                campiD[8] = "Addebito";                                          //  8 "Promemoria",

                campiS[9] = textBoxContoSorgente.Text;                           //  9 "Nome completo del conto",
                campiD[9] = textBoxContoDestinazione.Text;                       //  9 "Nome completo del conto",


                string[] porzioniContoS = textBoxContoSorgente.Text.Split(':');
                string[] porzioniContoD = textBoxContoDestinazione.Text.Split(':');
                campiS[10] = porzioniContoS[porzioniContoS.Length - 1]; // 10 "Nome del conto",
                campiD[10] = porzioniContoD[porzioniContoD.Length - 1]; // 10 "Nome del conto",

                string valore = textValoreOperazione.Text;
                string valoreSimb = valore + " €";
                campiS[11] = transizione.NegaValore(valoreSimb);                             // 11 "Importo con Simb",
                campiD[11] = valoreSimb;                                         // 11 "Importo con Simb",

                campiS[12] = transizione.NegaValore(valore);                                 // 12 "Importo Num.",
                campiD[12] = valore;                                             // 12 "Importo Num.",

                campiS[13] = transizione.NegaValore(valoreSimb);                             // 13 "Valore con Simb",
                campiD[13] = valoreSimb;                                         // 13 "Valore con Simb",

                campiS[14] = transizione.NegaValore(valore);                                 // 14 "Valore Num.",
                campiD[14] = valore;                                             // 14 "Valore Num.",

                campiS[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];    // 15 "Riconcilia",
                campiD[15] = campiS[15];

                campiS[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];    // 16 "Data di riconciliazione",
                campiD[16] = campiS[16];

                campiS[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];    // 17 "Tasso/Prezzo"
                campiD[17] = campiS[17];


                // Assegna le trasizioni generate    
                transactionDataGrid.Rows.Add(campiS);
                transactionDataGrid.Rows.Add(campiD);
            }
        }

        private void butAggiorna_Click(object sender, EventArgs e)
        {
            bool reso;

            if (radioButtonAssegna.Checked)
            {
                int cntGiri = Convert.ToInt32( textBoxGiri.Text);  
                bool gira = true;
                while (gira && cntGiri > 0)
                {
                    cntGiri--;

                    gira = GestioneAssegnaTransizione();
                    if (gira)
                    {
                        gira = GestioneNuovaTrasizione(true, true);
                    }
                }
            }
            else
                reso = GestioneAssegnaTransizione();
        }

        /// <summary>
        /// Gestisce l'assegnazione dei una transizione
        /// </summary>
        /// <returns></returns>
        private bool GestioneAssegnaTransizione()
        {
            if (transizione.Stato != CTransizione.EStatoTransizione.Analizzata)
            {
                string messaggio2 = "La transizione non è stata analizzata!";
                LData.ETransaErrore esito = LData.ETransaErrore.E1203_TransizioneAnalizzata;
                lData.StampaMessaggioErrore(esito, messaggio2);
                return false;
            }


            // esegue l'assegnazione della transizione
            GetTransiction(ref transactionDataGridView);


            // cambia lo stato della transizione
            transizione.Stato = CTransizione.EStatoTransizione.Assegnata;

            // Aggiorna lo stato della transizione
            AggiornaStatoTrasione();

            return true;

        }

    }
}
 
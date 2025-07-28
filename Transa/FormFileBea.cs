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
            richTextBoxLinee.Clear();

            // Controlla se la transizione può essere scomposta
            if (!transizione.Scomponibile())
            {
                richTextBoxLinee.AppendText("La transizione non può essere scomposta !!!");
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

    }
}
 
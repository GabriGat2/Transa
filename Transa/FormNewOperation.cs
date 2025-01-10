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
        /// Costruttore
        /// </summary>
        /// <param name="rLdata"></param>
        public FormNewOperation(ref LData rLdata)
        {
            lData = rLdata;
            InitializeComponent();
            Inizializzazione();
            LocalUpdate();
            //Debug_Inizializzazione();
        }
        /// <summary>
        /// Inizializzazione caselle base
        /// </summary>\
        private void Inizializzazione()
        {
            // carica le combobox selezione conti 
            comboBoxTipoContiSorgente.Items.Clear();
            comboBoxTipoContiDestinazione.Items.Clear();
            for (int i = 0; i < lData.TipoConti.Count(); i++)
            {
                // carica i conti sulla combo box
                comboBoxTipoContiSorgente.Items.Add(lData.TipoConti[i]);
                comboBoxTipoContiDestinazione.Items.Add(lData.TipoConti[i]);
            }
            comboBoxTipoContiSorgente.SelectedIndex = 0;
            comboBoxTipoContiDestinazione.SelectedIndex = 0;

              // inizializzazione caselle operazione
            textDescrizioneOperazione.Text = "Operazione di prova";
            textValoreOperazione.Text = "1234,56";
            textNumOperazione.Text = "1";
            textNotaSorgente.Text = "Prelievo da: ";
            textNotaDestinazione.Text = "Depositato in: ";

            // inizializza la combobox per la selezione del tipo di operazione
            comboBoxTipoOperazione.Items.Clear();
            for (int i = 0; i < lData.TipoOperazione.Length; i++)
            {
                comboBoxTipoOperazione.Items.Add(lData.TipoOperazione[i]);
            }
            comboBoxTipoOperazione.SelectedIndex = 0;

            // inizializza le combobox per la selezione del tipo di sottoconti
            comboBoxTipoSottocontiSorgente.Items.Clear();
            comboBoxTipoSottocontiDestinazione.Items.Clear();
            for (int i = 0; i < lData.TipoSottoconti.Length; i++)
            {
                comboBoxTipoSottocontiSorgente.Items.Add(lData.TipoSottoconti[i]);
                comboBoxTipoSottocontiDestinazione.Items.Add(lData.TipoSottoconti[i]);
            }
            comboBoxTipoSottocontiSorgente.SelectedIndex = 0;
            comboBoxTipoSottocontiDestinazione.SelectedIndex = 0;
        }
        /// <summary>
        /// DEBUG: inizializzazione caselle base
        /// </summary>
        private void Debug_Inizializzazione()
        {
            textDescrizioneOperazione.Text = "Operazione di prova";
            textValoreOperazione.Text = "1200,45";


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
            AggiornaSorgente();
        }
        // Aggiorna la sezione sorgente
        private void AggiornaSorgente()
        {
            string[] subOperazione = new string[3];

            // estra il tipo di sottoconto attivo
            string contiSelezionati = comboBoxTipoSottocontiSorgente.Text;

            // esegue l'operazione richiesta
            switch (contiSelezionati)
            {
                case "Single":
                    subOperazione[0] = textNotaSorgente.Text;
                    subOperazione[1] = GetContoSorgente(SezioneConto.ContoCompleto);
                    subOperazione[2] = lData.DEBUG_ValoreDefaultSorgente.ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                    break;

                case "Cnt":
                case "Dep":
                case "All":
                    AggiornaSorgenteMultipla(contiSelezionati);
                    break;

                default:
                    break;
            }
            // Aggiorna i totalizzatori
            AggiornaTotalizzatoriSorgente();
        }
        /// <summary>
        /// Aggiorna la tabella sorgente con i sottoconti multipli
        /// </summary>
        private void AggiornaSorgenteMultipla(string contiSelezionati)
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

            // Aggiunge il sottoconto base
            subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = lData.DEBUG_ValoreDefaultSorgente.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);


            // aggiunge i sotto conti del gruppo Cnt
            if ((contiSelezionati == "Cnt") || (contiSelezionati == "All"))
            {
                // Aggiunge il sottoconto base Cnt
                subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Cnt";
                subOperazione[1] = contoSorgenteCompleto + ":Cnt";
                subOperazione[2] = (lData.DEBUG_ValoreDefaultSorgente * 10).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                // aggiunge i sottoconti
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoSorgenteCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[2] = (lData.DEBUG_ValoreDefaultSorgente * (10 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                }

            }

            // aggiunge i sotto conti del gruppo Dep
            if ((contiSelezionati == "Dep") || (contiSelezionati == "All"))
            {
                // Aggiunge il conto base Dep
                subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Dep";
                subOperazione[1] = contoSorgenteCompleto + ":Dep";
                subOperazione[2] = (lData.DEBUG_ValoreDefaultSorgente * 20).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                // aggiunge i sottoconti del gruppo Dep
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaSorgente.Text + contoSorgenteBase + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoSorgenteCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[2] = (lData.DEBUG_ValoreDefaultSorgente * (20 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                }
            }
        }

        private void butAggiornaDestinazione_Click(object sender, EventArgs e)
        {
            AggiornaDestinazione();
        }
        /// <summary>
        /// Aggiorna la sezione destinazione
        /// </summary>
        private void AggiornaDestinazione()
        {
            string[] subOperazione = new string[3];

            // estra il tipo di sottoconto attivo
            string contiSelezionati = comboBoxTipoSottocontiDestinazione.Text;

            // esegue l'operazione richiesta
            switch (contiSelezionati)
            {
                case "Single":
                    subOperazione[0] = textNotaDestinazione.Text;
                    subOperazione[1] = GetContoDestinazione(SezioneConto.ContoCompleto);
                    subOperazione[2] = lData.DEBUG_ValoreDefaultDestinazione.ToString();

                    AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
                    break;

                case "Cnt":
                case "Dep":
                case "All":
                    AggiornaDestinazioneMultipla(contiSelezionati);
                    break;

                default:
                    break;
            }
            // Aggiorna i totalizzatori
            AggiornaTotalizzatoriDestinazione();
        }
        /// <summary>
        /// Aggiorna la sezione destinazioni con conti multipli
        /// </summary>
        private void AggiornaDestinazioneMultipla(string contiSelezionati)
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


            // Aggiunge il sottoconto base
            subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = lData.DEBUG_ValoreDefaultDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);


            // aggiunge i sotto conti del gruppo Cnt
            if ((contiSelezionati == "Cnt") || (contiSelezionati == "All"))
            {
                // Aggiunge il sottoconto base Cnt
                subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Cnt";
                subOperazione[1] = contoDestinazioneCompleto + ":Cnt";
                subOperazione[2] = (lData.DEBUG_ValoreDefaultDestinazione * 10).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

                // aggiunge i sottoconti Cnt
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoDestinazioneCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i]; ;
                    subOperazione[2] = (lData.DEBUG_ValoreDefaultDestinazione * (10 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
                }

            }

            // aggiunge i sotto conti del gruppo Dep
            if ((contiSelezionati == "Dep") || (contiSelezionati == "All"))
            {
                // Aggiunge il conto base Dep
                subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Dep";
                subOperazione[1] = contoDestinazioneCompleto + ":Dep";
                subOperazione[2] = (lData.DEBUG_ValoreDefaultDestinazione * 20).ToString(); ;
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

                // aggiunge i sottoconti Dep
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = textNotaDestinazione.Text + contoDestinazioneBase + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoDestinazioneCompleto + ":Dep:Dep-" + lData.ContiMultipli[i]; ;
                    subOperazione[2] = (lData.DEBUG_ValoreDefaultDestinazione * (20 + i + 1)).ToString(); ;
                    AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
                }
            }

        }
        /// <summary>
        /// Operazione open:
        /// - Preleva dal conto sorgente
        /// - Deposita nel gruppo del conto destinazione
        /// </summary>
        private void AggiornaOperazioneOpen()
        {
            // definisce la stringa per la porzione di transizione
            string[] subOperazione = new string[3];

            // compone i conti sorgente e destinazione
            string contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
            string contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);

            // compone promemoria base
            string promemoriaS = textDescrizioneOperazione.Text + "-> " + contoSorgenteCompleto;
            string promemoriaD = textDescrizioneOperazione.Text + "-> " + contoDestinazioneCompleto;

            // assegna il valori di inizializzazione base dei conti
            double DEBUG_vSorgente = lData.DEBUG_ValoreDefaultSorgente;
            double DEBUG_vDestinazione = DEBUG_vSorgente;


            // svuota le tabelle
            ClearDataGridView(ref dataGridViewSorgenteOperazione);
            ClearDataGridView(ref dataGridViewDestinazioneOperazione);


            //==================================================================
            // Compone le trasizioni sorgente
            //==================================================================

             // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaS;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = DEBUG_vSorgente.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // Aggiunge il sottoconto Cnt
            subOperazione[0] = promemoriaS + ":Cnt";
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = (DEBUG_vSorgente * 10).ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Cnt
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaS + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                subOperazione[1] = contoSorgenteCompleto;
                subOperazione[2] = (DEBUG_vSorgente * (10 + i + 1)).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
            }

            // Aggiunge il sottoconto Dep
            subOperazione[0] = promemoriaS + ":Dep";
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = (DEBUG_vSorgente * 20).ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Dep
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaS + ":Dep:Dep-" + lData.ContiMultipli[i];
                subOperazione[1] = contoSorgenteCompleto;
                subOperazione[2] = (DEBUG_vSorgente * (20 + i + 1)).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
            }


            //==================================================================
            // Compone le trasizioni sorgente destinazione
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaD;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // Aggiunge il sottoconto Cnt ...
            subOperazione[0] = promemoriaD + ":Cnt";
            subOperazione[1] = contoDestinazioneCompleto + ":Cnt";
            subOperazione[2] = (DEBUG_vDestinazione * 10).ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Cnt
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaD + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                subOperazione[1] = contoDestinazioneCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                subOperazione[2] = (DEBUG_vDestinazione * (10 + i + 1)).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
            }

            // Aggiunge il Sottoconto Dep
            subOperazione[0] = promemoriaD + ":Dep";
            subOperazione[1] = contoDestinazioneCompleto + ":Dep";
            subOperazione[2] = (DEBUG_vDestinazione * 20).ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Dep
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaD + ":Dep:Dep-" + lData.ContiMultipli[i];
                subOperazione[1] = contoDestinazioneCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                subOperazione[2] = (DEBUG_vDestinazione * (20 + i + 1)).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
            }

            // Aggiorna i totalizzazori();
            AggiornaTotalizzatoriSorgente();
        }
        /// <summary>
        /// Operazione Close:
        /// - Preleva dal gruppo del conto sorgente
        /// - Deposita nel conto destinazione
        /// </summary>
        private void AggiornaOperazioneClose()
        {
            // definisce la stringa per la porzione di transizione
            string[] subOperazione = new string[3];

            // compone i conti sorgente e destinazione
            string contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
            string contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);

            // compone promemoria base
            string promemoriaS = textDescrizioneOperazione.Text + "-> " + contoSorgenteCompleto;
            string promemoriaD = textDescrizioneOperazione.Text + "-> " + contoDestinazioneCompleto;

            // assegna il valori di inizializzazione base dei conti
            double DEBUG_vSorgente = lData.DEBUG_ValoreDefaultSorgente;
            double DEBUG_vDestinazione = DEBUG_vSorgente;


            // svuota le tabelle
            ClearDataGridView(ref dataGridViewSorgenteOperazione);
            ClearDataGridView(ref dataGridViewDestinazioneOperazione);


            //==================================================================
            // Compone le trasizioni sorgente
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaS;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = DEBUG_vSorgente.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // Aggiunge il sottoconto Cnt
            subOperazione[0] = promemoriaS + ":Cnt";
            subOperazione[1] = contoSorgenteCompleto + ":Cnt";
            subOperazione[2] = (DEBUG_vSorgente * 10).ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Cnt
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaS + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                subOperazione[1] = contoSorgenteCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i]; 
                subOperazione[2] = (DEBUG_vSorgente * (10 + i + 1)).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
            }

            // Aggiunge il sottoconto Dep
            subOperazione[0] = promemoriaS + ":Dep";
            subOperazione[1] = contoSorgenteCompleto + ":Dep";
            subOperazione[2] = (DEBUG_vSorgente * 20).ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Dep
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaS + ":Dep:Dep-" + lData.ContiMultipli[i];
                subOperazione[1] = contoSorgenteCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                subOperazione[2] = (DEBUG_vSorgente * (20 + i + 1)).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
            }


            //==================================================================
            // Compone le trasizioni sorgente destinazione
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaD;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // Aggiunge il sottoconto Cnt ...
            subOperazione[0] = promemoriaD + ":Cnt";
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = (DEBUG_vDestinazione * 10).ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Cnt
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaD + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                subOperazione[1] = contoDestinazioneCompleto;
                subOperazione[2] = (DEBUG_vDestinazione * (10 + i + 1)).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
            }

            // Aggiunge il Sottoconto Dep
            subOperazione[0] = promemoriaD + ":Dep";
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = (DEBUG_vDestinazione * 20).ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // aggiunge i sottoconti del gruppo Dep
            for (int i = 0; i < lData.ContiMultipli.Length; i++)
            {
                subOperazione[0] = promemoriaD + ":Dep:Dep-" + lData.ContiMultipli[i];
                subOperazione[1] = contoDestinazioneCompleto;
                subOperazione[2] = (DEBUG_vDestinazione * (20 + i + 1)).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
            }

            // Aggiorna i totalizzazori();
            AggiornaTotalizzatoriSorgente();
        }
        /// <summary>
        /// Operazione Zip:
        /// - Operazione 1: ZIP
        ///     - Preleva dal gruppo del conto sorgente
        ///     - Deposita nel conto base sorgente
        /// - Operazione 2: TOTALE    
        ///     - Preleva dal conto base sorgente
        ///     - deposita nel gruppo destinazione
        /// </summary>
        private void AggiornaOperazioneZip()
        {
           // estre il gruppo di sotto conti selezionati
            string contiSelezionati = comboBoxTipoSottocontiSorgente.Text;

            // definisce la stringa per la porzione di transizione
            string[] subOperazione = new string[3];

            // svuota le tabelle
            ClearDataGridView(ref dataGridViewSorgenteOperazione);
            ClearDataGridView(ref dataGridViewDestinazioneOperazione);

            // =============================================================================
            // - Operazione 1: ZIP
            //     - Preleva dal gruppo del conto sorgente
            //     - Deposita nel conto base sorgente
            // =============================================================================

            // compone i conti sorgente e destinazione
            string contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
            string contoDestinazioneCompleto = GetContoSorgente(SezioneConto.ContoCompleto);

            // compone promemoria base
            string promemoriaS = LData.ETipoOperazioneComplessa.ZIP.ToString() + " ->" + textNotaSorgente.Text + contoSorgenteCompleto;
            string promemoriaD = LData.ETipoOperazioneComplessa.ZIP.ToString() + " ->" + textNotaDestinazione.Text + contoDestinazioneCompleto;

            // assegna il valori di inizializzazione base dei conti
            double DEBUG_vSorgente = lData.DEBUG_ValoreDefaultSorgente;
            double DEBUG_vDestinazione = DEBUG_vSorgente;
            
            // Compone le trasizioni sorgente 1
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaS;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = DEBUG_vSorgente.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

            // aggiunge i sotto conti del gruppo Cnt se selezionati
            if ((contiSelezionati == "Cnt") || (contiSelezionati == "All"))
            {
                // Aggiunge il sottoconto Cnt
                subOperazione[0] = promemoriaS + ":Cnt";
                subOperazione[1] = contoSorgenteCompleto + ":Cnt";
                subOperazione[2] = (DEBUG_vSorgente * 10).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                // aggiunge i sottoconti del gruppo Cnt
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = promemoriaS + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoSorgenteCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[2] = (DEBUG_vSorgente * (10 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                }
            }

            // aggiunge i sotto conti del gruppo Dep se selezionati
            if ((contiSelezionati == "Dep") || (contiSelezionati == "All"))
            {
                // Aggiunge il sottoconto Dep
                subOperazione[0] = promemoriaS + ":Dep";
                subOperazione[1] = contoSorgenteCompleto + ":Dep";
                subOperazione[2] = (DEBUG_vSorgente * 20).ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                // aggiunge i sottoconti del gruppo Dep
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = promemoriaS + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoSorgenteCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[2] = (DEBUG_vSorgente * (20 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                }
            }
                        
            // Compone le trasizioni sorgente destinazione 1
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaD;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);



            // =============================================================================
            // - Operazione 2: TOTALE
            //     - Preleva nel conto base sorgente
            //     - Deposita nel conto destinazione
            // =============================================================================

            // compone i conti sorgente e destinazione
            contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
            contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);

            // compone promemoria base
            promemoriaS = LData.ETipoOperazioneComplessa.TOTALE.ToString() + " ->" + textNotaSorgente.Text + contoSorgenteCompleto;
            promemoriaD = LData.ETipoOperazioneComplessa.TOTALE.ToString() + " ->" + textNotaDestinazione.Text + contoDestinazioneCompleto;

            // assegna il valori di inizializzazione base dei conti
            DEBUG_vSorgente = lData.DEBUG_ValoreDefaultSorgente;
            DEBUG_vDestinazione = DEBUG_vSorgente;

            // Compone le trasizioni sorgente 2
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaS;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = DEBUG_vSorgente.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);


            // Compone le trasizioni sorgente destinazione 2
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaD;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);



            // Aggiorna i totalizzazori();
            AggiornaTotalizzatoriSorgente();
            AggiornaTotalizzatoriDestinazione();
        }
        /// <summary>
        /// Operazione Split:
        /// - Operazione 0: ZIP opzionale   
        ///     - Preleva dal gruppo del conto sorgente 
        ///     - Deposita nel conto sorgente base
        /// - Operazione 1: TOTALE   
        ///     - Preleva dal conto sorgente 
        ///     - deposita nel conto destinazione base
        /// - Operazione 2: SPLIT
        ///     - Preleva dal conto dal destinazione base
        ///     - Deposita nel gruppo del conto destinazione
        /// </summary>
        private void AggiornaOperazioneSplit(bool operazione0)
        {
            // estre il gruppo di sotto conti selezionati
            string contiSelezionatiS = comboBoxTipoSottocontiSorgente.Text;
            string contiSelezionatiD = comboBoxTipoSottocontiDestinazione.Text;

            // definisce la stringa per la porzione di transizione
            string[] subOperazione = new string[3];

            // svuota le tabelle
            ClearDataGridView(ref dataGridViewSorgenteOperazione);
            ClearDataGridView(ref dataGridViewDestinazioneOperazione);


            // Dischiara le variabili comuni
            // Conti sorgente e destinazione
            string contoSorgenteCompleto;
            string contoDestinazioneCompleto;

            // Promemoria base
            string promemoriaS = "";
            string promemoriaD = "";

            // Valori di inizializzazione base dei conti
            double DEBUG_vSorgente = 0;
            double DEBUG_vDestinazione = 0;



            // =============================================================================
            // - Operazione 0: ZIP opzionale
            //     - Preleva dal gruppo del conto sorgente
            //     - Deposita nel conto base sorgente
            // =============================================================================

            if (operazione0)
            {
                // compone i conti sorgente e destinazione
                contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
                contoDestinazioneCompleto = GetContoSorgente(SezioneConto.ContoCompleto);

                // compone promemoria base
                promemoriaS = LData.ETipoOperazioneComplessa.ZIP.ToString() + " ->" + textNotaSorgente.Text + contoSorgenteCompleto;
                promemoriaD = LData.ETipoOperazioneComplessa.ZIP.ToString() + " ->" + textNotaDestinazione.Text + contoDestinazioneCompleto;

                // assegna il valori di inizializzazione base dei conti
                DEBUG_vSorgente = lData.DEBUG_ValoreDefaultSorgente;
                DEBUG_vDestinazione = DEBUG_vSorgente;

                // Compone le trasizioni sorgente 1
                //==================================================================

                // Aggiunge il sottoconto base
                subOperazione[0] = promemoriaS;
                subOperazione[1] = contoSorgenteCompleto;
                subOperazione[2] = DEBUG_vSorgente.ToString();
                AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                // aggiunge i sotto conti del gruppo Cnt se selezionati
                if ((contiSelezionatiS == "Cnt") || (contiSelezionatiS == "All"))
                {
                    // Aggiunge il sottoconto Cnt
                    subOperazione[0] = promemoriaS + ":Cnt";
                    subOperazione[1] = contoSorgenteCompleto + ":Cnt";
                    subOperazione[2] = (DEBUG_vSorgente * 10).ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                    // aggiunge i sottoconti del gruppo Cnt
                    for (int i = 0; i < lData.ContiMultipli.Length; i++)
                    {
                        subOperazione[0] = promemoriaS + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                        subOperazione[1] = contoSorgenteCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                        subOperazione[2] = (DEBUG_vSorgente * (10 + i + 1)).ToString();
                        AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                    }
                }

                // aggiunge i sotto conti del gruppo Dep se selezionati
                if ((contiSelezionatiS == "Dep") || (contiSelezionatiS == "All"))
                {
                    // Aggiunge il sottoconto Dep
                    subOperazione[0] = promemoriaS + ":Dep";
                    subOperazione[1] = contoSorgenteCompleto + ":Dep";
                    subOperazione[2] = (DEBUG_vSorgente * 20).ToString();
                    AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);

                    // aggiunge i sottoconti del gruppo Dep
                    for (int i = 0; i < lData.ContiMultipli.Length; i++)
                    {
                        subOperazione[0] = promemoriaS + ":Dep:Dep-" + lData.ContiMultipli[i];
                        subOperazione[1] = contoSorgenteCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                        subOperazione[2] = (DEBUG_vSorgente * (20 + i + 1)).ToString();
                        AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);
                    }
                }

                // Compone le trasizioni sorgente destinazione 1
                //==================================================================

                // Aggiunge il sottoconto base
                subOperazione[0] = promemoriaD;
                subOperazione[1] = contoDestinazioneCompleto;
                subOperazione[2] = DEBUG_vDestinazione.ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            }

            // =============================================================================
            // - Operazione 1: TOTALE
            //     - Preleva nel conto sorgente
            //     - Deposita nel conto base destinazione
            // =============================================================================

            // compone i conti sorgente e destinazione
            contoSorgenteCompleto = GetContoSorgente(SezioneConto.ContoCompleto);
            contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);

            // compone promemoria base
            promemoriaS = LData.ETipoOperazioneComplessa.TOTALE.ToString() + " ->" + textNotaSorgente.Text + contoSorgenteCompleto;
            promemoriaD = LData.ETipoOperazioneComplessa.TOTALE.ToString() + " ->" + textNotaDestinazione.Text + contoDestinazioneCompleto;

            // assegna i valori di inizializzazione base dei conti
            DEBUG_vSorgente = lData.DEBUG_ValoreDefaultSorgente;
            DEBUG_vDestinazione = DEBUG_vSorgente;

            // Compone le trasizioni sorgente 1
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaS;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = DEBUG_vSorgente.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);


            // Compone le trasizioni sorgente destinazione 1
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaD;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);



            // =============================================================================
            // - Operazione 2: SPLIT
            //     - Preleva dal conto base destinazione
            //     - Deposita nel gruppo del conto base destinazione
            // =============================================================================

            // compone i conti sorgente e destinazione
            contoSorgenteCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);
            contoDestinazioneCompleto = GetContoDestinazione(SezioneConto.ContoCompleto);

            // compone promemoria base
            promemoriaS = LData.ETipoOperazioneComplessa.SPLIT.ToString() + " ->" + textNotaSorgente.Text + contoSorgenteCompleto;
            promemoriaD = LData.ETipoOperazioneComplessa.SPLIT.ToString() + " ->" + textNotaDestinazione.Text + contoDestinazioneCompleto;

            // assegna il valori di inizializzazione base dei conti
            DEBUG_vSorgente = lData.DEBUG_ValoreDefaultDestinazione;
            DEBUG_vDestinazione = DEBUG_vSorgente;

            // Compone le trasizioni sorgente  2
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaS;
            subOperazione[1] = contoSorgenteCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewSorgenteOperazione, subOperazione);


            // Compone le trasizioni destinazione 2
            //==================================================================

            // Aggiunge il sottoconto base
            subOperazione[0] = promemoriaD;
            subOperazione[1] = contoDestinazioneCompleto;
            subOperazione[2] = DEBUG_vDestinazione.ToString();
            AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

            // aggiunge i sotto conti del gruppo Cnt se selezionati
            if ((contiSelezionatiD == "Cnt") || (contiSelezionatiD == "All"))
            {
                // Aggiunge il sottoconto Cnt
                subOperazione[0] = promemoriaD + ":Cnt";
                subOperazione[1] = contoDestinazioneCompleto + ":Cnt";
                subOperazione[2] = (DEBUG_vDestinazione * 10).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

                // aggiunge i sottoconti del gruppo Cnt
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = promemoriaD + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoDestinazioneCompleto + ":Cnt:Cnt-" + lData.ContiMultipli[i];
                    subOperazione[2] = (DEBUG_vDestinazione * (10 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
                }
            }

            // aggiunge i sotto conti del gruppo Dep se selezionati
            if ((contiSelezionatiD == "Dep") || (contiSelezionatiD == "All"))
            {
                // Aggiunge il sottoconto Dep
                subOperazione[0] = promemoriaD + ":Dep";
                subOperazione[1] = contoDestinazioneCompleto + ":Dep";
                subOperazione[2] = (DEBUG_vDestinazione * 20).ToString();
                AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);

                // aggiunge i sottoconti del gruppo Dep
                for (int i = 0; i < lData.ContiMultipli.Length; i++)
                {
                    subOperazione[0] = promemoriaD + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[1] = contoDestinazioneCompleto + ":Dep:Dep-" + lData.ContiMultipli[i];
                    subOperazione[2] = (DEBUG_vDestinazione * (20 + i + 1)).ToString();
                    AddTransizione(ref dataGridViewDestinazioneOperazione, subOperazione);
                }
            }

            // Aggiorna i totalizzazori();
            AggiornaTotalizzatoriSorgente();
            AggiornaTotalizzatoriDestinazione();
        }
        /// <summary>
        /// Il valore di una cella sorgente è cambiato, viene ricalcolato il totale dei valori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSorgenteOperazione_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AggiornaTotalizzatoriSorgente();
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

            // aggiorna il delta valore rispetto al valore dell'operazione
            if (ConvertAG.IsDouble(textValoreOperazione.Text))
                textDeltaValoreSorgente.Text = (Convert.ToDouble(textValoreOperazione.Text) - totale).ToString();
            else
                textDeltaValoreSorgente.Text = "???";
        }
        /// <summary>
        /// Il valore di una cella destinazione è cambiato, viene ricalcolato il totale dei valori
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDestinazioneOperazione_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AggiornaTotalizzatoriDestinazione();
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
        /// Genera le trasisioni dalla tabella sorgente
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public uint GeneraTransizioniSorgente(ref DataGridView transactionDataGrid)
        {
            for (int i = 0; i < (dataGridViewSorgenteOperazione.Rows.Count - 1); i++)
            { 
                // crea la stringa campi
                string[] campi = new string[lData.NameColumnsTransition.Length];

                campi[0] = dateTimeOperazione.Text;                             //  0 "Data",
                campi[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];      //  1 "ID transazione",
                campi[2] = lData.FilteredCellValuesOfTheTrasizioneLine[2];      //  2 "Numero",

                campi[3] = "== € " + textValoreOperazione.Text + " == " + textDescrizioneOperazione.Text;  //  3 "Descrizione",

                campi[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campi[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campi[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campi[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",

                campi[8] = dataGridViewSorgenteOperazione.Rows[i].Cells[0].Value.ToString(); //  8 "Promemoria",
                campi[9] = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",

                string[] porzioniConto = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                campi[10] = porzioniConto[porzioniConto.Length - 1]; // 10 "Nome del conto",

                string valore = "-" + dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campi[11] = valoreSimb;                                         // 11 "Importo con Simb",
                campi[12] = valore;                                             // 12 "Importo Num.",
                campi[13] = valoreSimb;                                         // 13 "Valore con Simb",
                campi[14] = valore;                                             // 14 "Valore Num.",

                campi[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];    // 15 "Riconcilia",
                campi[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];    // 16 "Data di riconciliazione",
                campi[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];    // 17 "Tasso/Prezzo"


                // Assegna la trasizione generata    
                transactionDataGrid.Rows.Add(campi);
            }

            return 0;
        }
        /// <summary>
        /// Genera le trasisioni dalla tabella destinazione
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public uint GeneraTransizioniDestinazione(ref DataGridView transactionDataGrid)
        {
            for (int i = 0; i < (dataGridViewDestinazioneOperazione.Rows.Count - 1); i++)
            {
                // crea la stringa campi
                string[] campi = new string[lData.NameColumnsTransition.Length];


                campi[0] = dateTimeOperazione.Text;                             //  0 "Data",
                campi[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];      //  1 "ID transazione",
                campi[2] = lData.FilteredCellValuesOfTheTrasizioneLine[2];      //  2 "Numero",

                campi[3] = "== € " + textValoreOperazione.Text + " == " + textDescrizioneOperazione.Text;  //  3 "Descrizione",

                campi[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campi[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campi[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campi[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",

                campi[8] = dataGridViewDestinazioneOperazione.Rows[i].Cells[0].Value.ToString(); //  8 "Promemoria",
                campi[9] = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",

                string[] porzioniConto = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                campi[10] = porzioniConto[porzioniConto.Length - 1]; // 10 "Nome del conto",

                string valore = dataGridViewDestinazioneOperazione.Rows[i].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campi[11] = valoreSimb;                                         // 11 "Importo con Simb",
                campi[12] = valore;                                             // 12 "Importo Num.",
                campi[13] = valoreSimb;                                         // 13 "Valore con Simb",
                campi[14] = valore;                                             // 14 "Valore Num.",

                campi[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];    // 15 "Riconcilia",
                campi[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];    // 16 "Data di riconciliazione",
                campi[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];    // 17 "Tasso/Prezzo"

                // Assegna la trasizione generata    
                transactionDataGrid.Rows.Add(campi);
            }


            return 0;
        }
        /// <summary>
        /// Open genera un transizione per ogni conto:
        /// da conto sorgente
        /// a gruppo conti destinazione
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public uint GeneraTransizioniOpen(ref DataGridView transactionDataGrid)
        {
            // verifica che le tabelle sorgente e destinazione contengano lo stesso numero di transizioni
            int nTransizioniSorgente = dataGridViewSorgenteOperazione.Rows.Count - 1;
            int nTransizioniDestinazione = dataGridViewDestinazioneOperazione.Rows.Count - 1;
            if (nTransizioniSorgente != nTransizioniDestinazione)
                return 1001;

            // Recupera il numero dell'operazione
            int numOperazione = Convert.ToInt32(textNumOperazione.Text);

            for (int i = 0; i < (dataGridViewSorgenteOperazione.Rows.Count - 1); i++)
            {
                // crea la stringa campi
                string[] campiS = new string[lData.NameColumnsTransition.Length];
                string[] campiD = new string[lData.NameColumnsTransition.Length];

                campiS[0] = dateTimeOperazione.Text;                            //  0 "Data",
                campiD[0] = campiS[0];

                campiS[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];     //  1 "ID transazione",
                campiD[1] = campiS[1];

                campiS[2] = (numOperazione + i).ToString(); //lData.FilteredCellValuesOfTheTrasizioneLine[2];      //  2 "Numero",
                campiD[2] = campiS[2];

                campiS[3] = dataGridViewDestinazioneOperazione.Rows[i].Cells[0].Value.ToString();  //  3 "Descrizione",
                campiD[3] = campiS[3];

                campiS[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campiD[4] = campiS[4];

                campiS[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campiD[5] = campiS[5];

                campiS[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campiD[6] = campiS[6];

                campiS[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",
                campiD[7] = campiS[7];

                campiS[8] = dataGridViewSorgenteOperazione.Rows[i].Cells[0].Value.ToString(); //  8 "Promemoria",
                campiD[8] = dataGridViewDestinazioneOperazione.Rows[i].Cells[0].Value.ToString(); //  8 "Promemoria",

                campiS[9] = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",
                campiD[9] = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",


                string[] porzioniContoS = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                string[] porzioniContoD = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                campiS[10] = porzioniContoS[porzioniContoS.Length - 1]; // 10 "Nome del conto",
                campiD[10] = porzioniContoD[porzioniContoD.Length - 1]; // 10 "Nome del conto",

                string valore = dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campiS[11] = "-" + valoreSimb;                                   // 11 "Importo con Simb",
                campiD[11] = valoreSimb;                                         // 11 "Importo con Simb",

                campiS[12] = "-" + valore;                                       // 12 "Importo Num.",
                campiD[12] = valore;                                             // 12 "Importo Num.",

                campiS[13] = "-" + valoreSimb;                                   // 13 "Valore con Simb",
                campiD[13] = valoreSimb;                                         // 13 "Valore con Simb",

                campiS[14] = "-" + valore;                                       // 14 "Valore Num.",
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

            return 0;
        }
        /// <summary>
        /// Close genera un transizione per ogni conto
        /// da gruppo conti sorgente
        /// a conto destinazione
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public uint GeneraTransizioniClose(ref DataGridView transactionDataGrid)
        {
            // verifica che le tabelle sorgente e destinazione contengano lo stesso numero di transizioni
            int nTransizioniSorgente = dataGridViewSorgenteOperazione.Rows.Count - 1;
            int nTransizioniDestinazione = dataGridViewDestinazioneOperazione.Rows.Count - 1;
            if (nTransizioniSorgente != nTransizioniDestinazione)
                return 1001;

            // Recupera il numero dell'operazione
            int numOperazione = Convert.ToInt32(textNumOperazione.Text);

            for (int i = 0; i < (dataGridViewSorgenteOperazione.Rows.Count - 1); i++)
            {
                // crea la stringa campi
                string[] campiS = new string[lData.NameColumnsTransition.Length];
                string[] campiD = new string[lData.NameColumnsTransition.Length];

                campiS[0] = dateTimeOperazione.Text;                            //  0 "Data",
                campiD[0] = campiS[0];

                campiS[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];     //  1 "ID transazione",
                campiD[1] = campiS[1];

                campiS[2] = (numOperazione + i).ToString();                     //  2 "Numero",
                campiD[2] = campiS[2];

                campiS[3] = dataGridViewSorgenteOperazione.Rows[i].Cells[0].Value.ToString();  //  3 "Descrizione",
                campiD[3] = campiS[3];

                campiS[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",
                campiD[4] = campiS[4];

                campiS[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",
                campiD[5] = campiS[5];

                campiS[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",
                campiD[6] = campiS[6];

                campiS[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",
                campiD[7] = campiS[7];

                campiS[8] = dataGridViewSorgenteOperazione.Rows[i].Cells[0].Value.ToString(); //  8 "Promemoria",
                campiD[8] = dataGridViewDestinazioneOperazione.Rows[i].Cells[0].Value.ToString(); //  8 "Promemoria",

                campiS[9] = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",
                campiD[9] = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",


                string[] porzioniContoS = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                string[] porzioniContoD = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                campiS[10] = porzioniContoS[porzioniContoS.Length - 1]; // 10 "Nome del conto",
                campiD[10] = porzioniContoD[porzioniContoD.Length - 1]; // 10 "Nome del conto",

                string valore = dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campiS[11] = "-" + valoreSimb;                                   // 11 "Importo con Simb",
                campiD[11] = valoreSimb;                                         // 11 "Importo con Simb",

                campiS[12] = "-" + valore;                                       // 12 "Importo Num.",
                campiD[12] = valore;                                             // 12 "Importo Num.",

                campiS[13] = "-" + valoreSimb;                                   // 13 "Valore con Simb",
                campiD[13] = valoreSimb;                                         // 13 "Valore con Simb",

                campiS[14] = "-" + valore;                                       // 14 "Valore Num.",
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

            return 0;
        }
        /// <summary>
        /// Generara una tansizione Zip:
        /// - Operazione 1:
        ///     - Preleva dal gruppo del conto sorgente
        ///     - Deposita nel conto base sorgente
        /// - Operazione 2    
        ///     - Preleva dal conto base sorgente
        ///     - Deposita nel conto destinazione
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public uint GeneraTransizioniZip(ref DataGridView transactionDataGrid)
        {
             // compone nome operazione 1 e 2
            string nomeOperazione = " == " + textValoreOperazione.Text + " == " + textDescrizioneOperazione.Text;
            string nomeOperazione1 = LData.ETipoOperazioneComplessa.ZIP.ToString() + nomeOperazione;
            string nomeOperazione2 = LData.ETipoOperazioneComplessa.TOTALE.ToString() + nomeOperazione;

            // Assegna numero operazione 1 e 2
            int numeroOperazione1 = Convert.ToInt32(textNumOperazione.Text);
            int numeroOperazione2 = numeroOperazione1 + 1;

            // =============================================================================
            // - Fase 1:
            //     - Analizza operazioni 
            // =============================================================================
            GeneraTransizione(ref transactionDataGrid,
                              LData.ETipoOperazioneComplessa.ZIP.ToString(), 
                              nomeOperazione1, 
                              numeroOperazione1);

            GeneraTransizione(ref transactionDataGrid,
                              LData.ETipoOperazioneComplessa.TOTALE.ToString(), 
                              nomeOperazione2, 
                              numeroOperazione2);

            return 0;
        }
        /// <summary>
        /// Generara una tansizione Split:
        /// - Operazione 0:
        ///     - Preleva dal gruppo del conto base sorgente
        ///     - Deposita nel conto base sorgente
        /// - Operazione 1:    
        ///     - Preleva dal conto sorgente
        ///     - Peposita nel conto base destinazione
        /// - Operazione 2:
        ///     - Preleva dal conto base destinazione
        ///     - Deposita nel gruppo del conto destinazione
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <returns></returns>
        public uint GeneraTransizioniSplit(ref DataGridView transactionDataGrid)
        {
            // compone nome operazione 0, 1 e 2
            string nomeOperazione = " == " + textValoreOperazione.Text + " == " + textDescrizioneOperazione.Text;
            string nomeOperazione0 = LData.ETipoOperazioneComplessa.ZIP.ToString() + nomeOperazione;
            string nomeOperazione1 = LData.ETipoOperazioneComplessa.TOTALE.ToString() + nomeOperazione;
            string nomeOperazione2 = LData.ETipoOperazioneComplessa.SPLIT.ToString() + nomeOperazione;

            // Assegna numero operazione 1 e 2
            int numeroOperazione0 = Convert.ToInt32(textNumOperazione.Text);
            int numeroOperazione1 = numeroOperazione0 + 1;
            int numeroOperazione2 = numeroOperazione1 + 1;

            // =============================================================================
            // - Fase 1:
            //     - Analizza operazioni 
            // =============================================================================

            GeneraTransizione(ref transactionDataGrid,
                              LData.ETipoOperazioneComplessa.ZIP.ToString(),
                              nomeOperazione0,
                              numeroOperazione0);

            GeneraTransizione(ref transactionDataGrid,
                              LData.ETipoOperazioneComplessa.TOTALE.ToString(),
                              nomeOperazione1,
                              numeroOperazione1);

            GeneraTransizione(ref transactionDataGrid,
                              LData.ETipoOperazioneComplessa.SPLIT.ToString(),
                              nomeOperazione2,
                              numeroOperazione2);

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionDataGrid"></param>
        /// <param name="tipoOperazione"></param>
        /// <param name="nomeOperazione"></param>
        /// <param name="numeroOperazione"></param>
        /// <returns></returns>
        public uint GeneraTransizione( ref DataGridView transactionDataGrid, 
                                            string tipoOperazione, 
                                            string nomeOperazione, 
                                            int numeroOperazione)
        {
            // =============================================================================
            // - Fase 1:
            //     - Analizza operazioni sorgente
            // =============================================================================

            for (int i = 0; i < (dataGridViewSorgenteOperazione.Rows.Count - 1); i++)
            {
                // Scompone il nome dell'operazione
                string nomeOperazioneEsteso = dataGridViewSorgenteOperazione.Rows[i].Cells[0].Value.ToString();
                string[] campiNota = nomeOperazioneEsteso.Split(' ');
                // determina il tipo di operazione
                if (tipoOperazione != campiNota[0])
                    continue;

                // crea la stringa campi
                string[] campiS = new string[lData.NameColumnsTransition.Length];

                campiS[0] = dateTimeOperazione.Text;                            //  0 "Data",

                campiS[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];     //  1 "ID transazione",

                campiS[2] = numeroOperazione.ToString();                        //  2 "Numero"
                
                campiS[3] = nomeOperazione;                                     //  3 "Descrizione",

                campiS[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];      //  4 "Note",

                campiS[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];      //  5 "Commodity/Valuta",

                campiS[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];      //  6 "Motivo annullamento",

                campiS[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];      //  7 "Operazione",

                string[] campiNota2 = nomeOperazioneEsteso.Split('>');
                campiS[8] = campiNota2[1];                                       //  8 "Promemoria",

                campiS[9] = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",


                string[] porzioniContoS = dataGridViewSorgenteOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                campiS[10] = porzioniContoS[porzioniContoS.Length - 1]; // 10 "Nome del conto",

                string valore = dataGridViewSorgenteOperazione.Rows[i].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campiS[11] = "-" + valoreSimb;                                   // 11 "Importo con Simb",

                campiS[12] = "-" + valore;                                       // 12 "Importo Num.",

                campiS[13] = "-" + valoreSimb;                                   // 13 "Valore con Simb",

                campiS[14] = "-" + valore;                                       // 14 "Valore Num.",

                campiS[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];    // 15 "Riconcilia",

                campiS[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];    // 16 "Data di riconciliazione",

                campiS[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];    // 17 "Tasso/Prezzo"

                // Assegna le trasizioni generate    
                transactionDataGrid.Rows.Add(campiS);
            }

            // =============================================================================
            // - Fase 2:
            //     - Analizza operazioni destinazione
            // =============================================================================

            for (int i = 0; i < (dataGridViewDestinazioneOperazione.Rows.Count - 1); i++)
            {
                // Scompone il nome dell'operazione
                string nomeOperazioneEsteso = dataGridViewDestinazioneOperazione.Rows[i].Cells[0].Value.ToString();
                string[] campiNota = nomeOperazioneEsteso.Split(' ');
                // determina il tipo di operazione
                if (tipoOperazione != campiNota[0])
                    continue;

                // crea la stringa campi
                string[] campiD = new string[lData.NameColumnsTransition.Length];

                campiD[0] = dateTimeOperazione.Text;                                //  0 "Data",

                campiD[1] = lData.FilteredCellValuesOfTheTrasizioneLine[1];         //  1 "ID transazione",

                campiD[2] = numeroOperazione.ToString();                            //  2 "Numero"

                campiD[3] = nomeOperazione;                                         //  3 "Descrizione",

                campiD[4] = lData.FilteredCellValuesOfTheTrasizioneLine[4];         //  4 "Note",

                campiD[5] = lData.FilteredCellValuesOfTheTrasizioneLine[5];         //  5 "Commodity/Valuta",

                campiD[6] = lData.FilteredCellValuesOfTheTrasizioneLine[6];         //  6 "Motivo annullamento",

                campiD[7] = lData.FilteredCellValuesOfTheTrasizioneLine[7];         //  7 "Operazione",

                string[] campiNota2 = nomeOperazioneEsteso.Split('>');
                campiD[8] = campiNota2[1];                                          //  8 "Promemoria",

                campiD[9] = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString(); //  9 "Nome completo del conto",


                string[] porzioniContoS = dataGridViewDestinazioneOperazione.Rows[i].Cells[1].Value.ToString().Split(':');
                campiD[10] = porzioniContoS[porzioniContoS.Length - 1];             // 10 "Nome del conto",

                string valore = dataGridViewDestinazioneOperazione.Rows[i].Cells[2].Value.ToString();
                string valoreSimb = valore + " €";
                campiD[11] = valoreSimb;                                            // 11 "Importo con Simb",

                campiD[12] = valore;                                                // 12 "Importo Num.",

                campiD[13] = valoreSimb;                                            // 13 "Valore con Simb",

                campiD[14] = valore;                                                // 14 "Valore Num.",

                campiD[15] = lData.FilteredCellValuesOfTheTrasizioneLine[15];       // 15 "Riconcilia",

                campiD[16] = lData.FilteredCellValuesOfTheTrasizioneLine[16];       // 16 "Data di riconciliazione",

                campiD[17] = lData.FilteredCellValuesOfTheTrasizioneLine[17];       // 17 "Tasso/Prezzo"

                // Assegna le trasizioni generate    
                transactionDataGrid.Rows.Add(campiD);
            }

            return 0;
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
        /// <summary>
        /// Aggiorna in contemporaneamente i consi sorgente e destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAggiorna_Click(object sender, EventArgs e)
        {
            // recupera il tipo di operazione richiesta
            string TipoOperazione = comboBoxTipoOperazione.Text;


            // Esegue l'operazione richiesta
            switch (TipoOperazione)
            {
                case "Transition":
                    AggiornaSorgente();
                    AggiornaDestinazione();
                    break;

                case "Open":
                    AggiornaOperazioneOpen();
                    break;

                case "Close":
                    AggiornaOperazioneClose();
                    break;

                case "Split":
                    AggiornaOperazioneSplit(false);
                    break;

                case "Zip":
                    AggiornaOperazioneZip();
                    break;

                case "ZipSplit":
                    AggiornaOperazioneSplit(true);
                    break;

                default:
                    break;

            }
        }
        /// <summary>
        /// Svuota la tabella inidicata
        /// </summary>
        private void ClearDataGridView(ref DataGridView dataGrid)
        {
            int nRows = dataGrid.Rows.Count - 2;
            for (int i = nRows; i >= 0; i--)
            {
                dataGrid.Rows.RemoveAt(i);
            }

        }
        /// <summary>
        /// Verifica i cambi di una porzione di transazione
        /// </summary>
        /// <param name="subOperazione"></param>
        /// <returns>Rende 0 : se tutto va bene</returns>
        private uint VerificaSubTransazione(string[] subOperazione)
        {
            // verifica la dimensione della subOperazione
            if (subOperazione.Length != 3)
                return 1;

            // verifica suboperazione[0]: promemoria
            // =====================================
            if (subOperazione[0] == null)
                return 100;
            if (subOperazione[0].Length == 0)
                return 101;

            // verifica suboperazione[1]: nome del conto
            // =========================================
            if (subOperazione[1] == null)
                return 200;
            if (subOperazione[1].Length == 0)
                return 201;
            // verifica se il conto esiste
            bool find = false;
            foreach(string conto in lData.conti)
            {
                if (conto == subOperazione[1])
                {
                    find = true;
                    break;
                }
            }
            if (!find)
                return 202;


            // verifica suboperazione[2]: valore
            // =========================================
            if (subOperazione[1] == null)
                return 300;
            if (subOperazione[1].Length == 0)
                return 301;
            if (!ConvertAG.IsDouble(subOperazione[2]))
                return 302;



            // tutti i controlli sono andati a buon fine
            return 0;
        }
        /// <summary>
        /// Verifica la transazionee se non va a buon fine stampa un messaggio con l'esito dell'operazione
        /// </summary>
        /// <param name="subOperazione"></param>
        /// <returns></returns>
        private bool VerificaSubTransazioneMsg(string[] subOperazione)
        {
            uint result = VerificaSubTransazione(subOperazione);

            string DescrizioneErrore = "";


            if (result == 0)
                return true;
            else
            {
                switch (result)
                {
                    case 0:
                        return true;

                    case 1:
                        DescrizioneErrore = "La dimensione della subOperazione è errata.";
                        break;

                    case 100:
                        DescrizioneErrore = "Il campo suboperazione[0], Promemoria, non esiste.";
                        break;
                    case 101:
                        DescrizioneErrore = "Il campo suboperazione[0], Promemoria, è vuoto.";
                        break;

                    case 200:
                        DescrizioneErrore = "Il campo suboperazione[1], Conto, non esiste.";
                        break;
                    case 201:
                        DescrizioneErrore = "Il campo suboperazione[1], Conto, è vuoto.";
                        break;
                    case 202:
                        DescrizioneErrore = "Il campo suboperazione[1], Conto, continene un conto che NON è compreso nella lista dei conti.";
                        break;

                    case 300:
                        DescrizioneErrore = "Il campo suboperazione[2], Valore, non esiste.";
                        break;
                    case 301:
                        DescrizioneErrore = "Il campo suboperazione[2], Valore, è vuoto.";
                        break;
                    case 302:
                        DescrizioneErrore = "Il campo suboperazione[2], Valore, contiene un valore illecito.";
                        break;

                    default:
                        DescrizioneErrore = "Errore sconosciuto.";
                        break;
                }
            }

            // compone l'esito della verifica
            string titolo = "Errore nella transizione!";
            string messaggio =  "La verifica della trasizione : \n"+
                                "Suboperazione[0]:Promemoria: >" + subOperazione[0] + "<\n"+
                                "Suboperazione[1]:Conto: >" + subOperazione[1] + "<\n"+
                                "Suboperazione[2]:Valore: >" + subOperazione[2] + "<\n\n"+
                                "ha dato esito negativo : " + result.ToString() + "\n\n" +
                                DescrizioneErrore + "\n\n" +
                                "Cancelli la transizione?";

            //  stampa il messaggio con l'esito
            var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result3 == DialogResult.Yes)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Verifica la subOperazioni e se tutto va bene l'ha aggiunge alla tabella delle sub trasizioni
        /// </summary>
        /// <param name="dataGridView">Nome della tabella delle sun transazioni</param>
        /// <param name="subOperazione">SubOperazione</param>
        /// <param name="skipTest">Se TRUE non esegue il test, default = FALSE</param>
        /// <param name="RemoveValue0">Se TRUE non assegna le trasazioni con valore 0, default = FALSE</param>
        /// <returns></returns>
        private bool AddTransizione(ref DataGridView dataGridView, string[] subOperazione, bool skipTest = false, bool RemoveValue0 = false)
        {
            // verifica se i dati dalla transazione sono corretti
            if (VerificaSubTransazioneMsg(subOperazione))
            {
                dataGridView.Rows.Add(subOperazione);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Genera tutte le transizioni che formano un operazione 
        /// </summary>
        /// <param name="start"> = Inizia una nuova estrazione </param>
        /// <returns></returns>
        public uint GetTransiction(ref DataGridView transactionDataGrid)
        {
            // Estrae il tipo di operazione 
            string tipoDiOperazione = comboBoxTipoOperazione.Text;

            // Esegue l'operazione richiesta
            switch (tipoDiOperazione)
            {
                case "Transition":
                    // estrae le operazioni sorgente 
                    GeneraTransizioniSorgente(ref transactionDataGrid);
                    GeneraTransizioniDestinazione(ref transactionDataGrid);
                    break;
                case "Open":
                    GeneraTransizioniOpen(ref transactionDataGrid);
                    break;
                case "Close":
                    GeneraTransizioniClose(ref transactionDataGrid);
                    break;
                case "ZipSplit":
                case "Split":
                case "Zip":
                    GeneraTransizioniSplit(ref transactionDataGrid);
                    break;
                //case "Zip":
                    //GeneraTransizioniZip(ref transactionDataGrid);
                    //break;
                default:
                    break;
            }

            return 0;
        }

        private void comboBoxTipoOperazione_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Estrae il tipo di operazione  attiva
            string tipoDiOperazione = comboBoxTipoOperazione.Text;

            // Inizializza i campi in funzione del tipo di operazione
            switch (tipoDiOperazione)
            {
                case "Transition":
                    textDescrizioneOperazione.Text = "Transizione ";
                    textValoreOperazione.Text = "0";
                    textNumOperazione.Text = "1";
                    textNotaSorgente.Text = "Prelievo da  ";
                    textNotaDestinazione.Text = "Depositato in ";

                    butAggiornaSorgente.Enabled = true;
                    butAggiornaDestinazione.Enabled = true;

                    comboBoxTipoContiSorgente.SelectedIndex = 0;
                    comboBoxTipoContiDestinazione.SelectedIndex = 0;

                    comboBoxTipoSottocontiSorgente.SelectedIndex = 0;
                    break;

                case "Open":
                    textDescrizioneOperazione.Text = "Bilancio di apertura ";
                    textValoreOperazione.Text = "1";
                    textNumOperazione.Text = "80000";
                    textNotaSorgente.Text = "Prelievo da ";
                    textNotaDestinazione.Text = "Depositato in -> ";

                    butAggiornaSorgente.Enabled = false;
                    butAggiornaDestinazione.Enabled = false;

                    comboBoxTipoContiSorgente.SelectedIndex = 5;
                    comboBoxTipoContiDestinazione.SelectedIndex = 2;

                    comboBoxTipoSottocontiSorgente.SelectedIndex = 3;
                    break;

                case "Close":
                    textDescrizioneOperazione.Text = "Bilancio di chiusura ";
                    textValoreOperazione.Text = "1";
                    textNumOperazione.Text = "80000";
                    textNotaSorgente.Text = "Prelievo da ";
                    textNotaDestinazione.Text = "Depositato in ";

                    butAggiornaSorgente.Enabled = false;
                    butAggiornaDestinazione.Enabled = false;

                    comboBoxTipoContiSorgente.SelectedIndex = 2;
                    comboBoxTipoContiDestinazione.SelectedIndex = 6;

                    comboBoxTipoSottocontiSorgente.SelectedIndex = 3;
                    break;

                case "Split":
                    textDescrizioneOperazione.Text = "Operazione SPLIT ";
                    textValoreOperazione.Text = "1";
                    textNumOperazione.Text = "21000";
                    textNotaSorgente.Text = "Prelievo da ";
                    textNotaDestinazione.Text = "Depositato in ";

                    butAggiornaSorgente.Enabled = false;
                    butAggiornaDestinazione.Enabled = false;

                    comboBoxTipoContiSorgente.SelectedIndex = 2;
                    comboBoxTipoContiDestinazione.SelectedIndex = 2;

                    comboBoxTipoSottocontiSorgente.SelectedIndex = 0;
                    comboBoxTipoSottocontiDestinazione.SelectedIndex = 3;
                    break;

                case "Zip":
                    textDescrizioneOperazione.Text = "Operazione ZIP ";
                    textValoreOperazione.Text = "1";
                    textNumOperazione.Text = "20000";
                    textNotaSorgente.Text = "Prelievo da ";
                    textNotaDestinazione.Text = "Depositato in ";

                    butAggiornaSorgente.Enabled = false;
                    butAggiornaDestinazione.Enabled = false;

                    comboBoxTipoContiSorgente.SelectedIndex = 2;
                    comboBoxTipoContiDestinazione.SelectedIndex = 2;

                    comboBoxTipoSottocontiSorgente.SelectedIndex = 3;
                    comboBoxTipoSottocontiDestinazione.SelectedIndex = 0;
                    break;

                case "ZipSplit":
                    textDescrizioneOperazione.Text = "Operazione ZIP - SPLIT";
                    textValoreOperazione.Text = "1";
                    textNumOperazione.Text = "21000";
                    textNotaSorgente.Text = "Prelievo da ";
                    textNotaDestinazione.Text = "Depositato in ";

                    butAggiornaSorgente.Enabled = false;
                    butAggiornaDestinazione.Enabled = false;

                    comboBoxTipoContiSorgente.SelectedIndex = 2;
                    comboBoxTipoContiDestinazione.SelectedIndex = 2;

                    comboBoxTipoSottocontiSorgente.SelectedIndex = 3;
                    comboBoxTipoSottocontiDestinazione.SelectedIndex = 3;
                    break;


                default:
                    textDescrizioneOperazione.Text = ") ";
                    textValoreOperazione.Text = "0";
                    textNumOperazione.Text = "0";
                    textNotaSorgente.Text = "? ";
                    textNotaDestinazione.Text = "? ";

                    butAggiornaSorgente.Enabled = true;
                    butAggiornaDestinazione.Enabled = true;

                    comboBoxTipoContiSorgente.SelectedIndex = 0;
                    comboBoxTipoContiDestinazione.SelectedIndex = 0;
                    break;
            }
        }
        /// <summary>
        /// Aggiorna al combo box tipo dei conti
        /// </summary>
        private void AggiornaTipoConti(ref ComboBox comboBoxTipoConti, ref ComboBox comboBoxConti)
        {
            // azzera gli oggetti di visualizzazione
            comboBoxConti.Items.Clear();
            
            // Aggiorna la lista dei conti visualizzata
            switch (comboBoxTipoConti.SelectedItem)
            {
                case "All":
                    AggiornaTipoConto(ref comboBoxConti, lData.conti);
                    break;
                case "Attivita":
                    AggiornaTipoConto(ref comboBoxConti, lData.contiAttivita);
                    break;
                case "AttivitaBase":
                    AggiornaTipoConto(ref comboBoxConti, lData.contiAttivitaBase);
                    break;
                case "Capitali":
                    AggiornaTipoConto(ref comboBoxConti, lData.contiCapitali);
                    break;
                case "CapitaliBase":
                    AggiornaTipoConto(ref comboBoxConti, lData.contiCapitaliBase);
                    break;
                case "CapitaliBaseIniziale":
                    AggiornaTipoConto(ref comboBoxConti, lData.contiCapitaliBaseIniziale);
                    break;
                case "CapitaliBaseFinale":
                    AggiornaTipoConto(ref comboBoxConti, lData.contiCapitaliBaseFinale);
                    break;
                default:
                    AggiornaTipoConto(ref comboBoxConti, lData.conti);
                    break;
            }

        }
        /// <summary>
        /// Attiva la visualizzazione della lista di conti indicati
        /// </summary>
        /// <param name="conti"></param>
        private void AggiornaTipoConto(ref ComboBox comboBoxConti, List<string> conti)
        {
            // stampa e carica i conti sulla combo box 
            for (int i = 0; i < conti.Count; i++)
            {
                // carica i conti sulla combo box
                comboBoxConti.Items.Add(conti[i]);
            }
            if (conti.Count > 1)
                comboBoxConti.SelectedIndex = 0;
        }
        /// <summary>
        /// Al cambio della combo comboBoxTipoContiSorgente,
        /// aggiorna la comboBox comboBoxContoSorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipoContiSorgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaTipoConti(ref comboBoxTipoContiSorgente, ref comboBoxContoSorgente);
        }
        /// <summary>
        /// Al cambio della comboBox comboBoxTipoContiDestinazione,
        /// aggiorna la comboBox comboBoxContoDestinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipoContiDestinazione_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaTipoConti(ref comboBoxTipoContiDestinazione, ref comboBoxContoDestinazione);
        }
    }
}

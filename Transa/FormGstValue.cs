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
    public partial class FormGstValue : Form
    {
        /// <summary>
        /// Oggetto che contiene tutti i dati e le strutture comuni
        /// </summary>
        public LData lData;

        /// <summary>
        /// Identificatore colonne
        /// </summary>
        public enum ENomeColonne
        {
            Totale,         // 0                       
            TotaleSel,      // 1
            Radice,         // 2     
            Cnt,            // 3   
            CntFA,          // 4
            CntLC,          // 5
            CntGG,          // 6
            CntBG,          // 7
            CntCat,         // 8
            Dep,            // 9   
            DepFA,          // 10
            DepLC,          // 11
            DepGG,          // 12
            DepBG,          // 13
            DepCat          // 14
        };
        /// <summary>
        /// Nome colonne
        /// </summary>
        private string [] NomeColonne = 
        {
            "Totale",         // 0                       
            "TotaleSel",      // 1
            "@",              // 2
            "Cnt",            // 3   
            "Cnt-FA",         // 4
            "Cnt-LC",         // 5
            "Cnt-GG",         // 6
            "Cnt-BG",         // 7
            "Cnt-Cat",        // 8
            "Dep",            // 9   
            "Dep-FA",         // 10
            "Dep-LC",         // 11
            "Dep-GG",         // 12
            "Dep-BG",         // 13
            "Dep-Cat"         // 14
        };
        /// <summary>
        /// Costruttore
        /// </summary>
        public FormGstValue(ref LData rLdata)
        {
            lData = rLdata;

            InitializeComponent();
            Inizializza();
        }
        /// <summary>
        /// Inizializza Form custom
        /// </summary>
        private void Inizializza()
        {
            // inizilizza DataGrid
            InizializzaDataGrid(ref dataGridViewValoreConti, true, true);
            InizializzaDataGrid(ref dataGridViewSorgente, true, false);
            InizializzaDataGrid(ref dataGridViewDestinazione, false, true);

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
        private void InizializzaDataGrid(ref DataGridView dataGridView, bool src, bool dst)
        {
            // Configura le righe
            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            //dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.Red;
            //dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Yellow;
            //dataGridView.RowHeadersDefaultCellStyle.Font =
            //        new Font(dataGridView.Font, FontStyle.Bold);

            // configura le colonne
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView.Font, FontStyle.Bold);
            // aggiunge le colonne
            for (int i = 0; i < NomeColonne.Length; i++)
            {
                dataGridView.Columns.Add(NomeColonne[i], NomeColonne[i]);
            }

            // Configura le righe
            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.Red;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Yellow;
            dataGridView.RowHeadersDefaultCellStyle.Font =
                    new Font(dataGridView.Font, FontStyle.Bold);



            // aggiunge le righe sorgente e destinazione
            string[] valoriSorgente = new string[NomeColonne.Length];
            string[] valoriDestinazione = new string[NomeColonne.Length];
            for (int i = 1; i < NomeColonne.Length; i++)
            {
                valoriSorgente[i] = i.ToString();
                valoriDestinazione[i] = (10 + i).ToString();
            }
            int j = 0;
            if (src)
            {

                dataGridView.Rows.Add(valoriSorgente);
                dataGridView.Rows[j++].HeaderCell.Value = "Src";            }
            if (dst)
            {
                dataGridView.Rows.Add(valoriDestinazione);
                dataGridView.Rows[j].HeaderCell.Value = "Dst";  
            }
                

            // setta il nome delle righe
            //dataGridView.Rows[0].HeaderCell.Value = "Sorgente";
            //dataGridView.Rows[1].HeaderCell.Value = "Destinazione";


            // Setta il nome della riga
            //dataGridView.RowHeadersVisible = true;
            //dataGridView.Rows[0].HeaderCell.Style.BackColor = Color.Yellow;
            //dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            //dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.Yellow;
            //dataGridView.RowHeadersDefaultCellStyle.BackColor = Color.Red;
            //dataGridView.RowHeadersDefaultCellStyle.Font =
            //        new Font(dataGridView.Font, FontStyle.Bold);
            //dataGridView.RowsDefaultCellStyle.ForeColor = Color.Yellow;



            //dataGridView.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;
        }
        /// <summary>
        /// Analisi stringa sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalisiSorgente_Click(object sender, EventArgs e)
        {

            // Analisi stringa sorgente
            AnalisiStringa(textBoxInStringaSorgente.Text,
                            ref dataGridViewSorgente,
                            comboBoxTipoSottocontiSorgente.Text);

        }
        /// <summary>
        /// Analisi stringa destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalisiDestinazione_Click(object sender, EventArgs e)
        {
            // Analisi stringa destinazione
            AnalisiStringa(textBoxInStringaDestinazione.Text,
                            ref dataGridViewDestinazione,
                            comboBoxTipoSottocontiDestinazione.Text);
        }
        /// <summary>
        /// Analisi Stringa
        /// </summary>
        private void AnalisiStringa(string stringaIn, ref DataGridView dataGridView, string tipoSottoconto)
        {
            // analizza sottoconto attivo
            int colInizio = 0;
            int colFine = 0;
            AnalizzaSottocontoAttivo(tipoSottoconto, out colInizio, out colFine);

            // Prepara tabella
            InizializzaTabella(ref dataGridView, 0, colInizio, colFine);

            // scompone stringa
            string[] campi = stringaIn.Split('\t');

            // Assegna i valori alla cella
            int col;
            for (int i = 0; i < campi.Length; i++)
            {
                col = colInizio + i;
                if (col <= colFine)
                {
                    if (!TestResult(AggiornaCella(ref dataGridView, 0, col, campi[i], true), campi[i]))
                        break;
                }
                else
                {
                    if (!TestResult(LData.ETransaErrore.E0002_ValoreNonRichiesto, campi[i]))
                        break;
                    
                    if (!TestResult(AggiornaCella(ref dataGridView, 0, col, campi[i],false), campi[i]))
                        break;
                }

            }
            // Aggiorna i Totali
            AggiornaTotali(ref dataGridView, 0, colInizio, colFine);

        }
        /// <summary>
        /// Aggiorna il valore della cella specificata
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="valore"></param>
        /// <returns></returns>

        private LData.ETransaErrore AggiornaCella(ref DataGridView dataGridView, int row, int col, string valore, bool inRange)
        {
            // Verifica se la tabella esiste
            if (dataGridView == null)
                return LData.ETransaErrore.E1000_TabellaInesistente;
            // Verifica se la colonna esiste
            if ((dataGridView.Columns.Count <= col) || (col < 0))
                return LData.ETransaErrore.E1001_ColonnaTabellaFuoriLimiti;
            // Verifica se la riga esiste
            if ((dataGridView.Rows.Count <= row) || (row < 0))
                return LData.ETransaErrore.E1002_RigaTabellaFuoriLimiti;
            // Verifica se è un valore double
            if (!ConvertAG.IsDouble(valore))
                return LData.ETransaErrore.E2100_double_LaStringaNonContieneUnValoreDouble;

            // assegna il valore alla cella
            dataGridView.Rows[row].Cells[col].Value = valore;
            // colora la cella di verde
            if (inRange)
                dataGridView.Rows[row].Cells[col].Style.BackColor = Color.GreenYellow;
            else
                dataGridView.Rows[row].Cells[col].Style.BackColor = Color.Yellow;


            return LData.ETransaErrore.E0000_OK;
        }
        /// <summary>
        /// Testa il valore di un esito
        /// </summary>
        /// <returns></returns>
        private bool TestResult(LData.ETransaErrore result, string messaggio2 = "", bool stampaMessaggio = true)
        {
            // controlla l'esito del risultatao
            if (result != LData.ETransaErrore.E0000_OK)
            {
                if (stampaMessaggio)
                {
                    // compone l'esito della verifica
                    string titolo = "Errore!";
                    string messaggio = "La stringa >" + messaggio2 + "<\n\n" +
                                       "ha generato l'errore: \n\n" + 
                                       lData.RestultToSting(result) +  
                                        "\n\n" +
                                        "Continuo?";

                    //  stampa il messaggio con l'esito
                    var result3 = MessageBox.Show(messaggio, titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result3 == DialogResult.Yes)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Inizializza la tabella ponendo a 0 tutti i valore e colorandola opportunamente
        /// </summary>
        /// <param name="dataGridView"></param>
        private void InizializzaTabella (ref DataGridView dataGridView, int row, int colInizio, int colFine)
        {
            for (int j = 0; j < dataGridView.Rows[row].Cells.Count; j++)
            {
                // Azzera il valore della tabella
                dataGridView.Rows[row].Cells[j].Value = "0.00";
            }
            // Aggiorna il colore di sfondo della riga della tabella
            AggiornaColoreRigaTabella(ref dataGridView, row, colInizio, colFine);

            // aggiorna i valori totali delle tabelle coinvolte
            AggiornaTotali(ref dataGridView, row, colInizio, colFine);
        }
        /// <summary>
        /// Colora le caselle della riga della tabella in funzione del tipo di conto selezionato
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="row"></param>
        /// <param name="colInizio"></param>
        /// <param name="colFine"></param>
        private void AggiornaColoreRigaTabella(ref DataGridView dataGridView, int row, int colInizio, int colFine)
        {
            for (int j = 0; j < dataGridView.Rows[row].Cells.Count; j++)
            {
                // Cambia il colore di sfondo della tabella
                if ((j >= colInizio) && (j <= colFine))
                    dataGridView.Rows[row].Cells[j].Style.BackColor = Color.Yellow;
                else
                    dataGridView.Rows[row].Cells[j].Style.BackColor = Color.White;
            }
        }
        /// <summary>
        /// Calcola i totali di riga
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="colInizio"></param>
        /// <param name="colFine"></param>
        private void AggiornaTotali(ref DataGridView dataGridView, int row, int colInizio, int colFine)
        {
            double totale = 0;
            double totaleSel = 0;

            for (int j = 2; j < dataGridView.Rows[row].Cells.Count; j++)
            {
                // calcola il totale
                totale += ConvertAG.ToDouble0(dataGridView.Rows[row].Cells[j].Value.ToString()); 
 
                // calcola il totale selezionato
                if ((j >= colInizio) && (j <= colFine))
                    totaleSel += ConvertAG.ToDouble0(dataGridView.Rows[row].Cells[j].Value.ToString());
            }

            // Assegna i valori calcolati
            dataGridView.Rows[row].Cells[0].Value = totale.ToString();
            dataGridView.Rows[row].Cells[1].Value = totaleSel.ToString();

            // Assegna i colori delle celle
            if (totale == totaleSel)
                dataGridView.Rows[row].Cells[0].Style.BackColor = Color.LightGreen;
            else
                dataGridView.Rows[row].Cells[0].Style.BackColor = Color.LightPink;

            dataGridView.Rows[row].Cells[1].Style.BackColor = Color.LightGreen;
        }
        /// <summary>
        /// Cambio tipo sottoconto sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipoSottocontiSorgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaTipoSottoconto(ref dataGridViewSorgente, comboBoxTipoSottocontiSorgente.Text, 0);
        }
        /// <summary>
        /// Cambio tipo sottoconto destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTipoSottocontiDestinazione_SelectedIndexChanged(object sender, EventArgs e)
        {
            AggiornaTipoSottoconto(ref dataGridViewDestinazione, comboBoxTipoSottocontiDestinazione.Text, 1);
        }
        /// <summary>
        /// Agiorna il sottoconto attivo e le tabelle collegate
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="tipoSottoconto"></param>
        private void AggiornaTipoSottoconto(ref DataGridView dataGridView, string tipoSottoconto, int row)
        {
            // analizza sottoconto attivo
            int colInizio = 0;
            int colFine = 0;
            AnalizzaSottocontoAttivo(tipoSottoconto, out colInizio, out colFine);

            // Aggiorna il colore di sfondo della riga della tabella
            AggiornaColoreRigaTabella(ref dataGridView, 0, colInizio, colFine);
            AggiornaColoreRigaTabella(ref dataGridViewValoreConti, row, colInizio, colFine);

            // aggiorna i valori totali delle tabelle coinvolte
            AggiornaTotali(ref dataGridView, 0, colInizio, colFine);
            AggiornaTotali(ref dataGridViewValoreConti, row, colInizio, colFine);

        }
        /// <summary>
        /// Estrae il tipo di sottoconto attivo.
        /// Rente il valore della colonna iniziale e finale in cui è attivo
        /// </summary>
        private void AnalizzaSottocontoAttivo(string tipoSottoconto, out int colInizio, out int colFine)
        {
            // dichiara l'indice delle colonne su cui bisogna operare
            colInizio = 0;
            colFine = 0;

            // estrae il tipo di sottoconto attivo
            switch (tipoSottoconto)
            {
                case "Single":
                    colInizio = 2;
                    colFine = 2;
                    break;

                case "Cnt":
                    colInizio = 3;
                    colFine = 8;
                    break;

                case "Dep":
                    colInizio = 9;
                    colFine = 14;
                    break;

                case "All":
                    colInizio = 2;
                    colFine = 14;
                    break;

                default:
                    colInizio = 2;
                    colFine = 2;
                    break;
            }

        }
        /// <summary>
        /// Azzera l'area sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAzzeraSorgente_Click(object sender, EventArgs e)
        {
            // Azzera area sorgente
            Azzera(true);
        }
        /// <summary>
        /// /// Azzera l'area destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAzzeraDestinazione_Click(object sender, EventArgs e)
        {
            // Azzera area destinazione
            Azzera(false);
        }
        /// <summary>
        /// Azzera l'area indicata
        /// </summary>
        /// <param name="sorgente"></param>
        private void Azzera(bool sorgente, bool azzeraTabConti = false)
        {
            // seleziona gli oggetti su cui operare
            DataGridView dataGridView;
            string tipoSottoconto = "";
            int row;
            if (sorgente)
            {
                dataGridView = dataGridViewSorgente;
                tipoSottoconto = comboBoxTipoSottocontiSorgente.Text;
                textBoxInStringaSorgente.Text = "";
                row = 0;
            }
            else
            {
                dataGridView = dataGridViewDestinazione;
                tipoSottoconto = comboBoxTipoSottocontiDestinazione.Text;
                textBoxInStringaDestinazione.Text = "";
                row = 1;
            }

            // analizza sottoconto attivo
            int colInizio = 0;
            int colFine = 0;
            AnalizzaSottocontoAttivo(tipoSottoconto, out colInizio, out colFine);

            // Azzera la tabella
            InizializzaTabella(ref dataGridView, 0, colInizio, colFine);

            // Azzera la tabella dei conti
            if (azzeraTabConti)
            {
                InizializzaTabella(ref dataGridViewValoreConti, row, colInizio, colFine);
            }


        }
        /// <summary>
        /// Azzera tutte le aree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAzzeraTuttoSorgente_Click(object sender, EventArgs e)
        {
            AzzeraTutto();
        }
        /// <summary>
        /// Azzera tutte le aree
        /// </summary>
        private void AzzeraTutto()
        {
            // Azzera area sorgente
            Azzera(true, true);
            // Azzera area destinazione
            Azzera(false, true);
        }
        /// <summary>
        /// Assegna valori selezionati sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegnaSorgente_Click(object sender, EventArgs e)
        {
            AssegnaStringa(0, ref dataGridViewSorgente, comboBoxTipoSottocontiSorgente.Text, false);
        }
        /// <summary>
        /// Assegna tutti i valori sorgente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegnaTuttoSorgente_Click(object sender, EventArgs e)
        {
            AssegnaStringa(0, ref dataGridViewSorgente, comboBoxTipoSottocontiSorgente.Text, true);
        }
        /// <summary>
        /// Assegna valori selezionati destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegnaDestinazione_Click(object sender, EventArgs e)
        {
            AssegnaStringa(1, ref dataGridViewDestinazione, comboBoxTipoSottocontiDestinazione.Text, false);
        }
        /// <summary>
        /// Assegna tutti i valori destinazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAssegnaTuttoDestinazione_Click(object sender, EventArgs e)
        {
            AssegnaStringa(1, ref dataGridViewDestinazione, comboBoxTipoSottocontiDestinazione.Text, true);
        }
        /// <summary>
        /// Assegna i valori impostati
        /// </summary>
        private void AssegnaStringa(int row, ref DataGridView dataGridView, string tipoSottoconto, bool assegnaTutto)
        {
            // analizza sottoconto attivo
            int colInizio = 0;
            int colFine = 0;
            AnalizzaSottocontoAttivo(tipoSottoconto, out colInizio, out colFine);

            // Prepara tabella
            //InizializzaTabella(ref dataGridView, row, colInizio, colFine);

            // Assegna i valori delle celle
            string valore;
            bool inRange;
            for (int i = 2; i < dataGridViewValoreConti.Columns.Count; i++)
            {
                // estra il valore dalla cella della tabella SRC
                valore = dataGridView.Rows[0].Cells[i].Value.ToString();

                // controlla se il valore è nel range dei conti selezionati
                inRange = ((i >= colInizio) && (i <= colFine));

                if (inRange || assegnaTutto)
                {
                    if (!TestResult(AggiornaCella(ref dataGridViewValoreConti, row, i, valore, inRange), valore))
                        break;
                }
            }
            // Aggiorna i Totali
            AggiornaTotali(ref dataGridViewValoreConti, row, colInizio, colFine);

        }

    }
}

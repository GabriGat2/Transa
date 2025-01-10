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
    public partial class FormMain : Form
    {
        public LData lData = new LData();

        /// <summary>
        /// Tabella transizioni completa
        /// </summary>
        private DataGridView transactionDataGridView = new DataGridView();
        /// <summary>
        /// Costruttore
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            SetupDataGridView();
            PopulateDataGridView();

        }
        private void SetText(string text)
        {
            char[] charSeparators = new char[] { ',' };
            string[] stringhe = text.Split(charSeparators);
            //textBox1.Text = stringhe.Length.ToString();
            //richTextBox1.Text = text;
        }
        /// <summary>
        /// Assegna il nome delle colonne alla tabella delle transizioni
        /// </summary>
        /// <param name="text"></param>
        private void AssegnaNomeColonne(string text)
        {
            // separa i cmapi della stringa
            char[] charSeparators = new char[] { ',' };
            string[] nomeColonna = text.Split(charSeparators);
            //textBox1.Text = nomeColonna.Length.ToString();
            //richTextBox1.Text = text;

            // stampa i nomi della colonna
            for (int i = 0; i < 18; i++)
            {
                if (i < nomeColonna.Length)
                    transactionDataGridView.Columns[i].Name = i.ToString() + ":" + nomeColonna[i];
            }

        }
        /// <summary>
        /// decodifica e stampa una riga nella tabella delle trasizioni
        /// </summary>
        /// <param name="text"></param>
        private void StampaNuovaRiga(string text)
        {
            // separa i cmapi della stringa
            char[] charSeparators = new char[] { '"' };
            
            // loop di ricerca
            string[] campiRiga = new string[60];
            int inizio = 0;
            //int fine = 0;
            int cntToken = 0;
            char carPre = '!';
            char car;
            char carPost;
            int stato = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0)
                    carPre = text.ElementAt(i - 1);
                car = text.ElementAt(i);
                if (i < (text.Length - 1))
                    carPost = text.ElementAt(i + 1);

                
                switch (stato)
                {
                    case 0:
                        // se arriva qui significa che è attiva la ricerca di doppi apici " e della virgola
                        if (text.ElementAt(i) == ',')
                        {
                            // ha trovato la virgola, estrae il token
                            campiRiga[cntToken] = text.Substring(inizio, i - inizio);
                            cntToken++;
                            inizio = i + 1;
                        }
                        else if (text.ElementAt(i) == '"')
                        {
                            inizio = i + 1;
                            stato = 1;
                        }
                        break;

                    case 1:
                        // se arriva qui significa che è attiva la ricerca di doppi apici " si chiusura, la virgola è ignorata
                        if (text.ElementAt(i) == '"')
                        {
                            campiRiga[cntToken] = text.Substring(inizio, i - inizio);
                            stato = 2;
                        }
                        break;

                    case 2:
                        // se arriva deve trovare la virgola che segue i doppi apichi di chiusura
                        if (text.ElementAt(i) != ',')
                        {
                            campiRiga[cntToken] += " ### FAILED";
                        }
                        cntToken++;
                        inizio = i + 1;
                        stato = 0;
                        break;
                }

            }
            // estrae l'ultimo token


            transactionDataGridView.Rows.Add(campiRiga);

        }



        private void songsDataGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.transactionDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Configura la tabella delle trasizioni
        /// </summary>
        private void SetupDataGridView()
        {
            //this.Controls.Add(songsDataGridView);
            //this.panel1.Controls.Add(songsDataGridView);
            this.splitContainer1.Panel1.Controls.Add(transactionDataGridView);

            transactionDataGridView.ColumnCount = 18;

            transactionDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            transactionDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            transactionDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(transactionDataGridView.Font, FontStyle.Bold);

            transactionDataGridView.Name = "songsDataGridView";
            transactionDataGridView.Location = new Point(8, 8);
            transactionDataGridView.Size = new Size(500, 250);
            transactionDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            transactionDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            transactionDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            transactionDataGridView.GridColor = Color.Black;
            transactionDataGridView.RowHeadersVisible = false;

            transactionDataGridView.Columns[0].Name = "c1";
            transactionDataGridView.Columns[1].Name = "C2";
            transactionDataGridView.Columns[2].Name = "C3";
            transactionDataGridView.Columns[3].Name = "C4";
            transactionDataGridView.Columns[4].Name = "C5";
            transactionDataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(transactionDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            transactionDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            transactionDataGridView.MultiSelect = false;
            transactionDataGridView.Dock = DockStyle.Fill;

            transactionDataGridView.CellFormatting += new
                DataGridViewCellFormattingEventHandler(songsDataGridView_CellFormatting);

            transactionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //transactionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            transactionDataGridView.ScrollBars = ScrollBars.Both;
        }
        /// <summary>
        /// Popola la tabella delle transizioni
        /// </summary>
        private void PopulateDataGridView()
        {

            //string[] row0 = { "11/22/1968", "29", "Revolution 9",
            //"Beatles", "The Beatles [White Album]" };
            //string[] row1 = { "1960", "6", "Fools Rush In",
            //"Frank Sinatra", "Nice 'N' Easy" };
            //string[] row2 = { "11/11/1971", "1", "One of These Days",
            //"Pink Floyd", "Meddle" };
            //string[] row3 = { "1988", "7", "Where Is My Mind?",
            //"Pixies", "Surfer Rosa" };
            //string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            //"Cramps", "Psychedelic Jungle" };
            //string[] row5 = { "6/10/2003", "13",
            //"Scatterbrain. (As Dead As Leaves.)",
            //"Radiohead", "Hail to the Thief" };
            //string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            //songsDataGridView.Rows.Add(row0);
            //songsDataGridView.Rows.Add(row1);
            //songsDataGridView.Rows.Add(row2);
            //songsDataGridView.Rows.Add(row3);
            //songsDataGridView.Rows.Add(row4);
            //songsDataGridView.Rows.Add(row5);
            //songsDataGridView.Rows.Add(row6);

            //songsDataGridView.Columns[0].DisplayIndex = 3;
            //songsDataGridView.Columns[1].DisplayIndex = 4;
            //songsDataGridView.Columns[2].DisplayIndex = 0;
            //songsDataGridView.Columns[3].DisplayIndex = 1;
            //songsDataGridView.Columns[4].DisplayIndex = 2;
        }
        /// <summary>
        /// Apre un file transizione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);

                    //SetText(sr.ReadToEnd());

                    // Legge la prima riga con i nomi delle colonne
                    AssegnaNomeColonne(sr.ReadLine());

                    bool run = true;
                    string line;
                    while (run)
                    {
                        line = sr.ReadLine();
                        if (line == null)
                            run = false;
                        else
                            StampaNuovaRiga(line);
                        //run = false;
                    }


                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

            }

        }
        /// <summary>
        /// Aggiunge una riga alla tabelle delle transizioni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAddRow_Click(object sender, EventArgs e)
        {
            this.transactionDataGridView.Rows.Add();
        }
        /// <summary>
        /// Cancella una riga dalla tabella delle transizioni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDeleteRow_Click(object sender, EventArgs e)
        {
            if (this.transactionDataGridView.SelectedRows.Count > 0 &&
                this.transactionDataGridView.SelectedRows[0].Index !=
                this.transactionDataGridView.Rows.Count - 1)
            {
                this.transactionDataGridView.Rows.RemoveAt(
                    this.transactionDataGridView.SelectedRows[0].Index);
            }
        }
        /// <summary>
        /// Salva le transizione nel file specificato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSaveFile_Click(object sender, EventArgs e)
        {
            //Stream myStream;
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string fileName = saveFileDialog1.InitialDirectory;

                
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    outputFile.WriteLine(CodingOfTableOperationsTitle());

                    for (int i = 0; i < (transactionDataGridView.Rows.Count - 1); i++)
                    {
                        string line = CodingOfTableOperationsLine(i);
                        outputFile.WriteLine(line);
                    }
                }


                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                //    // Code to write the stream goes here.
                //    myStream.Write()

                //    myStream.Close();
                //}
            }
        }
        /// <summary>
        /// Codifica la riga della tabella trasizioni indicata
        /// </summary>
        /// <param name="row"></param>
        /// <returns> </returns>
        private string CodingOfTableOperationsLine(int row)
        {
            string line = "";

            // controla se deve filtare il valore del campo
            for (int i = 0; i < transactionDataGridView.Columns.Count; i++)
            {
                // assegna il carattere di incapsulamento iniziale
                switch (lData.EncapsulationCharacterOfATransitionField[i])
                {
                    case '"':
                        line += '"';
                        break;
                    default:
                        break;
                }

                // assegna il campo della tabella    
                line += transactionDataGridView.Rows[row].Cells[i].Value;

                // assegna il carattere di incapsulamento finale
                switch (lData.EncapsulationCharacterOfATransitionField[i])
                {
                    case '"':
                        line += '"';
                        break;
                    default:
                        break;
                }

                // se non è l'ultimo campo aggiunge il separatore virgola ','
                if (i < (transactionDataGridView.Columns.Count - 1))
                    line += ',';
            }

            return line;    
        }
        /// <summary>
        /// Codifica i titoli della tabella trasizioni 
        /// </summary>
        /// <returns></returns>
        private string CodingOfTableOperationsTitle()
        {
            string line = "";

            int len = lData.NameColumnsTransition.Length;


            for (int i = 0; i < lData.NameColumnsTransition.Length; i++)
            {
                // assegna il campo della tabella    
                line += lData.NameColumnsTransition[i]; 

                // se non è l'ultimo campo aggiunge il separatore virgola ','
                if (i < (lData.NameColumnsTransition.Length - 1))
                    line += ',';
            }

            return line;    


        }
        /// <summary>
        /// Apre la dialog per creare una nuova operazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butNewOperation_Click(object sender, EventArgs e)
        {
            FormNewOperation dlg = new FormNewOperation(ref lData);

            //int cnt = 0;
            //bool run = true;
            //while (run)
            //{ 
                // crea la nuova operazione
                dlg.ShowDialog();
            //    run = --cnt > 0;
            //}

            // Svuota la tabelle delle transizioni
            int nRows = transactionDataGridView.Rows.Count - 2;
            for (int i = nRows; i >= 0; i--)
            {
                transactionDataGridView.Rows.RemoveAt(i);
            }

            // rigenera la tabella delle transizioni
            RigeneratransactionDataGridView();

            // Estre le trasizioni dell'operazione
            dlg.GetTransiction(ref transactionDataGridView);
        }

        /// <summary>
        /// Rigenera la tabella delle transizioni
        /// </summary>
        private void RigeneratransactionDataGridView()
        {
            // Svuota la tabelle delle transizioni
            int nRows = transactionDataGridView.Rows.Count - 2;
            for (int i = nRows; i >= 0; i--)
            {
                transactionDataGridView.Rows.RemoveAt(i);
            }


            // stampa i nomi della colonna
            for (int i = 0; i < lData.NameColumnsTransition.Length; i++)
            {
                transactionDataGridView.Columns[i].Name = i.ToString() + ":" + lData.NameColumnsTransition[i];
            }

        }
        /// <summary>
        /// Apre la dialog per la gestione della struttura dei conti
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAccounts_Click(object sender, EventArgs e)
        {
            // Dichiara la dialog per la gestione delle strutture dei conti
            // assegnadogli il riferimento all'oggetto lDati
            FormGstStrConti dlg = new FormGstStrConti(ref lData);

            // Mostra la dialog
            dlg.Show();



        }

        private void butTest_Click(object sender, EventArgs e)
        {
            FormGstValue dlg = new FormGstValue();
            dlg.ShowDialog();
        }
    }
}

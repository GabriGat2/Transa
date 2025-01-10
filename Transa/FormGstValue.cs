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
        /// Identificatore colonne
        /// </summary>
        public enum ENomeColonne
        {
            Delta,          // 0                       
            Totale,         // 1               
            Cnt,            // 2   
            CntFA,          // 3
            CntLC,          // 4
            CntGG,          // 5
            CntBG,          // 6
            CntCat,         // 7
            Dep,            // 2   
            DepFA,          // 3
            DepLC,          // 4
            DepGG,          // 5
            DepBG,          // 6
            DepCat          // 7
        };
        /// <summary>
        /// Nome colonne
        /// </summary>
        private string [] NomeColonne = 
        {
            "Delta",          // 0                       
            "Totale",         // 1               
            "Cnt",            // 2   
            "Cnt-FA",          // 3
            "Cnt-LC",          // 4
            "Cnt-GG",          // 5
            "Cnt-BG",          // 6
            "Cnt-Cat",         // 7
            "Dep",            // 2   
            "Dep-FA",          // 3
            "Dep-LC",          // 4
            "Dep-GG",          // 5
            "Dep-BG",          // 6
            "Dep-Cat"          // 7
        };

        /// <summary>
        /// Costruttore
        /// </summary>
        public FormGstValue()
        {
            InitializeComponent();
            Inizializza();
        }
        /// <summary>
        /// Inizializza Form custom
        /// </summary>
        private void Inizializza()
        {
            InizializzaDataGrid(ref dataGridViewValoreConti, true, true);
            InizializzaDataGrid(ref dataGridViewSorgente, true, false);
            InizializzaDataGrid(ref dataGridViewDestinazione, false, true);

            //// Configura le righe
            //dataGridViewValoreConti.RowHeadersVisible = true;
            //dataGridViewValoreConti.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            ////dataGridViewValoreConti.RowHeadersDefaultCellStyle.ForeColor = Color.Red;
            ////dataGridViewValoreConti.RowHeadersDefaultCellStyle.BackColor = Color.Yellow;
            ////dataGridViewValoreConti.RowHeadersDefaultCellStyle.Font =
            ////        new Font(dataGridViewValoreConti.Font, FontStyle.Bold);

            //// configura le colonne
            //dataGridViewValoreConti.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
            //dataGridViewValoreConti.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
            //dataGridViewValoreConti.ColumnHeadersDefaultCellStyle.Font =
            //    new Font(dataGridViewValoreConti.Font, FontStyle.Bold);
            //// aggiunge le colonne
            //for (int i = 0; i < NomeColonne.Length; i++)
            //{
            //    dataGridViewValoreConti.Columns.Add(NomeColonne[i], NomeColonne[i]);
            //}

            //// Configura le righe
            //dataGridViewValoreConti.RowHeadersVisible = true;
            //dataGridViewValoreConti.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            //dataGridViewValoreConti.RowHeadersDefaultCellStyle.ForeColor = Color.Red;
            //dataGridViewValoreConti.RowHeadersDefaultCellStyle.BackColor = Color.Yellow;
            //dataGridViewValoreConti.RowHeadersDefaultCellStyle.Font =
            //        new Font(dataGridViewValoreConti.Font, FontStyle.Bold);


          
            //// aggiunge le righe sorgente e destinazione
            //string[] valoriSorgente = new string[NomeColonne.Length];
            //string[] valoriDestinazione = new string[NomeColonne.Length];
            //for (int i = 1; i < NomeColonne.Length; i++)
            //{
            //    valoriSorgente[i] = i.ToString();
            //    valoriDestinazione[i] = (10 + i).ToString();
            //}
            //dataGridViewValoreConti.Rows.Add(valoriSorgente);
            //dataGridViewValoreConti.Rows.Add(valoriDestinazione);

            //// setta il nome delle righe
            //dataGridViewValoreConti.Rows[0].HeaderCell.Value = "Sorgente";
            //dataGridViewValoreConti.Rows[1].HeaderCell.Value = "Destinazione";


            //// Setta il nome della riga
            ////dataGridViewValoreConti.RowHeadersVisible = true;
            ////dataGridViewValoreConti.Rows[0].HeaderCell.Style.BackColor = Color.Yellow;
            ////dataGridViewValoreConti.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            ////dataGridViewValoreConti.RowHeadersDefaultCellStyle.ForeColor = Color.Yellow;
            ////dataGridViewValoreConti.RowHeadersDefaultCellStyle.BackColor = Color.Red;
            ////dataGridViewValoreConti.RowHeadersDefaultCellStyle.Font =
            ////        new Font(dataGridViewValoreConti.Font, FontStyle.Bold);
            ////dataGridViewValoreConti.RowsDefaultCellStyle.ForeColor = Color.Yellow;



            ////dataGridViewValoreConti.Rows[0].DefaultCellStyle.BackColor = Color.Yellow;
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
        /// Analisi stringa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAnalisi_Click(object sender, EventArgs e)
        {
            string stringa = textBoxInStringaSorgente.Text;
            richTextBoxOut.AppendText(stringa);
            richTextBoxOut.AppendText("\n");
            richTextBoxOut.AppendText("\n");

            for (int i = 0; i < stringa.Length; i++)
            {
                UInt16 numero = Convert.ToUInt16(stringa[i]);
                richTextBoxOut.AppendText(numero.ToString());
                richTextBoxOut.AppendText("\n");
            }

            // decodifica stringa
            string[] campi = stringa.Split('\t');

            //int k = 1;
            //if (campi.Length >= k)
            //    textBoxCampo1.Text = campi[k-1];

            // k++;
            //if (campi.Length >= k)
            //    textBoxCampo2.Text = campi[k-1];

            //k++;
            //if (campi.Length >= k)
            //    textBoxCampo3.Text = campi[k-1];

            //k++;
            //if (campi.Length >= k)
            //    textBoxCampo4.Text = campi[k-1];
        }
    }
}

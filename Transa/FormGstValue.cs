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
        public FormGstValue()
        {
            InitializeComponent();
        }

        private void butAnalisi_Click(object sender, EventArgs e)
        {
            string stringa = textBoxInStringa.Text;
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

            int k = 1;
            if (campi.Length >= k)
                textBoxCampo1.Text = campi[k-1];

             k++;
            if (campi.Length >= k)
                textBoxCampo2.Text = campi[k-1];

            k++;
            if (campi.Length >= k)
                textBoxCampo3.Text = campi[k-1];

            k++;
            if (campi.Length >= k)
                textBoxCampo4.Text = campi[k-1];
        }
    }
}

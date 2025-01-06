
namespace Transa
{
    partial class FormNewOperation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textDescrizioneOperazione = new System.Windows.Forms.TextBox();
            this.textValoreOperazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateTimeOperazione = new System.Windows.Forms.DateTimePicker();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.comboBoxTipoOperazione = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.comboBoxContoSorgente = new System.Windows.Forms.ComboBox();
            this.textDeltaValoreSorgente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textTotaleValoreSorgente = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxTipoSottocontiSorgente = new System.Windows.Forms.ComboBox();
            this.radioOperazioneSorgenteMultipla = new System.Windows.Forms.RadioButton();
            this.butAggiornaSorgente = new System.Windows.Forms.Button();
            this.textNotaSorgente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewSorgenteOperazione = new System.Windows.Forms.DataGridView();
            this.ColNotaSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContoSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValoreSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.comboBoxContoDestinazione = new System.Windows.Forms.ComboBox();
            this.textDeltaValoreDestinazione = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.radioOperazioneDestinazioneMultipla = new System.Windows.Forms.RadioButton();
            this.textTotaleValoreDestinazione = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxTipoSottocontiDestinazione = new System.Windows.Forms.ComboBox();
            this.butAggiornaDestinazione = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textNotaDestinazione = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewDestinazioneOperazione = new System.Windows.Forms.DataGridView();
            this.ColNotaDst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConContoDst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValoreDst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSorgenteOperazione)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDestinazioneOperazione)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrizione operazione";
            // 
            // textDescrizioneOperazione
            // 
            this.textDescrizioneOperazione.Location = new System.Drawing.Point(147, 19);
            this.textDescrizioneOperazione.Name = "textDescrizioneOperazione";
            this.textDescrizioneOperazione.Size = new System.Drawing.Size(620, 20);
            this.textDescrizioneOperazione.TabIndex = 1;
            // 
            // textValoreOperazione
            // 
            this.textValoreOperazione.Location = new System.Drawing.Point(147, 45);
            this.textValoreOperazione.Name = "textValoreOperazione";
            this.textValoreOperazione.Size = new System.Drawing.Size(620, 20);
            this.textValoreOperazione.TabIndex = 3;
            this.textValoreOperazione.TextChanged += new System.EventHandler(this.textValoreOperazione_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valore Operazione";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dateTimeOperazione);
            this.splitContainer1.Panel1.Controls.Add(this.butAggiorna);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxTipoOperazione);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textValoreOperazione);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textDescrizioneOperazione);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1192, 626);
            this.splitContainer1.SplitterDistance = 80;
            this.splitContainer1.TabIndex = 4;
            // 
            // dateTimeOperazione
            // 
            this.dateTimeOperazione.CustomFormat = "dd/MM/yyyy";
            this.dateTimeOperazione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeOperazione.Location = new System.Drawing.Point(911, 16);
            this.dateTimeOperazione.Name = "dateTimeOperazione";
            this.dateTimeOperazione.Size = new System.Drawing.Size(150, 20);
            this.dateTimeOperazione.TabIndex = 14;
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(1068, 48);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 13;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            this.butAggiorna.Click += new System.EventHandler(this.butAggiorna_Click);
            // 
            // comboBoxTipoOperazione
            // 
            this.comboBoxTipoOperazione.FormattingEnabled = true;
            this.comboBoxTipoOperazione.Items.AddRange(new object[] {
            "@",
            "Cnt",
            "Dep"});
            this.comboBoxTipoOperazione.Location = new System.Drawing.Point(911, 48);
            this.comboBoxTipoOperazione.Name = "comboBoxTipoOperazione";
            this.comboBoxTipoOperazione.Size = new System.Drawing.Size(150, 21);
            this.comboBoxTipoOperazione.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(822, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Tipo operazione";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(822, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Data ";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1192, 542);
            this.splitContainer2.SplitterDistance = 600;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.comboBoxContoSorgente);
            this.splitContainer4.Panel1.Controls.Add(this.textDeltaValoreSorgente);
            this.splitContainer4.Panel1.Controls.Add(this.label11);
            this.splitContainer4.Panel1.Controls.Add(this.textTotaleValoreSorgente);
            this.splitContainer4.Panel1.Controls.Add(this.label10);
            this.splitContainer4.Panel1.Controls.Add(this.label8);
            this.splitContainer4.Panel1.Controls.Add(this.comboBoxTipoSottocontiSorgente);
            this.splitContainer4.Panel1.Controls.Add(this.radioOperazioneSorgenteMultipla);
            this.splitContainer4.Panel1.Controls.Add(this.butAggiornaSorgente);
            this.splitContainer4.Panel1.Controls.Add(this.textNotaSorgente);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridViewSorgenteOperazione);
            this.splitContainer4.Size = new System.Drawing.Size(600, 542);
            this.splitContainer4.SplitterDistance = 130;
            this.splitContainer4.TabIndex = 0;
            // 
            // comboBoxContoSorgente
            // 
            this.comboBoxContoSorgente.FormattingEnabled = true;
            this.comboBoxContoSorgente.Location = new System.Drawing.Point(147, 44);
            this.comboBoxContoSorgente.Name = "comboBoxContoSorgente";
            this.comboBoxContoSorgente.Size = new System.Drawing.Size(441, 21);
            this.comboBoxContoSorgente.TabIndex = 14;
            // 
            // textDeltaValoreSorgente
            // 
            this.textDeltaValoreSorgente.Location = new System.Drawing.Point(467, 102);
            this.textDeltaValoreSorgente.Name = "textDeltaValoreSorgente";
            this.textDeltaValoreSorgente.Size = new System.Drawing.Size(121, 20);
            this.textDeltaValoreSorgente.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Delta Valore";
            // 
            // textTotaleValoreSorgente
            // 
            this.textTotaleValoreSorgente.Location = new System.Drawing.Point(220, 100);
            this.textTotaleValoreSorgente.Name = "textTotaleValoreSorgente";
            this.textTotaleValoreSorgente.Size = new System.Drawing.Size(113, 20);
            this.textTotaleValoreSorgente.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Totale Valore";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tipo sottoconti";
            // 
            // comboBoxTipoSottocontiSorgente
            // 
            this.comboBoxTipoSottocontiSorgente.FormattingEnabled = true;
            this.comboBoxTipoSottocontiSorgente.Items.AddRange(new object[] {
            "@",
            "Cnt",
            "Dep"});
            this.comboBoxTipoSottocontiSorgente.Location = new System.Drawing.Point(467, 75);
            this.comboBoxTipoSottocontiSorgente.Name = "comboBoxTipoSottocontiSorgente";
            this.comboBoxTipoSottocontiSorgente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoSottocontiSorgente.TabIndex = 8;
            // 
            // radioOperazioneSorgenteMultipla
            // 
            this.radioOperazioneSorgenteMultipla.AutoSize = true;
            this.radioOperazioneSorgenteMultipla.Location = new System.Drawing.Point(147, 79);
            this.radioOperazioneSorgenteMultipla.Name = "radioOperazioneSorgenteMultipla";
            this.radioOperazioneSorgenteMultipla.Size = new System.Drawing.Size(118, 17);
            this.radioOperazioneSorgenteMultipla.TabIndex = 7;
            this.radioOperazioneSorgenteMultipla.TabStop = true;
            this.radioOperazioneSorgenteMultipla.Text = "Operazione Multipla";
            this.radioOperazioneSorgenteMultipla.UseVisualStyleBackColor = true;
            // 
            // butAggiornaSorgente
            // 
            this.butAggiornaSorgente.Location = new System.Drawing.Point(15, 73);
            this.butAggiornaSorgente.Name = "butAggiornaSorgente";
            this.butAggiornaSorgente.Size = new System.Drawing.Size(114, 23);
            this.butAggiornaSorgente.TabIndex = 6;
            this.butAggiornaSorgente.Text = "Aggiorna sorgente";
            this.butAggiornaSorgente.UseVisualStyleBackColor = true;
            this.butAggiornaSorgente.Click += new System.EventHandler(this.butAggiornaSorgente_Click);
            // 
            // textNotaSorgente
            // 
            this.textNotaSorgente.Location = new System.Drawing.Point(147, 19);
            this.textNotaSorgente.Name = "textNotaSorgente";
            this.textNotaSorgente.Size = new System.Drawing.Size(441, 20);
            this.textNotaSorgente.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Conto sorgente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nota sorgente";
            // 
            // dataGridViewSorgenteOperazione
            // 
            this.dataGridViewSorgenteOperazione.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSorgenteOperazione.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSorgenteOperazione.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNotaSrc,
            this.ColContoSrc,
            this.ColValoreSrc});
            this.dataGridViewSorgenteOperazione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSorgenteOperazione.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSorgenteOperazione.Name = "dataGridViewSorgenteOperazione";
            this.dataGridViewSorgenteOperazione.Size = new System.Drawing.Size(600, 408);
            this.dataGridViewSorgenteOperazione.TabIndex = 0;
            this.dataGridViewSorgenteOperazione.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSorgenteOperazione_CellValueChanged);
            // 
            // ColNotaSrc
            // 
            this.ColNotaSrc.HeaderText = "Nota";
            this.ColNotaSrc.Name = "ColNotaSrc";
            this.ColNotaSrc.Width = 55;
            // 
            // ColContoSrc
            // 
            this.ColContoSrc.HeaderText = "Conto";
            this.ColContoSrc.Name = "ColContoSrc";
            this.ColContoSrc.Width = 60;
            // 
            // ColValoreSrc
            // 
            this.ColValoreSrc.HeaderText = "Valore";
            this.ColValoreSrc.Name = "ColValoreSrc";
            this.ColValoreSrc.Width = 62;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.comboBoxContoDestinazione);
            this.splitContainer3.Panel1.Controls.Add(this.textDeltaValoreDestinazione);
            this.splitContainer3.Panel1.Controls.Add(this.label9);
            this.splitContainer3.Panel1.Controls.Add(this.label12);
            this.splitContainer3.Panel1.Controls.Add(this.radioOperazioneDestinazioneMultipla);
            this.splitContainer3.Panel1.Controls.Add(this.textTotaleValoreDestinazione);
            this.splitContainer3.Panel1.Controls.Add(this.label13);
            this.splitContainer3.Panel1.Controls.Add(this.comboBoxTipoSottocontiDestinazione);
            this.splitContainer3.Panel1.Controls.Add(this.butAggiornaDestinazione);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.textNotaDestinazione);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridViewDestinazioneOperazione);
            this.splitContainer3.Size = new System.Drawing.Size(588, 542);
            this.splitContainer3.SplitterDistance = 130;
            this.splitContainer3.TabIndex = 8;
            // 
            // comboBoxContoDestinazione
            // 
            this.comboBoxContoDestinazione.FormattingEnabled = true;
            this.comboBoxContoDestinazione.Location = new System.Drawing.Point(144, 48);
            this.comboBoxContoDestinazione.Name = "comboBoxContoDestinazione";
            this.comboBoxContoDestinazione.Size = new System.Drawing.Size(441, 21);
            this.comboBoxContoDestinazione.TabIndex = 15;
            // 
            // textDeltaValoreDestinazione
            // 
            this.textDeltaValoreDestinazione.Location = new System.Drawing.Point(464, 105);
            this.textDeltaValoreDestinazione.Name = "textDeltaValoreDestinazione";
            this.textDeltaValoreDestinazione.Size = new System.Drawing.Size(121, 20);
            this.textDeltaValoreDestinazione.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tipo sottoconti";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(337, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Delta Valore";
            // 
            // radioOperazioneDestinazioneMultipla
            // 
            this.radioOperazioneDestinazioneMultipla.AutoSize = true;
            this.radioOperazioneDestinazioneMultipla.Location = new System.Drawing.Point(144, 79);
            this.radioOperazioneDestinazioneMultipla.Name = "radioOperazioneDestinazioneMultipla";
            this.radioOperazioneDestinazioneMultipla.Size = new System.Drawing.Size(118, 17);
            this.radioOperazioneDestinazioneMultipla.TabIndex = 13;
            this.radioOperazioneDestinazioneMultipla.TabStop = true;
            this.radioOperazioneDestinazioneMultipla.Text = "Operazione Multipla";
            this.radioOperazioneDestinazioneMultipla.UseVisualStyleBackColor = true;
            // 
            // textTotaleValoreDestinazione
            // 
            this.textTotaleValoreDestinazione.Location = new System.Drawing.Point(217, 103);
            this.textTotaleValoreDestinazione.Name = "textTotaleValoreDestinazione";
            this.textTotaleValoreDestinazione.Size = new System.Drawing.Size(113, 20);
            this.textTotaleValoreDestinazione.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(141, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Totale Valore";
            // 
            // comboBoxTipoSottocontiDestinazione
            // 
            this.comboBoxTipoSottocontiDestinazione.FormattingEnabled = true;
            this.comboBoxTipoSottocontiDestinazione.Items.AddRange(new object[] {
            "@",
            "Cnt",
            "Dep"});
            this.comboBoxTipoSottocontiDestinazione.Location = new System.Drawing.Point(464, 78);
            this.comboBoxTipoSottocontiDestinazione.Name = "comboBoxTipoSottocontiDestinazione";
            this.comboBoxTipoSottocontiDestinazione.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoSottocontiDestinazione.TabIndex = 10;
            // 
            // butAggiornaDestinazione
            // 
            this.butAggiornaDestinazione.Location = new System.Drawing.Point(12, 75);
            this.butAggiornaDestinazione.Name = "butAggiornaDestinazione";
            this.butAggiornaDestinazione.Size = new System.Drawing.Size(126, 23);
            this.butAggiornaDestinazione.TabIndex = 12;
            this.butAggiornaDestinazione.Text = "Aggiorna destinazione";
            this.butAggiornaDestinazione.UseVisualStyleBackColor = true;
            this.butAggiornaDestinazione.Click += new System.EventHandler(this.butAggiornaDestinazione_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nota destinazione";
            // 
            // textNotaDestinazione
            // 
            this.textNotaDestinazione.Location = new System.Drawing.Point(144, 19);
            this.textNotaDestinazione.Name = "textNotaDestinazione";
            this.textNotaDestinazione.Size = new System.Drawing.Size(441, 20);
            this.textNotaDestinazione.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Conto destinazione";
            // 
            // dataGridViewDestinazioneOperazione
            // 
            this.dataGridViewDestinazioneOperazione.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDestinazioneOperazione.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDestinazioneOperazione.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNotaDst,
            this.ConContoDst,
            this.ColValoreDst});
            this.dataGridViewDestinazioneOperazione.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDestinazioneOperazione.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDestinazioneOperazione.Name = "dataGridViewDestinazioneOperazione";
            this.dataGridViewDestinazioneOperazione.Size = new System.Drawing.Size(588, 408);
            this.dataGridViewDestinazioneOperazione.TabIndex = 0;
            this.dataGridViewDestinazioneOperazione.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDestinazioneOperazione_CellValueChanged);
            // 
            // ColNotaDst
            // 
            this.ColNotaDst.HeaderText = "Nota";
            this.ColNotaDst.Name = "ColNotaDst";
            this.ColNotaDst.Width = 55;
            // 
            // ConContoDst
            // 
            this.ConContoDst.HeaderText = "Conto";
            this.ConContoDst.Name = "ConContoDst";
            this.ConContoDst.Width = 60;
            // 
            // ColValoreDst
            // 
            this.ColValoreDst.HeaderText = "Valore";
            this.ColValoreDst.Name = "ColValoreDst";
            this.ColValoreDst.Width = 62;
            // 
            // FormNewOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 626);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormNewOperation";
            this.Text = "FormNewOperation";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSorgenteOperazione)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDestinazioneOperazione)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDescrizioneOperazione;
        private System.Windows.Forms.TextBox textValoreOperazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNotaSorgente;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.RadioButton radioOperazioneSorgenteMultipla;
        private System.Windows.Forms.Button butAggiornaSorgente;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RadioButton radioOperazioneDestinazioneMultipla;
        private System.Windows.Forms.Button butAggiornaDestinazione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textNotaDestinazione;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewSorgenteOperazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNotaSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContoSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValoreSrc;
        private System.Windows.Forms.DataGridView dataGridViewDestinazioneOperazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNotaDst;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConContoDst;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValoreDst;
        private System.Windows.Forms.ComboBox comboBoxTipoSottocontiSorgente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxTipoSottocontiDestinazione;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textDeltaValoreSorgente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textTotaleValoreSorgente;
        private System.Windows.Forms.TextBox textDeltaValoreDestinazione;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textTotaleValoreDestinazione;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxContoSorgente;
        private System.Windows.Forms.ComboBox comboBoxContoDestinazione;
        private System.Windows.Forms.ComboBox comboBoxTipoOperazione;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button butAggiorna;
        private System.Windows.Forms.DateTimePicker dateTimeOperazione;
    }
}
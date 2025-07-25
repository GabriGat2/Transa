namespace Transa
{
    partial class FormFileBea
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxFileTransazioni = new System.Windows.Forms.GroupBox();
            this.butApri = new System.Windows.Forms.Button();
            this.textBoxNomeFile = new System.Windows.Forms.TextBox();
            this.butNomeFile = new System.Windows.Forms.Button();
            this.splitContainer1B_2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1B_2A = new System.Windows.Forms.SplitContainer();
            this.groupBoxLineeFile = new System.Windows.Forms.GroupBox();
            this.butAnalizza = new System.Windows.Forms.Button();
            this.textBoxLinea = new System.Windows.Forms.TextBox();
            this.butNext = new System.Windows.Forms.Button();
            this.groupBoxLinee = new System.Windows.Forms.GroupBox();
            this.richTextBoxLinee = new System.Windows.Forms.RichTextBox();
            this.groupBoxOperazioni = new System.Windows.Forms.GroupBox();
            this.splitContainer1B_2B_3 = new System.Windows.Forms.SplitContainer();
            this.textBoxStatoConti = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butValoreConti = new System.Windows.Forms.Button();
            this.textNumOperazione = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimeOperazione = new System.Windows.Forms.DateTimePicker();
            this.butAggiorna = new System.Windows.Forms.Button();
            this.comboBoxTipoOperazione = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textValoreOperazione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDescrizioneOperazione = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxLinee2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxFileTransazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B_2)).BeginInit();
            this.splitContainer1B_2.Panel1.SuspendLayout();
            this.splitContainer1B_2.Panel2.SuspendLayout();
            this.splitContainer1B_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B_2A)).BeginInit();
            this.splitContainer1B_2A.Panel1.SuspendLayout();
            this.splitContainer1B_2A.Panel2.SuspendLayout();
            this.splitContainer1B_2A.SuspendLayout();
            this.groupBoxLineeFile.SuspendLayout();
            this.groupBoxLinee.SuspendLayout();
            this.groupBoxOperazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B_2B_3)).BeginInit();
            this.splitContainer1B_2B_3.Panel1.SuspendLayout();
            this.splitContainer1B_2B_3.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxFileTransazioni);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer1B_2);
            this.splitContainer1.Size = new System.Drawing.Size(1192, 626);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxFileTransazioni
            // 
            this.groupBoxFileTransazioni.Controls.Add(this.butApri);
            this.groupBoxFileTransazioni.Controls.Add(this.textBoxNomeFile);
            this.groupBoxFileTransazioni.Controls.Add(this.butNomeFile);
            this.groupBoxFileTransazioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFileTransazioni.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFileTransazioni.Name = "groupBoxFileTransazioni";
            this.groupBoxFileTransazioni.Size = new System.Drawing.Size(1192, 53);
            this.groupBoxFileTransazioni.TabIndex = 0;
            this.groupBoxFileTransazioni.TabStop = false;
            this.groupBoxFileTransazioni.Text = "File Transazioni";
            // 
            // butApri
            // 
            this.butApri.Location = new System.Drawing.Point(1005, 20);
            this.butApri.Name = "butApri";
            this.butApri.Size = new System.Drawing.Size(75, 23);
            this.butApri.TabIndex = 2;
            this.butApri.Text = "Apri";
            this.butApri.UseVisualStyleBackColor = true;
            this.butApri.Click += new System.EventHandler(this.butApri_Click);
            // 
            // textBoxNomeFile
            // 
            this.textBoxNomeFile.Location = new System.Drawing.Point(87, 22);
            this.textBoxNomeFile.Name = "textBoxNomeFile";
            this.textBoxNomeFile.Size = new System.Drawing.Size(912, 20);
            this.textBoxNomeFile.TabIndex = 1;
            // 
            // butNomeFile
            // 
            this.butNomeFile.Location = new System.Drawing.Point(6, 19);
            this.butNomeFile.Name = "butNomeFile";
            this.butNomeFile.Size = new System.Drawing.Size(75, 23);
            this.butNomeFile.TabIndex = 0;
            this.butNomeFile.Text = "Nome file";
            this.butNomeFile.UseVisualStyleBackColor = true;
            this.butNomeFile.Click += new System.EventHandler(this.butNomeFile_Click);
            // 
            // splitContainer1B_2
            // 
            this.splitContainer1B_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1B_2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1B_2.Name = "splitContainer1B_2";
            this.splitContainer1B_2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1B_2.Panel1
            // 
            this.splitContainer1B_2.Panel1.Controls.Add(this.splitContainer1B_2A);
            // 
            // splitContainer1B_2.Panel2
            // 
            this.splitContainer1B_2.Panel2.Controls.Add(this.groupBoxOperazioni);
            this.splitContainer1B_2.Size = new System.Drawing.Size(1192, 569);
            this.splitContainer1B_2.SplitterDistance = 120;
            this.splitContainer1B_2.TabIndex = 0;
            // 
            // splitContainer1B_2A
            // 
            this.splitContainer1B_2A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1B_2A.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1B_2A.Name = "splitContainer1B_2A";
            this.splitContainer1B_2A.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1B_2A.Panel1
            // 
            this.splitContainer1B_2A.Panel1.Controls.Add(this.groupBoxLineeFile);
            // 
            // splitContainer1B_2A.Panel2
            // 
            this.splitContainer1B_2A.Panel2.Controls.Add(this.groupBoxLinee);
            this.splitContainer1B_2A.Size = new System.Drawing.Size(1192, 120);
            this.splitContainer1B_2A.SplitterDistance = 60;
            this.splitContainer1B_2A.TabIndex = 0;
            // 
            // groupBoxLineeFile
            // 
            this.groupBoxLineeFile.Controls.Add(this.label3);
            this.groupBoxLineeFile.Controls.Add(this.butAnalizza);
            this.groupBoxLineeFile.Controls.Add(this.textBoxLinea);
            this.groupBoxLineeFile.Controls.Add(this.butNext);
            this.groupBoxLineeFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLineeFile.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLineeFile.Name = "groupBoxLineeFile";
            this.groupBoxLineeFile.Size = new System.Drawing.Size(1192, 60);
            this.groupBoxLineeFile.TabIndex = 0;
            this.groupBoxLineeFile.TabStop = false;
            this.groupBoxLineeFile.Text = "Linee file";
            // 
            // butAnalizza
            // 
            this.butAnalizza.Location = new System.Drawing.Point(1086, 19);
            this.butAnalizza.Name = "butAnalizza";
            this.butAnalizza.Size = new System.Drawing.Size(75, 23);
            this.butAnalizza.TabIndex = 5;
            this.butAnalizza.Text = "Analizza";
            this.butAnalizza.UseVisualStyleBackColor = true;
            this.butAnalizza.Click += new System.EventHandler(this.butAnalizza_Click);
            // 
            // textBoxLinea
            // 
            this.textBoxLinea.Location = new System.Drawing.Point(87, 22);
            this.textBoxLinea.Name = "textBoxLinea";
            this.textBoxLinea.Size = new System.Drawing.Size(912, 20);
            this.textBoxLinea.TabIndex = 4;
            // 
            // butNext
            // 
            this.butNext.Location = new System.Drawing.Point(1005, 19);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(75, 23);
            this.butNext.TabIndex = 3;
            this.butNext.Text = "Next";
            this.butNext.UseVisualStyleBackColor = true;
            this.butNext.Click += new System.EventHandler(this.butNext_Click);
            // 
            // groupBoxLinee
            // 
            this.groupBoxLinee.Controls.Add(this.richTextBoxLinee);
            this.groupBoxLinee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLinee.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLinee.Name = "groupBoxLinee";
            this.groupBoxLinee.Size = new System.Drawing.Size(1192, 56);
            this.groupBoxLinee.TabIndex = 0;
            this.groupBoxLinee.TabStop = false;
            this.groupBoxLinee.Text = "Linee";
            // 
            // richTextBoxLinee
            // 
            this.richTextBoxLinee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLinee.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxLinee.Name = "richTextBoxLinee";
            this.richTextBoxLinee.Size = new System.Drawing.Size(1186, 37);
            this.richTextBoxLinee.TabIndex = 0;
            this.richTextBoxLinee.Text = "";
            // 
            // groupBoxOperazioni
            // 
            this.groupBoxOperazioni.Controls.Add(this.splitContainer1B_2B_3);
            this.groupBoxOperazioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOperazioni.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOperazioni.Name = "groupBoxOperazioni";
            this.groupBoxOperazioni.Size = new System.Drawing.Size(1192, 445);
            this.groupBoxOperazioni.TabIndex = 0;
            this.groupBoxOperazioni.TabStop = false;
            this.groupBoxOperazioni.Text = "Operazioni";
            // 
            // splitContainer1B_2B_3
            // 
            this.splitContainer1B_2B_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1B_2B_3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1B_2B_3.Name = "splitContainer1B_2B_3";
            this.splitContainer1B_2B_3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1B_2B_3.Panel1
            // 
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.richTextBoxLinee2);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.textBoxStatoConti);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.label18);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.label2);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.butValoreConti);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.textNumOperazione);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.label15);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.dateTimeOperazione);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.butAggiorna);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.comboBoxTipoOperazione);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.label14);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.label7);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.textValoreOperazione);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.label1);
            this.splitContainer1B_2B_3.Panel1.Controls.Add(this.textDescrizioneOperazione);
            this.splitContainer1B_2B_3.Size = new System.Drawing.Size(1186, 426);
            this.splitContainer1B_2B_3.SplitterDistance = 395;
            this.splitContainer1B_2B_3.TabIndex = 0;
            // 
            // textBoxStatoConti
            // 
            this.textBoxStatoConti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatoConti.Location = new System.Drawing.Point(613, 37);
            this.textBoxStatoConti.Name = "textBoxStatoConti";
            this.textBoxStatoConti.ReadOnly = true;
            this.textBoxStatoConti.Size = new System.Drawing.Size(151, 20);
            this.textBoxStatoConti.TabIndex = 34;
            this.textBoxStatoConti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(528, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Stato conti attivi: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Valore operazione";
            // 
            // butValoreConti
            // 
            this.butValoreConti.Location = new System.Drawing.Point(9, 40);
            this.butValoreConti.Name = "butValoreConti";
            this.butValoreConti.Size = new System.Drawing.Size(136, 23);
            this.butValoreConti.TabIndex = 31;
            this.butValoreConti.Text = "Modifica conti operazione";
            this.butValoreConti.UseVisualStyleBackColor = true;
            // 
            // textNumOperazione
            // 
            this.textNumOperazione.Location = new System.Drawing.Point(1065, 7);
            this.textNumOperazione.Name = "textNumOperazione";
            this.textNumOperazione.Size = new System.Drawing.Size(112, 20);
            this.textNumOperazione.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1033, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Num";
            // 
            // dateTimeOperazione
            // 
            this.dateTimeOperazione.CustomFormat = "dd/MM/yyyy";
            this.dateTimeOperazione.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeOperazione.Location = new System.Drawing.Point(868, 10);
            this.dateTimeOperazione.Name = "dateTimeOperazione";
            this.dateTimeOperazione.Size = new System.Drawing.Size(150, 20);
            this.dateTimeOperazione.TabIndex = 28;
            // 
            // butAggiorna
            // 
            this.butAggiorna.Location = new System.Drawing.Point(1033, 36);
            this.butAggiorna.Name = "butAggiorna";
            this.butAggiorna.Size = new System.Drawing.Size(75, 23);
            this.butAggiorna.TabIndex = 27;
            this.butAggiorna.Text = "Aggiorna";
            this.butAggiorna.UseVisualStyleBackColor = true;
            // 
            // comboBoxTipoOperazione
            // 
            this.comboBoxTipoOperazione.FormattingEnabled = true;
            this.comboBoxTipoOperazione.Items.AddRange(new object[] {
            "@",
            "Cnt",
            "Dep"});
            this.comboBoxTipoOperazione.Location = new System.Drawing.Point(868, 36);
            this.comboBoxTipoOperazione.Name = "comboBoxTipoOperazione";
            this.comboBoxTipoOperazione.Size = new System.Drawing.Size(150, 21);
            this.comboBoxTipoOperazione.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(779, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Tipo operazione";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(779, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Data ";
            // 
            // textValoreOperazione
            // 
            this.textValoreOperazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValoreOperazione.Location = new System.Drawing.Point(250, 42);
            this.textValoreOperazione.Name = "textValoreOperazione";
            this.textValoreOperazione.ReadOnly = true;
            this.textValoreOperazione.Size = new System.Drawing.Size(173, 20);
            this.textValoreOperazione.TabIndex = 23;
            this.textValoreOperazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Descrizione operazione";
            // 
            // textDescrizioneOperazione
            // 
            this.textDescrizioneOperazione.Location = new System.Drawing.Point(155, 10);
            this.textDescrizioneOperazione.Name = "textDescrizioneOperazione";
            this.textDescrizioneOperazione.Size = new System.Drawing.Size(609, 20);
            this.textDescrizioneOperazione.TabIndex = 22;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Transizione";
            // 
            // richTextBoxLinee2
            // 
            this.richTextBoxLinee2.Location = new System.Drawing.Point(12, 69);
            this.richTextBoxLinee2.Name = "richTextBoxLinee2";
            this.richTextBoxLinee2.Size = new System.Drawing.Size(1146, 307);
            this.richTextBoxLinee2.TabIndex = 35;
            this.richTextBoxLinee2.Text = "";
            // 
            // FormFileBea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 626);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormFileBea";
            this.Text = "FormFileBea";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxFileTransazioni.ResumeLayout(false);
            this.groupBoxFileTransazioni.PerformLayout();
            this.splitContainer1B_2.Panel1.ResumeLayout(false);
            this.splitContainer1B_2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B_2)).EndInit();
            this.splitContainer1B_2.ResumeLayout(false);
            this.splitContainer1B_2A.Panel1.ResumeLayout(false);
            this.splitContainer1B_2A.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B_2A)).EndInit();
            this.splitContainer1B_2A.ResumeLayout(false);
            this.groupBoxLineeFile.ResumeLayout(false);
            this.groupBoxLineeFile.PerformLayout();
            this.groupBoxLinee.ResumeLayout(false);
            this.groupBoxOperazioni.ResumeLayout(false);
            this.splitContainer1B_2B_3.Panel1.ResumeLayout(false);
            this.splitContainer1B_2B_3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1B_2B_3)).EndInit();
            this.splitContainer1B_2B_3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxFileTransazioni;
        private System.Windows.Forms.TextBox textBoxNomeFile;
        private System.Windows.Forms.Button butNomeFile;
        private System.Windows.Forms.Button butApri;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1B_2;
        private System.Windows.Forms.GroupBox groupBoxLineeFile;
        private System.Windows.Forms.Button butAnalizza;
        private System.Windows.Forms.TextBox textBoxLinea;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.SplitContainer splitContainer1B_2A;
        private System.Windows.Forms.GroupBox groupBoxLinee;
        private System.Windows.Forms.RichTextBox richTextBoxLinee;
        private System.Windows.Forms.GroupBox groupBoxOperazioni;
        private System.Windows.Forms.SplitContainer splitContainer1B_2B_3;
        private System.Windows.Forms.TextBox textBoxStatoConti;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butValoreConti;
        private System.Windows.Forms.TextBox textNumOperazione;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimeOperazione;
        private System.Windows.Forms.Button butAggiorna;
        private System.Windows.Forms.ComboBox comboBoxTipoOperazione;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textValoreOperazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDescrizioneOperazione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxLinee2;
    }
}
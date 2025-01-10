
namespace Transa
{
    partial class FormMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butAccounts = new System.Windows.Forms.Button();
            this.butNewOperation = new System.Windows.Forms.Button();
            this.butSaveFile = new System.Windows.Forms.Button();
            this.butDeleteRow = new System.Windows.Forms.Button();
            this.butAddRow = new System.Windows.Forms.Button();
            this.butOpenFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.butTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1237, 653);
            this.splitContainer1.SplitterDistance = 609;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butTest);
            this.panel1.Controls.Add(this.butAccounts);
            this.panel1.Controls.Add(this.butNewOperation);
            this.panel1.Controls.Add(this.butSaveFile);
            this.panel1.Controls.Add(this.butDeleteRow);
            this.panel1.Controls.Add(this.butAddRow);
            this.panel1.Controls.Add(this.butOpenFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1237, 35);
            this.panel1.TabIndex = 0;
            // 
            // butAccounts
            // 
            this.butAccounts.Location = new System.Drawing.Point(508, 7);
            this.butAccounts.Name = "butAccounts";
            this.butAccounts.Size = new System.Drawing.Size(108, 23);
            this.butAccounts.TabIndex = 5;
            this.butAccounts.Text = "Gestione conti";
            this.butAccounts.UseVisualStyleBackColor = true;
            this.butAccounts.Click += new System.EventHandler(this.butAccounts_Click);
            // 
            // butNewOperation
            // 
            this.butNewOperation.Location = new System.Drawing.Point(378, 7);
            this.butNewOperation.Name = "butNewOperation";
            this.butNewOperation.Size = new System.Drawing.Size(108, 23);
            this.butNewOperation.TabIndex = 4;
            this.butNewOperation.Text = "Nuova Operazione";
            this.butNewOperation.UseVisualStyleBackColor = true;
            this.butNewOperation.Click += new System.EventHandler(this.butNewOperation_Click);
            // 
            // butSaveFile
            // 
            this.butSaveFile.Location = new System.Drawing.Point(70, 9);
            this.butSaveFile.Margin = new System.Windows.Forms.Padding(2);
            this.butSaveFile.Name = "butSaveFile";
            this.butSaveFile.Size = new System.Drawing.Size(56, 19);
            this.butSaveFile.TabIndex = 3;
            this.butSaveFile.Text = "Save File";
            this.butSaveFile.UseVisualStyleBackColor = true;
            this.butSaveFile.Click += new System.EventHandler(this.butSaveFile_Click);
            // 
            // butDeleteRow
            // 
            this.butDeleteRow.Location = new System.Drawing.Point(271, 9);
            this.butDeleteRow.Margin = new System.Windows.Forms.Padding(2);
            this.butDeleteRow.Name = "butDeleteRow";
            this.butDeleteRow.Size = new System.Drawing.Size(56, 19);
            this.butDeleteRow.TabIndex = 2;
            this.butDeleteRow.Text = "Del row";
            this.butDeleteRow.UseVisualStyleBackColor = true;
            this.butDeleteRow.Click += new System.EventHandler(this.butDeleteRow_Click);
            // 
            // butAddRow
            // 
            this.butAddRow.Location = new System.Drawing.Point(210, 9);
            this.butAddRow.Margin = new System.Windows.Forms.Padding(2);
            this.butAddRow.Name = "butAddRow";
            this.butAddRow.Size = new System.Drawing.Size(56, 19);
            this.butAddRow.TabIndex = 1;
            this.butAddRow.Text = "Add row";
            this.butAddRow.UseVisualStyleBackColor = true;
            this.butAddRow.Click += new System.EventHandler(this.butAddRow_Click);
            // 
            // butOpenFile
            // 
            this.butOpenFile.Location = new System.Drawing.Point(9, 9);
            this.butOpenFile.Margin = new System.Windows.Forms.Padding(2);
            this.butOpenFile.Name = "butOpenFile";
            this.butOpenFile.Size = new System.Drawing.Size(56, 19);
            this.butOpenFile.TabIndex = 0;
            this.butOpenFile.Text = "Open File";
            this.butOpenFile.UseVisualStyleBackColor = true;
            this.butOpenFile.Click += new System.EventHandler(this.butOpenFile_Click);
            // 
            // butTest
            // 
            this.butTest.Location = new System.Drawing.Point(837, 6);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(75, 23);
            this.butTest.TabIndex = 6;
            this.butTest.Text = "Test";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1237, 653);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butOpenFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butDeleteRow;
        private System.Windows.Forms.Button butAddRow;
        private System.Windows.Forms.Button butSaveFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button butNewOperation;
        private System.Windows.Forms.Button butAccounts;
        private System.Windows.Forms.Button butTest;
    }
}


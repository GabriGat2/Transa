
namespace Transa
{
    partial class FormGstStrConti
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxConti = new System.Windows.Forms.ComboBox();
            this.butLoad = new System.Windows.Forms.Button();
            this.richTextBoxStrConti = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1debug = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumeroConti = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFileNameConti = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxFileNameConti);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxNumeroConti);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxConti);
            this.splitContainer1.Panel1.Controls.Add(this.butLoad);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxStrConti);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selezione conti";
            // 
            // comboBoxConti
            // 
            this.comboBoxConti.FormattingEnabled = true;
            this.comboBoxConti.Location = new System.Drawing.Point(198, 37);
            this.comboBoxConti.Name = "comboBoxConti";
            this.comboBoxConti.Size = new System.Drawing.Size(590, 21);
            this.comboBoxConti.TabIndex = 0;
            // 
            // butLoad
            // 
            this.butLoad.Location = new System.Drawing.Point(12, 12);
            this.butLoad.Name = "butLoad";
            this.butLoad.Size = new System.Drawing.Size(94, 23);
            this.butLoad.TabIndex = 0;
            this.butLoad.Text = "Carica Struttura";
            this.butLoad.UseVisualStyleBackColor = true;
            this.butLoad.Click += new System.EventHandler(this.butLoad_Click);
            // 
            // richTextBoxStrConti
            // 
            this.richTextBoxStrConti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxStrConti.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxStrConti.Name = "richTextBoxStrConti";
            this.richTextBoxStrConti.Size = new System.Drawing.Size(800, 386);
            this.richTextBoxStrConti.TabIndex = 0;
            this.richTextBoxStrConti.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero conti";
            // 
            // textBoxNumeroConti
            // 
            this.textBoxNumeroConti.Location = new System.Drawing.Point(198, 12);
            this.textBoxNumeroConti.Name = "textBoxNumeroConti";
            this.textBoxNumeroConti.ReadOnly = true;
            this.textBoxNumeroConti.Size = new System.Drawing.Size(86, 20);
            this.textBoxNumeroConti.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome file struttura conti";
            // 
            // textBoxFileNameConti
            // 
            this.textBoxFileNameConti.Location = new System.Drawing.Point(458, 14);
            this.textBoxFileNameConti.Name = "textBoxFileNameConti";
            this.textBoxFileNameConti.ReadOnly = true;
            this.textBoxFileNameConti.Size = new System.Drawing.Size(330, 20);
            this.textBoxFileNameConti.TabIndex = 5;
            // 
            // GstStrConti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GstStrConti";
            this.Text = "GstStrConti";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxConti;
        private System.Windows.Forms.Button butLoad;
        private System.Windows.Forms.RichTextBox richTextBoxStrConti;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1debug;
        private System.Windows.Forms.TextBox textBoxNumeroConti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFileNameConti;
        private System.Windows.Forms.Label label3;
    }
}
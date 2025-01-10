
namespace Transa
{
    partial class FormGstValue
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
            this.textBoxCampo1 = new System.Windows.Forms.TextBox();
            this.textBoxCampo2 = new System.Windows.Forms.TextBox();
            this.textBoxCampo3 = new System.Windows.Forms.TextBox();
            this.textBoxCampo4 = new System.Windows.Forms.TextBox();
            this.textBoxInStringa = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBoxOut = new System.Windows.Forms.RichTextBox();
            this.butAnalisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCampo1
            // 
            this.textBoxCampo1.Location = new System.Drawing.Point(65, 74);
            this.textBoxCampo1.Name = "textBoxCampo1";
            this.textBoxCampo1.Size = new System.Drawing.Size(96, 20);
            this.textBoxCampo1.TabIndex = 0;
            // 
            // textBoxCampo2
            // 
            this.textBoxCampo2.Location = new System.Drawing.Point(178, 74);
            this.textBoxCampo2.Name = "textBoxCampo2";
            this.textBoxCampo2.Size = new System.Drawing.Size(96, 20);
            this.textBoxCampo2.TabIndex = 1;
            // 
            // textBoxCampo3
            // 
            this.textBoxCampo3.Location = new System.Drawing.Point(293, 74);
            this.textBoxCampo3.Name = "textBoxCampo3";
            this.textBoxCampo3.Size = new System.Drawing.Size(96, 20);
            this.textBoxCampo3.TabIndex = 2;
            // 
            // textBoxCampo4
            // 
            this.textBoxCampo4.Location = new System.Drawing.Point(414, 74);
            this.textBoxCampo4.Name = "textBoxCampo4";
            this.textBoxCampo4.Size = new System.Drawing.Size(96, 20);
            this.textBoxCampo4.TabIndex = 3;
            // 
            // textBoxInStringa
            // 
            this.textBoxInStringa.Location = new System.Drawing.Point(36, 30);
            this.textBoxInStringa.Name = "textBoxInStringa";
            this.textBoxInStringa.Size = new System.Drawing.Size(604, 20);
            this.textBoxInStringa.TabIndex = 4;
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
            this.splitContainer1.Panel1.Controls.Add(this.butAnalisi);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxInStringa);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCampo1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCampo4);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCampo2);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxCampo3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxOut);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 5;
            // 
            // richTextBoxOut
            // 
            this.richTextBoxOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOut.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxOut.Name = "richTextBoxOut";
            this.richTextBoxOut.Size = new System.Drawing.Size(800, 221);
            this.richTextBoxOut.TabIndex = 0;
            this.richTextBoxOut.Text = "";
            // 
            // butAnalisi
            // 
            this.butAnalisi.Location = new System.Drawing.Point(695, 26);
            this.butAnalisi.Name = "butAnalisi";
            this.butAnalisi.Size = new System.Drawing.Size(75, 23);
            this.butAnalisi.TabIndex = 5;
            this.butAnalisi.Text = "Analisi";
            this.butAnalisi.UseVisualStyleBackColor = true;
            this.butAnalisi.Click += new System.EventHandler(this.butAnalisi_Click);
            // 
            // FormGstValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormGstValue";
            this.Text = "FormGstValue";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCampo1;
        private System.Windows.Forms.TextBox textBoxCampo2;
        private System.Windows.Forms.TextBox textBoxCampo3;
        private System.Windows.Forms.TextBox textBoxCampo4;
        private System.Windows.Forms.TextBox textBoxInStringa;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butAnalisi;
        private System.Windows.Forms.RichTextBox richTextBoxOut;
    }
}
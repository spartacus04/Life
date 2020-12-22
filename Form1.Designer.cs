namespace Life
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.DebugBtn = new System.Windows.Forms.Button();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nuova Generazione";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DebugBtn
            // 
            this.DebugBtn.Location = new System.Drawing.Point(545, 388);
            this.DebugBtn.Name = "DebugBtn";
            this.DebugBtn.Size = new System.Drawing.Size(145, 23);
            this.DebugBtn.TabIndex = 2;
            this.DebugBtn.Text = "Debug";
            this.DebugBtn.UseVisualStyleBackColor = true;
            this.DebugBtn.Visible = false;
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(546, 12);
            this.NumberTextBox.MaxLength = 2;
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.ShortcutsEnabled = false;
            this.NumberTextBox.Size = new System.Drawing.Size(144, 20);
            this.NumberTextBox.TabIndex = 3;
            this.NumberTextBox.Text = "4";
            this.NumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumberTextBox.TextChanged += new System.EventHandler(this.NumberTextBox_TextChanged);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Location = new System.Drawing.Point(12, 12);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(400, 400);
            this.ButtonPanel.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(546, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Resetta Griglia";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 422);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.DebugBtn);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Il gioco della vita";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DebugBtn;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button button2;
    }
}


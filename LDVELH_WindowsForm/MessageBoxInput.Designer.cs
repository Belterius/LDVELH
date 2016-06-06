namespace LDVELH_WindowsForm
{
    partial class MessageBoxInput
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
            this.textBoxCharacterName = new System.Windows.Forms.TextBox();
            this.labelContent = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCharacterName
            // 
            this.textBoxCharacterName.Location = new System.Drawing.Point(167, 48);
            this.textBoxCharacterName.Name = "textBoxCharacterName";
            this.textBoxCharacterName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCharacterName.TabIndex = 0;
            this.textBoxCharacterName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(71, 51);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(90, 13);
            this.labelContent.TabIndex = 1;
            this.labelContent.Text = "Character Name :";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(131, 98);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // MessageBoxInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 133);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.textBoxCharacterName);
            this.Name = "MessageBoxInput";
            this.Text = "MessageBoxInput";
            this.Load += new System.EventHandler(this.MessageBoxInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCharacterName;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Button buttonOK;
    }
}
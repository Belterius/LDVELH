namespace LDVELH_WindowsForm
{
    partial class Form1
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
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.labelHitPointDescription = new System.Windows.Forms.Label();
            this.labelHitPoint = new System.Windows.Forms.Label();
            this.groupBoxInventory = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxChoices = new System.Windows.Forms.GroupBox();
            this.labelAgilityDescription = new System.Windows.Forms.Label();
            this.labelAgility = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelWeapon = new System.Windows.Forms.Label();
            this.labelSpecialItems = new System.Windows.Forms.Label();
            this.labelGoldAmount = new System.Windows.Forms.Label();
            this.labelBackPack = new System.Windows.Forms.Label();
            this.buttonThrowBackPackItem = new System.Windows.Forms.Button();
            this.buttonThrowWeapon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxStats.SuspendLayout();
            this.groupBoxInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.labelAgilityDescription);
            this.groupBoxStats.Controls.Add(this.labelAgility);
            this.groupBoxStats.Controls.Add(this.labelHitPointDescription);
            this.groupBoxStats.Controls.Add(this.labelHitPoint);
            this.groupBoxStats.Location = new System.Drawing.Point(0, 0);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(511, 62);
            this.groupBoxStats.TabIndex = 0;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Hero Stats";
            // 
            // labelHitPointDescription
            // 
            this.labelHitPointDescription.AutoSize = true;
            this.labelHitPointDescription.Location = new System.Drawing.Point(42, 29);
            this.labelHitPointDescription.Name = "labelHitPointDescription";
            this.labelHitPointDescription.Size = new System.Drawing.Size(58, 13);
            this.labelHitPointDescription.TabIndex = 2;
            this.labelHitPointDescription.Text = "Hit Points :";
            // 
            // labelHitPoint
            // 
            this.labelHitPoint.AutoSize = true;
            this.labelHitPoint.Location = new System.Drawing.Point(106, 29);
            this.labelHitPoint.Name = "labelHitPoint";
            this.labelHitPoint.Size = new System.Drawing.Size(36, 13);
            this.labelHitPoint.TabIndex = 3;
            this.labelHitPoint.Text = "20/20";
            // 
            // groupBoxInventory
            // 
            this.groupBoxInventory.Controls.Add(this.buttonThrowWeapon);
            this.groupBoxInventory.Controls.Add(this.buttonThrowBackPackItem);
            this.groupBoxInventory.Controls.Add(this.labelBackPack);
            this.groupBoxInventory.Controls.Add(this.labelGoldAmount);
            this.groupBoxInventory.Controls.Add(this.labelSpecialItems);
            this.groupBoxInventory.Controls.Add(this.labelWeapon);
            this.groupBoxInventory.Controls.Add(this.labelGold);
            this.groupBoxInventory.Controls.Add(this.listBox3);
            this.groupBoxInventory.Controls.Add(this.listBox2);
            this.groupBoxInventory.Controls.Add(this.listBox1);
            this.groupBoxInventory.Location = new System.Drawing.Point(517, 0);
            this.groupBoxInventory.Name = "groupBoxInventory";
            this.groupBoxInventory.Size = new System.Drawing.Size(167, 607);
            this.groupBoxInventory.TabIndex = 0;
            this.groupBoxInventory.TabStop = false;
            this.groupBoxInventory.Text = "Inventory";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(37, 68);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(452, 268);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // groupBoxChoices
            // 
            this.groupBoxChoices.Location = new System.Drawing.Point(37, 342);
            this.groupBoxChoices.Name = "groupBoxChoices";
            this.groupBoxChoices.Size = new System.Drawing.Size(452, 180);
            this.groupBoxChoices.TabIndex = 1;
            this.groupBoxChoices.TabStop = false;
            this.groupBoxChoices.Text = "Choices";
            // 
            // labelAgilityDescription
            // 
            this.labelAgilityDescription.AutoSize = true;
            this.labelAgilityDescription.Location = new System.Drawing.Point(168, 29);
            this.labelAgilityDescription.Name = "labelAgilityDescription";
            this.labelAgilityDescription.Size = new System.Drawing.Size(40, 13);
            this.labelAgilityDescription.TabIndex = 6;
            this.labelAgilityDescription.Text = "Agility :";
            // 
            // labelAgility
            // 
            this.labelAgility.AutoSize = true;
            this.labelAgility.Location = new System.Drawing.Point(214, 29);
            this.labelAgility.Name = "labelAgility";
            this.labelAgility.Size = new System.Drawing.Size(19, 13);
            this.labelAgility.TabIndex = 7;
            this.labelAgility.Text = "20";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 100);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 43);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(11, 221);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 1;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(11, 385);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 199);
            this.listBox3.TabIndex = 2;
            // 
            // labelGold
            // 
            this.labelGold.AutoSize = true;
            this.labelGold.Location = new System.Drawing.Point(19, 29);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(35, 13);
            this.labelGold.TabIndex = 3;
            this.labelGold.Text = "Gold :";
            // 
            // labelWeapon
            // 
            this.labelWeapon.AutoSize = true;
            this.labelWeapon.Location = new System.Drawing.Point(19, 84);
            this.labelWeapon.Name = "labelWeapon";
            this.labelWeapon.Size = new System.Drawing.Size(54, 13);
            this.labelWeapon.TabIndex = 4;
            this.labelWeapon.Text = "Weapon :";
            // 
            // labelSpecialItems
            // 
            this.labelSpecialItems.AutoSize = true;
            this.labelSpecialItems.Location = new System.Drawing.Point(19, 369);
            this.labelSpecialItems.Name = "labelSpecialItems";
            this.labelSpecialItems.Size = new System.Drawing.Size(76, 13);
            this.labelSpecialItems.TabIndex = 5;
            this.labelSpecialItems.Text = "Special Items :";
            // 
            // labelGoldAmount
            // 
            this.labelGoldAmount.AutoSize = true;
            this.labelGoldAmount.Location = new System.Drawing.Point(29, 49);
            this.labelGoldAmount.Name = "labelGoldAmount";
            this.labelGoldAmount.Size = new System.Drawing.Size(65, 13);
            this.labelGoldAmount.TabIndex = 6;
            this.labelGoldAmount.Text = "GoldAmount";
            // 
            // labelBackPack
            // 
            this.labelBackPack.AutoSize = true;
            this.labelBackPack.Location = new System.Drawing.Point(19, 205);
            this.labelBackPack.Name = "labelBackPack";
            this.labelBackPack.Size = new System.Drawing.Size(63, 13);
            this.labelBackPack.TabIndex = 7;
            this.labelBackPack.Text = "BackPack :";
            // 
            // buttonThrowBackPackItem
            // 
            this.buttonThrowBackPackItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThrowBackPackItem.Location = new System.Drawing.Point(32, 316);
            this.buttonThrowBackPackItem.Name = "buttonThrowBackPackItem";
            this.buttonThrowBackPackItem.Size = new System.Drawing.Size(75, 23);
            this.buttonThrowBackPackItem.TabIndex = 3;
            this.buttonThrowBackPackItem.Text = "Throw Item";
            this.buttonThrowBackPackItem.UseVisualStyleBackColor = true;
            // 
            // buttonThrowWeapon
            // 
            this.buttonThrowWeapon.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThrowWeapon.Location = new System.Drawing.Point(32, 149);
            this.buttonThrowWeapon.Name = "buttonThrowWeapon";
            this.buttonThrowWeapon.Size = new System.Drawing.Size(75, 23);
            this.buttonThrowWeapon.TabIndex = 8;
            this.buttonThrowWeapon.Text = "Throw Weapon";
            this.buttonThrowWeapon.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 528);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 619);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxChoices);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBoxInventory);
            this.Controls.Add(this.groupBoxStats);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.groupBoxInventory.ResumeLayout(false);
            this.groupBoxInventory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.GroupBox groupBoxInventory;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxChoices;
        private System.Windows.Forms.Label labelHitPointDescription;
        private System.Windows.Forms.Label labelHitPoint;
        private System.Windows.Forms.Label labelAgilityDescription;
        private System.Windows.Forms.Label labelAgility;
        private System.Windows.Forms.Button buttonThrowWeapon;
        private System.Windows.Forms.Button buttonThrowBackPackItem;
        private System.Windows.Forms.Label labelBackPack;
        private System.Windows.Forms.Label labelGoldAmount;
        private System.Windows.Forms.Label labelSpecialItems;
        private System.Windows.Forms.Label labelWeapon;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}


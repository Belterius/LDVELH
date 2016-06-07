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
            this.labelAgilityDescription = new System.Windows.Forms.Label();
            this.labelAgility = new System.Windows.Forms.Label();
            this.labelHitPointDescription = new System.Windows.Forms.Label();
            this.labelHitPoint = new System.Windows.Forms.Label();
            this.groupBoxInventory = new System.Windows.Forms.GroupBox();
            this.buttonThrowWeapon = new System.Windows.Forms.Button();
            this.buttonThrowBackPackItem = new System.Windows.Forms.Button();
            this.labelBackPack = new System.Windows.Forms.Label();
            this.labelGoldAmount = new System.Windows.Forms.Label();
            this.labelSpecialItems = new System.Windows.Forms.Label();
            this.labelWeapon = new System.Windows.Forms.Label();
            this.labelGold = new System.Windows.Forms.Label();
            this.listBoxSpecialItem = new System.Windows.Forms.ListBox();
            this.listBoxBackPack = new System.Windows.Forms.ListBox();
            this.listBoxWeapon = new System.Windows.Forms.ListBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxChoices = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.buttonUseItem = new System.Windows.Forms.Button();
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
            this.groupBoxInventory.Controls.Add(this.buttonUseItem);
            this.groupBoxInventory.Controls.Add(this.buttonThrowWeapon);
            this.groupBoxInventory.Controls.Add(this.buttonThrowBackPackItem);
            this.groupBoxInventory.Controls.Add(this.labelBackPack);
            this.groupBoxInventory.Controls.Add(this.labelGoldAmount);
            this.groupBoxInventory.Controls.Add(this.labelSpecialItems);
            this.groupBoxInventory.Controls.Add(this.labelWeapon);
            this.groupBoxInventory.Controls.Add(this.labelGold);
            this.groupBoxInventory.Controls.Add(this.listBoxSpecialItem);
            this.groupBoxInventory.Controls.Add(this.listBoxBackPack);
            this.groupBoxInventory.Controls.Add(this.listBoxWeapon);
            this.groupBoxInventory.Location = new System.Drawing.Point(517, 0);
            this.groupBoxInventory.Name = "groupBoxInventory";
            this.groupBoxInventory.Size = new System.Drawing.Size(167, 607);
            this.groupBoxInventory.TabIndex = 0;
            this.groupBoxInventory.TabStop = false;
            this.groupBoxInventory.Text = "Inventory";
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
            this.buttonThrowWeapon.Click += new System.EventHandler(this.buttonThrowWeapon_Click);
            // 
            // buttonThrowBackPackItem
            // 
            this.buttonThrowBackPackItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThrowBackPackItem.Location = new System.Drawing.Point(86, 322);
            this.buttonThrowBackPackItem.Name = "buttonThrowBackPackItem";
            this.buttonThrowBackPackItem.Size = new System.Drawing.Size(75, 23);
            this.buttonThrowBackPackItem.TabIndex = 3;
            this.buttonThrowBackPackItem.Text = "Throw Item";
            this.buttonThrowBackPackItem.UseVisualStyleBackColor = true;
            this.buttonThrowBackPackItem.Click += new System.EventHandler(this.buttonThrowBackPackItem_Click);
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
            // labelGoldAmount
            // 
            this.labelGoldAmount.AutoSize = true;
            this.labelGoldAmount.Location = new System.Drawing.Point(29, 49);
            this.labelGoldAmount.Name = "labelGoldAmount";
            this.labelGoldAmount.Size = new System.Drawing.Size(65, 13);
            this.labelGoldAmount.TabIndex = 6;
            this.labelGoldAmount.Text = "GoldAmount";
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
            // labelWeapon
            // 
            this.labelWeapon.AutoSize = true;
            this.labelWeapon.Location = new System.Drawing.Point(19, 84);
            this.labelWeapon.Name = "labelWeapon";
            this.labelWeapon.Size = new System.Drawing.Size(54, 13);
            this.labelWeapon.TabIndex = 4;
            this.labelWeapon.Text = "Weapon :";
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
            // listBoxSpecialItem
            // 
            this.listBoxSpecialItem.FormattingEnabled = true;
            this.listBoxSpecialItem.Location = new System.Drawing.Point(11, 385);
            this.listBoxSpecialItem.Name = "listBoxSpecialItem";
            this.listBoxSpecialItem.Size = new System.Drawing.Size(150, 199);
            this.listBoxSpecialItem.TabIndex = 2;
            // 
            // listBoxBackPack
            // 
            this.listBoxBackPack.FormattingEnabled = true;
            this.listBoxBackPack.Location = new System.Drawing.Point(11, 221);
            this.listBoxBackPack.Name = "listBoxBackPack";
            this.listBoxBackPack.Size = new System.Drawing.Size(150, 95);
            this.listBoxBackPack.TabIndex = 1;
            // 
            // listBoxWeapon
            // 
            this.listBoxWeapon.FormattingEnabled = true;
            this.listBoxWeapon.Location = new System.Drawing.Point(11, 100);
            this.listBoxWeapon.Name = "listBoxWeapon";
            this.listBoxWeapon.Size = new System.Drawing.Size(150, 43);
            this.listBoxWeapon.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "AddGold";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 561);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "RemoveGold";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(199, 528);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "AddSPItem";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(199, 561);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "RemoveSPItem";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(37, 528);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "AddHP";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(37, 561);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "RemoveHP";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(280, 528);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "AddItem";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(280, 561);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "RemoveItem";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(361, 561);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "RemoveWeapon";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(361, 528);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "AddWeapon";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // buttonUseItem
            // 
            this.buttonUseItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUseItem.Location = new System.Drawing.Point(6, 322);
            this.buttonUseItem.Name = "buttonUseItem";
            this.buttonUseItem.Size = new System.Drawing.Size(75, 23);
            this.buttonUseItem.TabIndex = 9;
            this.buttonUseItem.Text = "Use Item";
            this.buttonUseItem.UseVisualStyleBackColor = true;
            this.buttonUseItem.Click += new System.EventHandler(this.buttonUseItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 619);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
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
        private System.Windows.Forms.ListBox listBoxSpecialItem;
        private System.Windows.Forms.ListBox listBoxBackPack;
        private System.Windows.Forms.ListBox listBoxWeapon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button buttonUseItem;
    }
}


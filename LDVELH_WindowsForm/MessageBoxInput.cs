using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDVELH_WindowsForm
{
    public partial class MessageBoxInput : Form
    {
        public MessageBoxInput()
        {
            InitializeComponent();
            this.Text = "Select a character name";
        }
        public MessageBoxInput(string title, string content)
        {
            InitializeComponent();
            this.Text = title;
            labelContent.Text = content;
        }

        private void MessageBoxInput_Load(object sender, EventArgs e)
        {
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public string getCharacterName
        {
            get { return textBoxCharacterName.Text; }
        }
    }
}

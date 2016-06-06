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
    public partial class Form1 : Form
    {
        Hero hero;
        CharacterObserver testObs;
        HeroObserver heroObserver;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initHero(ShowMyDialogBox());
            this.Text = hero.getName();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void initHero(String name)
        {
            hero = new Hero(name);
            heroHPListener();
            heroGoldListener();
            
        }
        private void heroHPListener()
        {
            testObs = new CharacterObserver(labelHitPoint);
            hero.HitPointChanged += testObs.HitPointChanged;
            labelHitPoint.Text = hero.getActualHitPoint().ToString() + "/" + hero.getMaxHitPoint().ToString();
            labelAgility.Text = hero.getBaseAgility().ToString();
        }
        private void heroGoldListener()
        {
            heroObserver = new HeroObserver(labelGoldAmount, listBox1, listBox2, listBox3);
            hero.GoldChanged += heroObserver.GoldChanged;
            labelGoldAmount.Text = hero.getGold().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hero.takeDamage(2);
            }
            catch (YouAreDeadException)
            {
                MessageBox.Show("You died !");
                initHero(hero.getName());
                
            }
        }
        public string ShowMyDialogBox()
        {
            MessageBoxInput testDialog = new MessageBoxInput();

            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (testDialog.getCharacterName != "")
                {
                    testDialog.Dispose();
                    return testDialog.getCharacterName;
                }
                else
                {
                    testDialog.Dispose();
                    return "NoName";
                }
                    
            }
            else
            {
                testDialog.Dispose();
                return "NoName";
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            hero.addGold(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hero.removeGold(2);
        }

    }
}

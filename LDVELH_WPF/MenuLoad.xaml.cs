using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for LoadMenu.xaml
    /// </summary>
    public partial class MenuLoad : Window
    {
        List<Hero> listHeroes;
        public MenuLoad()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using(HeroSaveContext heroSaveContext = new HeroSaveContext()){

                var query = from hero in heroSaveContext.MyHero
                            select hero;
                listHeroes = query.ToList();
                listBoxHeroes.ItemsSource = listHeroes;
                listBoxHeroes.DisplayMemberPath = "getResume";
                listBoxHeroes.SelectedValuePath = "CharacterID";
            }
        }

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            using(HeroSaveContext heroSaveContext = new HeroSaveContext()){
                try
                {
                    heroSaveContext.MyBackPack.Load();
                    heroSaveContext.MyHero.Load();
                    heroSaveContext.MyItems.Load();
                    heroSaveContext.MySpecialItem.Load();
                    heroSaveContext.MyWeaponHolders.Load();
                    heroSaveContext.MyWeapons.Load();
                    heroSaveContext.MyCapacities.Load();
                    Hero heroSelected = heroSaveContext.MyHero.Where(x => x.CharacterID.ToString() == listBoxHeroes.SelectedValue.ToString()).First();
                    MainWindow mainWindow = new MainWindow(heroSelected);
                    mainWindow.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading the Hero : " + ex);
                }
            }

        }
    }
}

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

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MenuCapacities.xaml
    /// </summary>
    public partial class MenuCapacities : Window
    {
        int allowedNumberCapacities = 2;
        Hero hero;
        MainWindow mainWindow;

        public MenuCapacities()
        {
            InitializeComponent();
        }
        public MenuCapacities(Hero hero, MainWindow mainWindow)
        {
            InitializeComponent();
            this.hero = hero;
            this.mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numberOfCapacities = 0;
            foreach (var item in ((Grid)(groupBoxCapacities.Content)).Children)
            {
                if (item is CapacityCheckBox)
                {
                    CapacityCheckBox checkbox = (CapacityCheckBox)item;
                    if ((bool)checkbox.IsChecked)
                    {
                        numberOfCapacities++;
                    }

                }
            }
            if (numberOfCapacities != allowedNumberCapacities)
            {
                MessageBox.Show("You must select " + allowedNumberCapacities + " capacities !");
                return;
            }
            foreach (var item in ((Grid)(groupBoxCapacities.Content)).Children)
            {
                if (item is CapacityCheckBox)
                {
                    CapacityCheckBox checkbox = (CapacityCheckBox)item;
                    if ((bool)checkbox.IsChecked)
                    {
                        hero.addCapacity(checkbox.myCapacity);
                    }

                }
            }

            mainWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int top = 0;
            int bottom = 0;
            int left = 0;
            int right = 0;
            foreach (CapacityType capaType in Enum.GetValues(typeof(CapacityType)))
            {
                CapacityCheckBox checkbox = new CapacityCheckBox();
                checkbox.Name = capaType.ToString();
                checkbox.myCapacity = new Capacity(capaType);
                checkbox.Margin = new Thickness(left, top, right, bottom);
                Label label = new Label();
                label.Content = capaType.ToString();
                label.Margin = new Thickness(left+20, top - 5, 0, 0);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(checkbox);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(label);
                top += 20;
            }
        }
    }

    public class CapacityCheckBox : CheckBox
    {
        Capacity _myCapacity;
        public Capacity myCapacity
        {
            get { return _myCapacity; }
            set { _myCapacity = value; }
        }

        public CapacityCheckBox()
        {
        }
    }
}

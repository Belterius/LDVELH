using LDVELH_WPF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MenuCapacities.xaml
    /// </summary>
    public partial class MenuCapacities : Window
    {
        static readonly int allowedNumberCapacities = 5;

        public MenuCapacities()
        {
            InitializeComponent();
            TranslateLabel();
        }

        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.translator.ProvideValue("MenuCapacities");
            groupBoxCapacities.Header = GlobalTranslator.Instance.translator.ProvideValue("ListCapacities");
            ButtonConfirm.Content = GlobalTranslator.Instance.translator.ProvideValue("Confirm");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hero Hero = new Hero(labelHeroName.Content.ToString());
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
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("YouMustSelect") + " " + allowedNumberCapacities + " " + GlobalTranslator.Instance.translator.ProvideValue("Capacities") + " !");
                return;
            }
            foreach (var item in ((Grid)(groupBoxCapacities.Content)).Children)
            {
                if (item is CapacityCheckBox)
                {
                    CapacityCheckBox checkbox = (CapacityCheckBox)item;
                    if ((bool)checkbox.IsChecked)
                    {
                        Hero.addCapacity(checkbox.myCapacity);
                    }

                }
            }

            MainWindow mainWindow = new MainWindow() { DataContext = new MainWindowViewModel(Hero, false) };
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
                Capacity myCapacity = new Capacity(capaType);
                CapacityCheckBox checkbox = new CapacityCheckBox();
                checkbox.Name = capaType.ToString();
                checkbox.myCapacity = myCapacity;
                checkbox.Margin = new Thickness(left, top, right, bottom);
                Label label = new Label();
                label.Content = myCapacity.CapacityKind.GetTranslation(); 
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

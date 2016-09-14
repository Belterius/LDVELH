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
        static readonly int AllowedNumberCapacities = 5;

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
            int NumberOfCapacities = 0;
            foreach (var Item in ((Grid)(groupBoxCapacities.Content)).Children)
            {
                if (Item is CapacityCheckBox)
                {
                    CapacityCheckBox checkbox = (CapacityCheckBox)Item;
                    if ((bool)checkbox.IsChecked)
                    {
                        NumberOfCapacities++;
                    }

                }
            }
            if (NumberOfCapacities != AllowedNumberCapacities)
            {
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("YouMustSelect") + " " + AllowedNumberCapacities + " " + GlobalTranslator.Instance.translator.ProvideValue("Capacities") + " !");
                return;
            }
            foreach (var Item in ((Grid)(groupBoxCapacities.Content)).Children)
            {
                if (Item is CapacityCheckBox)
                {
                    CapacityCheckBox checkbox = (CapacityCheckBox)Item;
                    if ((bool)checkbox.IsChecked)
                    {
                        Hero.AddCapacity(checkbox.MyCapacity);
                    }

                }
            }

            MainWindow MainWindow = new MainWindow() { DataContext = new MainWindowViewModel(Hero, false) };
            MainWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int Top = 0;
            int Bottom = 0;
            int Left = 0;
            int Right = 0;
            foreach (CapacityType CapaType in Enum.GetValues(typeof(CapacityType)))
            {
                Capacity myCapacity = new Capacity(CapaType);
                CapacityCheckBox Checkbox = new CapacityCheckBox();
                Checkbox.Name = CapaType.ToString();
                Checkbox.MyCapacity = myCapacity;
                Checkbox.Margin = new Thickness(Left, Top, Right, Bottom);
                Label Label = new Label();
                Label.Content = myCapacity.CapacityKind.GetTranslation(); 
                Label.Margin = new Thickness(Left+20, Top - 5, 0, 0);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(Checkbox);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(Label);
                Top += 20;
            }
        }
    }

    public class CapacityCheckBox : CheckBox
    {
        Capacity _myCapacity;
        public Capacity MyCapacity
        {
            get { return _myCapacity; }
            set { _myCapacity = value; }
        }

        public CapacityCheckBox()
        {
        }
    }
}

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
        public MenuCapacities()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int Top = 0;
            int Bottom = 0;
            int Left = 0;
            int Right = 0;
            foreach (CapacityType CapaType in Enum.GetValues(typeof(CapacityType)))
            {
                CapacityCheckBox MyCheckbox = new CapacityCheckBox();
                MyCheckbox.Name = CapaType.ToString();
                MyCheckbox.MyCapacity = CapaType;
                MyCheckbox.Margin = new Thickness(Left, Top, Right, Bottom);
                MyCheckbox.Checked += CheckBox_Checked;
                MyCheckbox.Unchecked += CheckBox_UnChecked;
                System.Windows.Forms.CheckBox test = new System.Windows.Forms.CheckBox();
                Label Label = new Label();
                Label.Content = MyCheckbox.MyCapacity.GetTranslation();
                Label.ToolTip = GlobalTranslator.Instance.Translator.ProvideValue("ToolTip" + MyCheckbox.MyCapacity.ToString());
                Label.Margin = new Thickness(Left+20, Top - 5, 0, 0);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(MyCheckbox);
                ((Grid)(groupBoxCapacities.Content)).Children.Add(Label);
                Top += 20;
            }
        }
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            if (((MenuCapacitiesViewModel)DataContext).Hero.Capacities.Count >= ((MenuCapacitiesViewModel)DataContext).Hero.MaxNumberOfCapacities)
            {
                //Ugly Hack.
                //I know that if my Hero already has reached his max number of capacities, I won't be able to add a new one.
                //Problem : I am still ticking the checkbox, for an un-added capacity.
                //Per MVVM View, my RelayCommand cannot send me back if it managed to add the Capacity or not.
                //I cannot either bind my IsChecked property on one of my View Model property as it would break the build each time you create a new Capacity.
                //I am not sure if it is better to keep the Add and Remove Method in the ViewModel and do the hack, or do the Add and Remove Method here without the hack.
                //I decided that I prefer not to do any operation on my Data in the View.

                //Won't add the capacity so we make sure to uncheck the box, the additional call to CheckBox_Unchecked won't matter
                ((CapacityCheckBox)sender).IsChecked = false;
            }
            ((MenuCapacitiesViewModel)DataContext).AddCapacityCommand.Execute(((CapacityCheckBox)sender).MyCapacity);
        }
        private void CheckBox_UnChecked(object sender, EventArgs e)
        {
            ((MenuCapacitiesViewModel)DataContext).RemoveCapacityCommand.Execute(((CapacityCheckBox)sender).MyCapacity);
        }
    }

    public class CapacityCheckBox : CheckBox
    {
        CapacityType _myCapacity;
        
        public CapacityType MyCapacity
        {
            get { return _myCapacity; }
            set { _myCapacity = value;}
        }
        
        public CapacityCheckBox()
        {
        }
    }
}

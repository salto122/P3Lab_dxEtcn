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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Scripts scripts = new Scripts();
        DB db = new DB();
        public MainWindow() {
            InitializeComponent();
        }

        public void Login(object sender, EventArgs e) {
            int logState = scripts.LoginUser(loginName.Text, passwordName.Text);
            var converter = new System.Windows.Media.BrushConverter();

            Console.WriteLine(logState);

            if (logState == 0) {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#BDBDBD");
            } else if (logState == 1) {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#FFFFBBBB");
                this.Title = "Błędne dane logowania";
            } else if (logState == 2)  {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#99FF9A");
                this.Title = "Witaj " + loginName.Text;

                foreach(Classes value in db.GetClasses()) {
                    classList.Items.Add(value.Name);
                }
            }
        }

        public void SelectClass(object sender, EventArgs e) {
            dataGrid.ItemsSource = db.GetGradesClass(classList.Items[classList.SelectedIndex].ToString());
        }

        public void Search(object sender, EventArgs e) {
            
        }
    }
}

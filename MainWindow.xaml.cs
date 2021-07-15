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
using System.Text.RegularExpressions;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Scripts scripts = new Scripts();
        DB db = new DB();
        bool isLogedIn = false;

        public MainWindow() {
            InitializeComponent();
        }

        public void Login(object sender, EventArgs e) {
            bool logState = scripts.LoginUser(loginName.Text, passwordName.Text);
            var converter = new System.Windows.Media.BrushConverter();

            if (logState) {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#FFFFBBBB");
                this.Title = "Błędne dane logowania";
            } else {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#99FF9A");
                
                if(!isLogedIn) {
                    this.Title = "Witaj " + loginName.Text;

                    foreach (Classes value in db.GetClasses()){
                        classList.Items.Add(value.Name);
                    }

                    if (true) {     //IF ADMIN
                        BarOperator(true);
                        panelClasses.ItemsSource = db.GetClass().Select(x => x.Class);
                        panelClass.ItemsSource = db.GetClasses().Select(x => x.Name);
                    }

                    isLogedIn = true;
                }
            }
        }

        public void BarOperator(bool enableStatus) {
            searchClass.IsEnabled = enableStatus;
            searchName.IsEnabled = enableStatus;
            searchSurname.IsEnabled = enableStatus;
            searchButton.IsEnabled = enableStatus;
            panel.Visibility = enableStatus ? Visibility.Visible : Visibility.Hidden;
        }

        public void Search(object sender, EventArgs e) {
            dataGrid.ItemsSource = db.GetGradesClass(classList.Items[classList.SelectedIndex].ToString(), searchClass.Text, searchName.Text, searchSurname.Text);
        }

        private void Logout(object sender, RoutedEventArgs e) {
            var converter = new System.Windows.Media.BrushConverter();
            LoginBackground.Background = (Brush)converter.ConvertFromString("#BDBDBD");
            classList.Items.Clear();
            BarOperator(false);
            this.Title = "Niezalogowany";
            isLogedIn = false;
        }

        public void BlockPanel() {

        }

        private void PanelSelectedClass(object sender, RoutedEventArgs e) {
            panelName.ItemsSource = db.GetUsers(panelClasses.SelectedItem.ToString()).Select(x => x.Name + " " + x.Surname);
        }

        private void PreviewPanel(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PanelAdd(object sender, RoutedEventArgs e) {
            db.AddGrade();
        }

    }
}

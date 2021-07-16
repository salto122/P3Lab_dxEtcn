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
        User user;
        //int userID;

        public MainWindow() {
            InitializeComponent();
        }

        public void Login(object sender, EventArgs e) {
            //bool logState = scripts.LoginUser(loginName.Text, passwordName.Text);
            user = db.LoginUser(loginName.Text, passwordName.Text);
            Console.WriteLine(user);
            var converter = new System.Windows.Media.BrushConverter();

            if (user is null) {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#FFFFBBBB");
                this.Title = "Błędne dane logowania";
            } else {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#99FF9A");

                if(!isLogedIn) {
                    this.Title = "Witaj " + loginName.Text;
                    //userID = db.GetLogedData(loginName.Text, passwordName.Text);

                    foreach (Classes value in db.GetClasses()){
                        classList.Items.Add(value.Name);
                    }

                    if (user.Admin) {
                        BarOperator(true);
                        panelClasses.ItemsSource = db.GetClass().Select(x => x.Class);
                        panelClass.ItemsSource = db.GetClasses().Select(x => x.ID + " " + x.Name);
                    } else {
                        searchClass.Text = user.Class;
                        searchName.Text = user.Name;
                        searchSurname.Text = user.Surname;
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
            panelName.ItemsSource = db.GetUsers(panelClasses.SelectedItem.ToString()).Select(x => x.ID + " " + x.Name + " " + x.Surname);
        }

        private void PreviewPanel(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PanelAdd(object sender, RoutedEventArgs e) {
            string studentID = panelName.SelectedItem.ToString().Split(' ').FirstOrDefault();
            string classID = panelClass.SelectedItem.ToString().Split(' ').FirstOrDefault();
            db.AddGrade(studentID, user.ID, classID, panelWage.Text, panelGrade.Text);
            MessageBox.Show("Pomyślnie dodano ocenę");
        }
        private void GridChange(object sender, RoutedEventArgs e) {
            DataGrid selectedGrid = dataGrid.SelectedItem as DataGrid;
            Console.WriteLine(selectedGrid.Name);
            
        }

    }
}

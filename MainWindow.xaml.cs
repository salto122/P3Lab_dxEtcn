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
    public partial class MainWindow : Window {
        DB db = new DB();
        bool isLogedIn = false;
        User user;

        public MainWindow() {
            InitializeComponent();

            foreach (Classes value in db.GetClasses()) {
                classList.Items.Add(value.Name);
            }
        }

        public void Login(object sender, EventArgs e) {
            user = db.LoginUser(loginName.Text, passwordName.Text);
            var converter = new System.Windows.Media.BrushConverter();

            if (user is null) {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#FFFFBBBB");
                this.Title = "Błędne dane logowania";
            } else {
                LoginBackground.Background = (Brush)converter.ConvertFromString("#99FF9A");

                if(!isLogedIn) {
                    this.Title = "Witaj " + loginName.Text;
                    classList.IsEnabled = true;

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
            RefreshGrid();
            panelDelete.IsEnabled = false;
        }

        public void RefreshGrid() {
            string classes = "";
 
            if(classList.SelectedIndex != -1) {
                classes = classList.Items[classList.SelectedIndex].ToString();
            }

            dataGrid.ItemsSource = db.GetGradesClass(classes, searchClass.Text, searchName.Text, searchSurname.Text);
        }

        private void Logout(object sender, RoutedEventArgs e) {
            var converter = new System.Windows.Media.BrushConverter();
            LoginBackground.Background = (Brush)converter.ConvertFromString("#BDBDBD");
            classList.IsEnabled = false;
            BarOperator(false);
            dataGrid.ItemsSource = null;
            panelDelete.IsEnabled = false;
            this.Title = "Niezalogowany";
            isLogedIn = false;
        }

        private void PanelSelectedClass(object sender, RoutedEventArgs e) {
            panelName.ItemsSource = db.GetUsers(panelClasses.SelectedItem.ToString()).Select(x => x.ID + " " + x.Name + " " + x.Surname);
        }

        private void PreviewPanel(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PanelAdd(object sender, RoutedEventArgs e) {
            string errMessage = "";

            if(panelClasses.SelectedItem is null)  {
                errMessage += "Podaj klasę ucznia\n";
            }

            if(panelName.SelectedItem is null) {
                errMessage += "Podaj imię oraz nazwisko ucznia\n";
            }            
            
            if(panelClass.SelectedItem is null) {
                errMessage += "Podaj nazwę przedmiotu\n";
            }

            if (string.IsNullOrEmpty(panelWage.Text)) {
                errMessage += "Podaj wagę\n";
            }            
            
            if (string.IsNullOrEmpty(panelGrade.Text)) {
                errMessage += "Podaj grade\n";
            }

            if(errMessage == "") {
                string studentID = panelName.SelectedItem.ToString().Split(' ').FirstOrDefault();
                string classID = panelClass.SelectedItem.ToString().Split(' ').FirstOrDefault();
                db.AddGrade(studentID, user.ID, classID, panelWage.Text, panelGrade.Text);
                MessageBox.Show("Pomyślnie dodano ocenę");
                RefreshGrid();
            } else {
                MessageBox.Show(errMessage);
            }
        }

        private void GridChange(object sender, RoutedEventArgs e) {
            panelDelete.IsEnabled = true;
        }        
        
        private void PanelDelete(object sender, RoutedEventArgs e) {
            DataGrid selectedGrid = dataGrid.SelectedItem as DataGrid;
            if(!(dataGrid.SelectedItem is null)) {
                db.DeleteGrade(selectedGrid.ID);
                panelDelete.IsEnabled = false;
                RefreshGrid();
            }
        }
    }
}

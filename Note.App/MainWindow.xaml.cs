using Note.Core;
using Note.Core.Data;
using Note.Core.Service;
using System.Windows;

namespace Note.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SecurityViewModel viewModel = new SecurityViewModel(new SecurityService(new SecurityRemoteDataSource()));
        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(viewModel.LoginCommand.CanExecute(null))
            {
                viewModel.LoginCommand.Execute(null);
                NotesWindow notesWindow = new NotesWindow();
                notesWindow.Show();
                this.Close();
            }
        }
    }
}
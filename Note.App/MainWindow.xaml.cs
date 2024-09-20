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
        private MainViewModel viewModel = new MainViewModel(new NoteService(new NoteDataSource()));
        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
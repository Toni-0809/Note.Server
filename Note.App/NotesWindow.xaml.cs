using Note.Core.Data;
using Note.Core.Service;
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

namespace Note.App
{
    /// <summary>
    /// Логика взаимодействия для NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        private NotesViewModel viewModel = new NotesViewModel(new NoteService(new NoteRemoteDataSource()));
        public NotesWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}

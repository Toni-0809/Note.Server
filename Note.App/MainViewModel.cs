using Note.App.Core;
using Note.Core.Entity;
using Note.Core.Service;
using System.Collections.ObjectModel;

namespace Note.App
{


    public class MainViewModel : ObservableObject
    {

        private string _input = string.Empty;
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
            }
        }

        private ObservableCollection<NoteEntity> _noteList = new ObservableCollection<NoteEntity>();
        public ObservableCollection<NoteEntity> NoteList { get => _noteList; set { _noteList = value; OnPropertyChanged("NoteList"); } }

        private NoteService _noteService;

        private NoteEntity _selectedNote;
        public NoteEntity SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public MainViewModel(NoteService service)
        {
            _noteService = service;
            NoteList = new ObservableCollection<NoteEntity>(_noteService.GetAll());
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      _noteService.Create(
                          new NoteEntity(Input)
                          );
                      NoteList = new ObservableCollection<NoteEntity>(_noteService.GetAll());
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      _noteService.Delete(
                          SelectedNote.ItemId
                          );
                      NoteList = new ObservableCollection<NoteEntity>(_noteService.GetAll());
                  }));
            }
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(obj =>
                  {
                      SelectedNote.Title = Input;
                      _noteService.Update(
                          SelectedNote
                          );
                      NoteList = new ObservableCollection<NoteEntity>(_noteService.GetAll());
                  }));
            }
        }


    }
}

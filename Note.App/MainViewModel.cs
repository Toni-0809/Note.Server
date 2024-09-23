using Note.App.Core;
using Note.Core.Entity;
using Note.Core.Service;
using Note_3.DTOs;
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

        private string _input2 = string.Empty;
        public string Input2
        {
            get => _input2;
            set
            {
                _input2 = value;
                OnPropertyChanged("Input2");
            }
        }

        private ObservableCollection<NotesDTO> _noteList = new ObservableCollection<NotesDTO>();
        public ObservableCollection<NotesDTO> NoteList { get => _noteList; set { _noteList = value; OnPropertyChanged("NoteList"); } }

        private NoteService _noteService;

        private NotesDTO _selectedNote;
        public NotesDTO SelectedNote
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
            Task.Run(() => Fetch());
        }

        public async Task Fetch()
        {
            NoteList = new ObservableCollection<NotesDTO>(await _noteService.GetAll());
        }

        private AsyncRelayCommand addCommand;
        public AsyncRelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (
                    addCommand = new AsyncRelayCommand(() => Task.Run(
                          async () =>
                          {
                              await _noteService.Create(new NotesDTO(0, Input, Input2, 1, 1));
                              await Fetch();

                          }))
                    );
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
                          SelectedNote.Id
                          );
                      Task.Run(() => Fetch());
                  }));
            }
        }
        private AsyncRelayCommand editCommand;
        public AsyncRelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new AsyncRelayCommand(() => Task.Run(
                      async () =>
                      {
                          await _notesService.Update(
                            new UpdateNotesDTO(
                                0,
                                Input,
                                Input2,
                                1,
                                1
                                )
                            );
                          await Fetch();
                      }))
                  );
            }
        }


    }
}

using Note.App.Core;
using Note.Core;
using Note.Core.Service;
using Note_3.DTOs;

namespace Note.App
{
    public class SecurityViewModel : ObservableObject
    {
        private SecurityService _securityService;

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

        public SecurityViewModel(SecurityService securityService)
        {
            this._securityService = securityService;
        }



        private AsyncRelayCommand registerCommand;
        public AsyncRelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ?? (
                    registerCommand = new AsyncRelayCommand(() => Task.Run(
                    async () =>
                    {
                              await _securityService.Register(new SecurityRequest(Input, Input2));
                          }))
                    );
            }
        }\

        private AsyncRelayCommand loginCommand;
        public AsyncRelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (
                    loginCommand = new AsyncRelayCommand(() => Task.Run(
                    async () =>
                    {
                        await _securityService.Login(new SecurityRequest(Input, Input2));
                    }))
                    );
            }
        }


    }
}
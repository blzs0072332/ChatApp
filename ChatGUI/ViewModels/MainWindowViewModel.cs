using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace ChatGUI.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string sender;
        private string inputMessage;
        private List<string> messages;

        public string Sender { get => sender; set => sender = value; }
        public string InputMessage
        {
            get { return inputMessage; }
            set { inputMessage = value; OnPropertyChanged(); (SendCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }

        public MainWindowViewModel()
        {

        }

    }
}

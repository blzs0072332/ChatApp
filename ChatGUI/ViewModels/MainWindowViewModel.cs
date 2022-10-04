using System;
using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Windows.Input;
using Workshop05.ClientApp;
using ChatServer.Models;
using System.ComponentModel;
using System.Windows;

namespace ChatGUI.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string sender;
        private string inputMessage;
        RestCollection<Message> Messages { get; set; }

        public ICommand SendCommand { get; set; }

        public string Sender { get => sender; set => sender = value; }
        public string InputMessage
        {
            get { return inputMessage; }
            set { inputMessage = value; OnPropertyChanged(); (SendCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }

        public static bool IsInDesigneMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {

        }

    }
}

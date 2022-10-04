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
        public RestCollection<Message> Messages { get; set; }

        public ICommand SendCommand { get; set; }

        public string Sender { get => sender; set => sender = value; }
        //public INameService NameService { get; set; }
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

            if (!IsInDesigneMode)
            {
                Messages = new RestCollection<Message>("http://localhost:44869/", "message", "hub");
                SendCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message() { sender = this.sender, msg = inputMessage });
                    inputMessage = "";
                }, () => { return inputMessage != null && inputMessage != ""; });

                //// Hidden dependency, sorry, quick solution, should be done /w IoC :)
                //NameService = new NameServiceViaWindow();

                //// Collection change event forward to code behind to scrollbar adjustment
                //Messages.CollectionChanged += Messages_CollectionChanged;

                //// Window Loaded event receiver
                //Messenger.Register<object, string, string>(this, "MainWindowLoaded", (recipient, msg) =>
                //{
                //    this.Sender = NameService.GetName();
                //});
            }
        }

    }
}

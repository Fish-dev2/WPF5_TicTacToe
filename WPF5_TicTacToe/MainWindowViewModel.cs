using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF5_TicTacToe
{
    internal class MainWindowViewModel : ObservableObject
    {
        public RestCollection<char> Table { get; set; }
        public char SelectedChar { get; set; }
        public int Pressed { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand PutLetter { get; set; }

        public MainWindowViewModel()
        {
            if (IsInDesignMode)
            {
                return;
            }
            string ip = "http://localhost:5246/";
            Table = new RestCollection<char>(ip, "table", "hub");

            //commands

        }
    }
}

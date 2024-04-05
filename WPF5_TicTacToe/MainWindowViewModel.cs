using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF5_TicTacToe
{
    internal class MainWindowViewModel : ObservableObject
    {
        public RestService<char> Table { get; set; }
        public char SelectedChar { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (IsInDesignMode)
            {
                return;
            }
            string ip = "http://localhost:53910/";
            Table = new RestService<char>(ip, "table", "hub");
        }
    }
}

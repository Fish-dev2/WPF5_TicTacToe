﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF5_TicTacToe.Models;

namespace WPF5_TicTacToe
{
    internal class MainWindowViewModel : ObservableObject
    {
        public RestCollection<Game> Table { get; set; }
        public Game[] TableReal { get; set; }

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
        public ICommand PutLetterCommand { get; set; }

        public MainWindowViewModel()
        {
            if (IsInDesignMode)
            {
                return;
            }
            string ip = "http://localhost:5246/";
            Table = new RestCollection<Game>(ip, "game", "hub");

            //commands
            PutLetterCommand = new RelayCommand(() =>
            {
                OnPropertyChanged();
                Table.Update(new Game()
                {
                    coord = Pressed,
                    letter = SelectedChar
                });
            });

        }
    }
}

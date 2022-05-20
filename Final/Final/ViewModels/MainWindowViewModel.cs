using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
//using Final.
using System.Collections.Specialized;


namespace Final.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Horse> Horse_var { get; set; }
        public ObservableCollection<Jockey> Jockey_var { get; set; }
        public ObservableCollection<Owner> Owner_var { get; set; }
        public ObservableCollection<Trainer> Trainer_var { get; set; }
        public ObservableCollection<Result> Result_var { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
            Horse_var = new ObservableCollection<Horse>();
            Jockey_var = new ObservableCollection<Jockey>();
            Owner_var = new ObservableCollection<Owner>();
            Trainer_var = new ObservableCollection<Trainer>();
            Result_var = new ObservableCollection<Result>();


            using (var db = new BDContext())
            {
                foreach (var item in db.Horses) Horse_var.Add(item);
                foreach (var item in db.Jockeys) Jockey_var.Add(item);
                foreach (var item in db.Owners) Owner_var.Add(item);
                foreach (var item in db.Trainers) Trainer_var.Add(item);
                foreach (var item in db.Results) Result_var.Add(item);
            }

            Content = new DataBaseViewModel();

        }
    }
}
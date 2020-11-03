using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorApp.Model;
using DBServices.Services;
using VisitorApp.Commands;
using System.Dynamic;
using System.Windows;
using VisitorApp.View;

namespace VisitorApp.ViewModel
{
    class TourListViewModel : BindableBase
    {
        public ObservableCollection<Tour> Tours { get; set; }
        private TourService TourService = new TourService();
        public MyCommand ViewSelectedTourCommand { get; set; }
        public MyCommand AddToMyTourCommand { get; set; }

        private Tour _selectedTour;

        public TourListViewModel()
        {
            LoadTours();
            ViewSelectedTourCommand = new MyCommand(ViewSelectedTour, SelectTour);
            AddToMyTourCommand = new MyCommand(AddToMyTour, SelectTour);
        }

        private void LoadTours()
        {
            ObservableCollection<Tour> tours = new ObservableCollection<Tour>();
            var tour_list = TourService.GetTours();

            foreach (var v in tour_list)
            {
                tours.Add(new Tour
                {
                    TourID = v.TourID,
                    Name = v.Name,
                    Price = v.Price,
                    Date = v.Date
                });
            }
            Tours = tours;
        }

        public Tour SelectedTour
        {
            get
            {
                return _selectedTour;
            }
            set
            {
                _selectedTour = value;
                ViewSelectedTourCommand.RaiseEventChange();
            }
        }
        
        private void AddToMyTour()
        {

        }

        private void ViewSelectedTour()
        {
            Window viewTourDialog = new ViewTourDialog(SelectedTour);
            viewTourDialog.ShowDialog();
            if(viewTourDialog.DialogResult.Value)
            {
                int user_id = (int) Application.Current.Resources["user_id"];

                if(TourService.AddToMyTour(user_id, SelectedTour.TourID))
                {
                    MessageBox.Show("Added to List");
                }
            }
        }

        private bool SelectTour()
        {
            return SelectedTour != null;
        }
    }
}

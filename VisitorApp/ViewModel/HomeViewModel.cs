using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DBServices.Services;
using VisitorApp.Model;

namespace VisitorApp.ViewModel
{
    class HomeViewModel : BindableBase
    {
        private TourService TourService = new TourService();
        public ObservableCollection<Tour> UserTour { get; set; }
        private Tour _selectedTour;

        public HomeViewModel()
        {
            LoadUserTour();
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
            }
        }

        private void LoadUserTour()
        {
            ObservableCollection<Tour> tours = new ObservableCollection<Tour>();

            int user_id = (int)Application.Current.Resources["user_id"];
            var tour = TourService.GetToursByID(user_id);

            foreach(var t in tour)
            {
                tours.Add(new Tour
                {
                    TourID = t.TourID,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price,
                    Date = t.Date,
                });
            }

            UserTour = tours;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorApp.Model
{
    class Tour : BaseModel
    {
        private int _tourID;
        private string _name;
        private float _price;
        private string _description;
        private DateTime _date;

        public int TourID
        {
            get
            {
                return _tourID;
            }
            set
            {
                _tourID = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        public float Price 
        {
            get
            {
                return _price;
            }
            set
            {
                if(_price != value)
                {
                    _price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }
        public DateTime Date 
        {
            get
            {
                return _date;
            }
            set
            {
                if(_date != value)
                {
                    _date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }
    }
}

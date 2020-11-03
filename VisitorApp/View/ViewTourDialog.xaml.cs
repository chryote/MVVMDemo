using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VisitorApp.Model;

namespace VisitorApp.View
{
    /// <summary>
    /// Interaction logic for ViewTourDialog.xaml
    /// </summary>
    public partial class ViewTourDialog : Window
    {
        private Tour Tour;
        public ViewTourDialog(object tour)
        {
            InitializeComponent();
            Tour = (Tour)tour;
            base.Title = Tour.Name;
            TourName.Text = Tour.Name;
            Price.Text = ((float)Tour.Price).ToString("N0");
            Date.Text = Tour.Date.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}

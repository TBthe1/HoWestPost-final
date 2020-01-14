using HoWestPost.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HoWestPost.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private MockingDeliveryService deliveryService;
        private Dispatcher _dispatcher;

        List<Thread> packageThreads = new List<Thread>();
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            deliveryService = new MockingDeliveryService();

            deliveryService.AddDelivery(new Delivery()
            {
                PackageType = "Maxi", //TO DO get name of the radio button 
                TravelTime = Convert.ToInt32(nNumberTraveltime.Text)
            });

            lstDeliveries.ItemsSource = deliveryService.CombinedDeliverySet;

            deliveryService.OnDeliveryAdded += UpdateListBoxOnDeliveryAdded;
            deliveryService.OnDeliveryAdded += UpdateLastDeliveryId;

            _dispatcher = Dispatcher.CurrentDispatcher;
        }
        #endregion

        #region Events
        private void UpdateListBoxOnDeliveryAdded(object sender, DeliveryEventArgs e)
        {
            Delivery newDelivery = e.NewDelivery;

            UpdateUitThread(() => lstDeliveries.Items.Refresh());
        }

        private void UpdateLastDeliveryId(object sender, DeliveryEventArgs e)
        {
            UpdateUitThread(() => txtDeliveryId.Text = e.NewDelivery.Id.ToString());
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Updates UI
        /// </summary>
        public void UpdateUitThread(Action handler)
        {
            _dispatcher.Invoke(handler);
        }
        #endregion

        #region Event Handlers
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            deliveryService.AddDelivery(new Delivery()
            {
                PackageType = "Maxi", //get name of the radio button 
                TravelTime = Convert.ToInt32(nNumberTraveltime.Text)
            });
        }
        #endregion

        #region Private Methods
        
        #endregion

    }
}

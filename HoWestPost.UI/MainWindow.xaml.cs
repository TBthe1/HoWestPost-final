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
        public Dispatcher _dispatcher;

        private PackageType _selectedType = PackageType.Standaard;
        private PackageType _selectedPriority = PackageType.regular;

        double totalTravelTime = 0;
        string selectedPackageType;
        bool checkIfPrior = false;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstDeliveries.ItemsSource = DeliveryService.Deliveries;

            DeliveryProcessor.ProgressUpdated += UpdateProgress;
            DeliveryProcessor.IdUpdated += UpdateId;
            DeliveryProcessor.RefreshList += UpdateListbox;
            DeliveryProcessor.ShowDeliveryData += UpdateDeliveryStatus;
            DeliveryProcessor.RemoveDeliveryData += DeleteDeliveryStatus;

            _dispatcher = Dispatcher.CurrentDispatcher;
        }
        #endregion

        #region Events
        #endregion

        #region Public Methods
        /// <summary>
        /// Updates UI
        /// </summary>
        public void UpdateGuiThread(Action handler)
        {
            _dispatcher.Invoke(handler);
        }

        public void UpdateProgress(string generalInfo, double progress, double remainingTime)
        {
            UpdateGuiThread(() => txtInfo.Text = generalInfo);
            UpdateGuiThread(() => progressBar.Value += progress);
            UpdateGuiThread(() => txtRestingTime.Text = remainingTime.ToString());
        }

        public void UpdateId(int currentId)
        {
            UpdateGuiThread(() => txtDeliveryId.Text = currentId.ToString());
        }

        public void UpdateListbox()
        {
            UpdateGuiThread(() => lstDeliveries.Items.Refresh());
        }

        public void UpdateDeliveryStatus()
        {
            UpdateGuiThread(() => txtTotalTraveltime.Text = totalTravelTime.ToString());
            UpdateGuiThread(() => txtPackageType.Text = selectedPackageType);
            UpdateGuiThread(() => txtPriorOrNot.Text = _selectedPriority.ToString());
        }

        public void DeleteDeliveryStatus()
        {
            UpdateGuiThread(() => txtTotalTraveltime.Text = "");
            UpdateGuiThread(() => txtPackageType.Text = "");
            UpdateGuiThread(() => txtPriorOrNot.Text = "");
            UpdateGuiThread(() => txtDeliveryId.Text = "");
            UpdateGuiThread(() => txtRestingTime.Text = "");
            UpdateGuiThread(() => progressBar.Value = 0);
        }

        #endregion

        #region Event Handlers
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {

            switch (_selectedType)
            {
                case PackageType.Mini:
                    totalTravelTime = Convert.ToInt32(nNumberTraveltime.Text);
                    selectedPackageType = PackageType.Mini.ToString();
                    break;
                case PackageType.Standaard:
                    totalTravelTime = (Convert.ToInt32(nNumberTraveltime.Text)) * 1.2;
                    selectedPackageType = PackageType.Standaard.ToString();
                    break;
                case PackageType.Maxi:
                    totalTravelTime = (Convert.ToInt32(nNumberTraveltime.Text)) * 1.5;
                    selectedPackageType = PackageType.Maxi.ToString();
                    break;
            }

            if (chkPriority.IsChecked == true)
            {
                checkIfPrior = true;
                _selectedPriority = PackageType.priority;
            }
            else
            {
                checkIfPrior = false;
                _selectedPriority = PackageType.regular;
            }


            DeliveryService.AddDelivery(new Delivery()
            {
                PackageType = _selectedType,
                TravelTime = totalTravelTime,
                Priority = checkIfPrior,
                PriorType = _selectedPriority
            });

            rbtnStandaard.IsChecked = true;
            rbtnMini.IsChecked = false;
            rbtnMaxi.IsChecked = false;

            //Select first delivery in the list
            if (this.lstDeliveries.Items.Count > 0)
            {
                this.lstDeliveries.SelectedIndex = 0;
            }

            UpdateGuiThread(() => lstDeliveries.Items.Refresh());
        }  

        #endregion

        #region Private Methods
        private void Rbtn_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rad = sender as RadioButton;

            string type = (string)rad.Content;

            if (type != null)
            {
                Enum.TryParse(type, out _selectedType);

                btnSend.IsEnabled = true;
            }
        }
        #endregion

    }
}

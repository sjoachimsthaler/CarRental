using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using BusinessLogic.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient httpClient;
        
        List<Car> Cars = new List<Car>();

        public MainWindow()
        {
            httpClient = new HttpClient();
            InitializeComponent();
            dataGrid.ItemsSource = Cars;
            LoadCars();
        }

        private async void LoadCars()
        {
            Cars = await httpClient.GetFromJsonAsync<List<Car>>("https://localhost:5001/api/car");
            dataGrid.ItemsSource = Cars;

            dataGrid.CellEditEnding += DataGrid_CellEditEnding;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                //e.Column.
                var updatedCar = (Car)dataGrid.CurrentItem;
                Task.Run(async () => await httpClient.PutAsJsonAsync<Car>("https://localhost:5001/api/car", updatedCar));
            }
        }
    }
}

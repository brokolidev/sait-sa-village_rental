using MySqlConnector;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype
{
    public partial class MainPage : ContentPage
    {
        private DatabaseManager dbManager;

        public MainPage()
        {
            InitializeComponent();
        }

        // Navigation buttons
        private void EquipmentButton_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(EquipmentList));
        }
    }

}

using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype
{
    public partial class MainPage : ContentPage
    {
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

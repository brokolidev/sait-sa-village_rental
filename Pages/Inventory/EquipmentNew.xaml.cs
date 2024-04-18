using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Equipment;

public partial class EquipmentNew : ContentPage
{
	public EquipmentNew()
	{
		InitializeComponent();
	}

    private void ValidationAlert(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Please fill out all fields", "OK");
    }
}
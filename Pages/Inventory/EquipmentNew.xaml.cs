using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Equipment;

public partial class EquipmentNew : ContentPage
{
	public EquipmentNew()
	{
		InitializeComponent();
	}


    // navigation functions
    private void EquipmentButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EquipmentList));
    }
}
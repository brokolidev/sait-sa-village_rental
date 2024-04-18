using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Controls;

public partial class Nav : ContentView
{
    public event EventHandler<EventArgs> OnEquipmentMangementClicked;

    public Nav()
	{
		InitializeComponent();
	}

	private void EquipmentButton_Clicked(object sender, EventArgs e)
	{
		if(OnEquipmentMangementClicked != null)
		{
            OnEquipmentMangementClicked?.Invoke(this, e);
        }
		else
		{
            Shell.Current.GoToAsync(nameof(EquipmentList));
        }
		
    }
}
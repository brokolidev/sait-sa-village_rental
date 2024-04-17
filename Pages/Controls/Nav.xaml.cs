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
		OnEquipmentMangementClicked?.Invoke(this, e);
    }
}
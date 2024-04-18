namespace VillageRentalsPrototype.Pages.Customer;

public partial class CustomerNew : ContentPage
{
	public CustomerNew()
	{
		InitializeComponent();
	}

    private void ValidationAlert(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Please fill out all fields", "OK");
    }
}
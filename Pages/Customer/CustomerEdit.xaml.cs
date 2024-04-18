namespace VillageRentalsPrototype.Pages.Customer;

public partial class CustomerEdit : ContentPage
{
	public CustomerEdit()
	{
		InitializeComponent();
	}

    private void ValidationAlert(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Please fill out all fields", "OK");
    }
}
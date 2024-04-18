using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages.Customer;

public partial class CustomerList : ContentPage
{
	public CustomerList()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
        base.OnAppearing();

        // get all customers from the database
        DatabaseManager dbManager = new DatabaseManager();
        List<Models.Customer> customers = dbManager.GetAllCustomers();

        // set the items source for the list view
        CustomerListView.ItemsSource = customers;
        CustomerListView.ItemSelected += OnCustomerSelected;
    }

    private void OnCustomerSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (CustomerListView.SelectedItem == null)
            return;

        var selectedCustomer = (Models.Customer)e.SelectedItem;

        Shell.Current.GoToAsync($"{nameof(CustomerView)}" +
            $"?Id={selectedCustomer.Id}");
    }

    private void AddCustomer_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerNew));
    }
}
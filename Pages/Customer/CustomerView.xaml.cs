using System.Diagnostics;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Models;

namespace VillageRentalsPrototype.Pages.Customer;

[QueryProperty(nameof(SelectedId), "Id")]
public partial class CustomerView : ContentPage
{
    private Models.Customer customer;
    private DatabaseManager dbManager;

	public CustomerView()
	{
		InitializeComponent();
        dbManager = new DatabaseManager();
    }

    public string SelectedId
    {
        set
        {
            int id = Convert.ToInt32(value);
            customer = dbManager.GetCustomerById(id);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (customer != null)
        {
            SetCustomer();
        }
    }

    private void SetCustomer()
    {
        Id.Detail = customer.Id.ToString();
        FirstName.Detail = customer.FirstName;
        LastName.Detail = customer.LastName;
        Email.Detail = customer.Email;
        Phone.Detail = customer.Phone;
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerList));
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // display alert to confirm deletion
        bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this customer?", "Yes", "No");

        if (!answer)
        {
            return;
        }

        if (customer == null)
        {
            DisplayAlert("Error", "Customer not found", "OK");
            return;
        }

        dbManager.DeleteCustomer(customer.Id);

        Shell.Current.GoToAsync(nameof(CustomerList));
    }

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine($"Edit customer {customer.Id}");
        Shell.Current.GoToAsync($"{nameof(CustomerEdit)}?Id={customer.Id}");
    }
}
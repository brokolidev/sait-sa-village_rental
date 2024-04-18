using System.Diagnostics;
using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages.Customer;

[QueryProperty(nameof(CustomerId), "Id")]
public partial class CustomerEdit : ContentPage
{
    private Models.Customer customer;
    private DatabaseManager dbManager;

    public string CustomerId
    {
        set
        {
            if (value != null)
            {
                customer = dbManager.GetCustomerById(Int32.Parse(value));
                CustomerForm.Id = customer.Id.ToString();
                CustomerForm.FirstName = customer.FirstName;
                CustomerForm.LastName = customer.LastName;
                CustomerForm.Email = customer.Email;
                CustomerForm.Phone = customer.Phone;
            }
        }
    }

    public CustomerEdit()
	{
		InitializeComponent();
        dbManager = new DatabaseManager();
    }

    private void ValidationAlert(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Please fill out all fields", "OK");
    }
}
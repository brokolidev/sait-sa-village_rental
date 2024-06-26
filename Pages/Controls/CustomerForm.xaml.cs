using System.Collections.Generic;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Models;
using VillageRentalsPrototype.Pages.Customer;

namespace VillageRentalsPrototype.Pages.Controls;

public partial class CustomerForm : ContentView
{
    public event EventHandler<EventArgs> OnValidationErrorOccured;

    private DatabaseManager dbManager;
    
    public bool IsEdit { get; set; }

    //Creating properties to access xaml tags in UI
    public string Id
    {
        get => IdEntry.Text;
        set { IdEntry.Text = value; }
    }

    public string FirstName
    {
        get => FirstNameEntry.Text;
        set { FirstNameEntry.Text = value; }
    }

    public string LastName
    {
        get => LastNameEntry.Text;
        set { LastNameEntry.Text = value; }
    }

    public string Email
    {
        get => EmailEntry.Text;
        set { EmailEntry.Text = value; }
    }

    public string Phone
    {
        get => PhoneEntry.Text;
        set { PhoneEntry.Text = value; }
    }


    public CustomerForm()
	{
		InitializeComponent();

        dbManager = new DatabaseManager();
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (IsEdit)
        {
            AddButton.IsVisible = false;
        }
        else
        {
            UpdateButton.IsVisible = false;
            IdLabel.IsVisible = false;
            IdEntry.IsVisible = false;
        }
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (!ValidateForms())
        {
            OnValidationErrorOccured?.Invoke(this, e);
            return;
        }

        // add customer to database
        dbManager.AddCustomer(new Models.Customer(
            LastNameEntry.Text,
            FirstNameEntry.Text,
            PhoneEntry.Text,
            EmailEntry.Text
        ));

        Shell.Current.GoToAsync(nameof(CustomerList));
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CustomerList));
    }

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        if (!ValidateForms())
        {
            OnValidationErrorOccured?.Invoke(this, e);
            return;
        }

        // update customer info
        dbManager.UpdateCustomer(new Models.Customer(
            Int32.Parse(IdEntry.Text),
            LastNameEntry.Text,
            FirstNameEntry.Text,
            PhoneEntry.Text,
            EmailEntry.Text
        ));

        Shell.Current.GoToAsync(nameof(CustomerList));
    }

    private bool ValidateForms()
    {
        // validate form
        if (string.IsNullOrEmpty(FirstNameEntry.Text) || string.IsNullOrEmpty(LastNameEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text) || PhoneEntry == null)
        {
            // Display alert 
            return false;
        }

        return true;
    }
}
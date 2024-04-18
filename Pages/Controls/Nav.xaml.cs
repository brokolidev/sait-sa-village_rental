using VillageRentalsPrototype.Pages.Customer;
using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Controls;

public partial class Nav : ContentView
{
    public event EventHandler<EventArgs> OnHomeClicked;
    public event EventHandler<EventArgs> OnRentalClicked;
    public event EventHandler<EventArgs> OnManageCustomerClicked;
    public event EventHandler<EventArgs> OnManageInventoryClicked;
    public event EventHandler<EventArgs> OnManageSystemClicked;


    public Nav()
	{
		InitializeComponent();
	}

	private void EquipmentButton_Clicked(object sender, EventArgs e)
	{
		if(OnManageInventoryClicked != null)
		{
            OnManageInventoryClicked?.Invoke(this, e);
        }
		else
		{
            Shell.Current.GoToAsync(nameof(EquipmentList));
        }	
    }

	private void HomeButton_Clicked(object sender, EventArgs e)
	{
        if(OnHomeClicked != null)
		{
            OnHomeClicked?.Invoke(this, e);
        }
        else
        {
            Shell.Current.Navigation.PopToRootAsync();
        }
    }

    private void RentalButton_Clicked(object sender, EventArgs e)
    {
        if (OnRentalClicked != null)
        {
            OnRentalClicked?.Invoke(this, e);
        }
        else
        {
            Shell.Current.GoToAsync(nameof(Rental));
        }
    }

    private void CustomerButton_Clicked(object sender, EventArgs e)
    {
        if (OnManageCustomerClicked != null)
        {
            OnManageCustomerClicked?.Invoke(this, e);
        }
        else
        {
            Shell.Current.GoToAsync(nameof(CustomerList));
        }
    }

    private void SystemButton_Clicked(object sender, EventArgs e)
    {
        if (OnManageSystemClicked != null)
        {
            OnManageSystemClicked?.Invoke(this, e);
        }
        else
        {
            Shell.Current.GoToAsync(nameof(System));
        }
    }
}
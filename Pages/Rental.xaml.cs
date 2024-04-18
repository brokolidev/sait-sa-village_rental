using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages;

public partial class Rental : ContentPage
{
	DatabaseManager dbManager;
	Models.Equipment selectedEquipment;
    Models.Customer selectedCustomer;
    double totalCost;

	public Rental()
	{
		InitializeComponent();

		dbManager = new DatabaseManager();

		SetEquipmentPicker();
        SetCustomerPicker();
		SetDatePickers();

        CalculateTotalCost(null, null);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        EquipmentPicker.SelectedIndexChanged += CalculateTotalCost;
        FromDatePicker.DateSelected += CalculateTotalCost;
        ToDatePicker.DateSelected += CalculateTotalCost;
        CustomerPicker.SelectedIndexChanged += CustomerPicker_SelectedIndexChanged;
    }

    private void CustomerPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedCustomer = (Models.Customer)CustomerPicker.SelectedItem;
    }

    private void SetCustomerPicker()
    {
        CustomerPicker.ItemsSource = dbManager.GetAllCustomers();
        CustomerPicker.ItemDisplayBinding = new Binding("FirstName");

        CustomerPicker.SelectedIndex = 0;
    }

    private void CalculateTotalCost(object sender, EventArgs e)
    {
        selectedEquipment = (Models.Equipment)EquipmentPicker.SelectedItem;

        var totalDays = (ToDatePicker.Date - FromDatePicker.Date).TotalDays;

        if(totalDays < 1)
        {
            FromDatePicker.Date = DateTime.Now;
            ToDatePicker.Date = DateTime.Now.AddDays(10);
            DisplayAlert("Error", "The rental period must be at least 1 day", "OK");
            return;
        }

        if (selectedEquipment == null)
        {
            DisplayAlert("Error", "Please select an equipment", "OK");
            return;
        }


        totalCost = selectedEquipment.DailyRate * totalDays;
        CostEntry.Text = $"{totalCost:C}";
    }

    private void SetDatePickers()
	{
        FromDatePicker.MinimumDate = DateTime.Now;
        FromDatePicker.Date = DateTime.Now;
        ToDatePicker.Date = DateTime.Now.AddDays(10);
    }

	private void SetEquipmentPicker()
	{
        EquipmentPicker.ItemsSource = dbManager.GetAllEquipments();
        EquipmentPicker.ItemDisplayBinding = new Binding("Name");

        EquipmentPicker.SelectedIndex = 0;
    }

	public void SaveButton_Clicked(object sender, EventArgs e)
	{
        var rental = new Models.Rental(
            selectedCustomer.Id,
            selectedEquipment.Id,
            FromDatePicker.Date,
            ToDatePicker.Date,
            totalCost
        );

        dbManager.AddRental(rental);

        DisplayAlert("Success", "Rental saved", "OK");
    }
}
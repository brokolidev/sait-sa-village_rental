using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages;

public partial class RentalList : ContentPage
{
	DatabaseManager dbManager;
    List<Models.Rental> rentals;

	public RentalList()
	{
		InitializeComponent();

		dbManager = new DatabaseManager();
	}

    override protected void OnAppearing()
	{
        base.OnAppearing();

        rentals = dbManager.GetAllRentals();
        RentalListView.ItemsSource = rentals;
    }


}
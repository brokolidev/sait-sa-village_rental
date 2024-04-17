using System.Diagnostics;
using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages.Inventory;

public partial class EquipmentList : ContentPage
{
	DatabaseManager dbManager;
	List<Models.Equipment> equipments;

	public EquipmentList()
	{
		InitializeComponent();

		dbManager = new DatabaseManager();
		equipments = dbManager.GetAllEquipments();

		foreach (var equipment in equipments)
		{
			Debug.WriteLine(equipment.Name, equipment.CategoryName);
		}

		EquipListView.ItemsSource = equipments;
    }

	private void AddEquipment_Clicked(object sender, EventArgs e)
	{
        //Navigation.PushAsync(new AddEquipment());
    }

    private void DeleteEquipment_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new AddEquipment());
    }
}
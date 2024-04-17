using System.Diagnostics;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Pages.Equipment;

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
        EquipListView.ItemSelected += OnEquipmentSelected;
    }

	private void OnEquipmentSelected(object sender, SelectedItemChangedEventArgs e)
	{
        if (EquipListView.SelectedItem == null)
            return;

        var selectedEquipment = (Models.Equipment)e.SelectedItem;

        Shell.Current.GoToAsync($"{nameof(EquipmentView)}" +
            $"?ISBN={selectedEquipment.Id}");
    }

	private void AddEquipment_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(EquipmentNew));
    }


	// navigation functions
	private void EquipmentButton_Clicked()
	{
		// do nothing
	}
}
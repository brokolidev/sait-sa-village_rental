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
            Debug.WriteLine("EquipmentList: equipment = " + equipment.Name);
        }
	}
}
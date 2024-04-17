using System.Diagnostics;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Equipment;

[QueryProperty(nameof(SelectedId), "Id")]
public partial class EquipmentView : ContentPage
{
    private Models.Equipment equipment;
    private DatabaseManager dbManager;

    public EquipmentView()
    {
        InitializeComponent();

        dbManager = new DatabaseManager();
    }

    public string SelectedId
    {
        set
        {
            int id = Convert.ToInt32(value);
            equipment = dbManager.GetEquipment(id);
            Debug.WriteLine(equipment);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (equipment != null)
        {
            Debug.WriteLine(equipment.Name, equipment.CategoryName);
        }
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EquipmentList));
    }
}
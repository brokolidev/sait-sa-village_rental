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
            SetEquipment();
        }
    }

    private void SetEquipment()
    {
        Id.Detail = equipment.Id.ToString();
        Name.Detail = equipment.Name;
        Category.Detail = equipment.CategoryName;
        Name.Detail = equipment.Name;
        Description.Detail = equipment.Description;
        DailyRate.Detail = $"${equipment.DailyRate}";
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EquipmentList));
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the equipment
    }

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EquipmentEdit));
    }
}
using System.Diagnostics;
using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages.Equipment;

[QueryProperty(nameof(eqId), "Id")]
public partial class EquipmentEdit : ContentPage
{
    private DatabaseManager dbManger;
    private Models.Equipment selectedEquipment;

    public string eqId
    {
        set
        {
            if (value != null)
            {
                selectedEquipment = dbManger.GetEquipmentById(Int32.Parse(value));
                EquipmentForm.Id = selectedEquipment.Id.ToString();
                EquipmentForm.Name = selectedEquipment.Name;
                EquipmentForm.Description = selectedEquipment.Description;
                EquipmentForm.DailyRate = selectedEquipment.DailyRate.ToString();
                EquipmentForm.SelectedCategoryId = selectedEquipment.CategoryId;
            }
        }
    }

    public EquipmentEdit()
	{
		InitializeComponent();

        dbManger = new DatabaseManager();
    }

    private void ValidationAlert(object sender, EventArgs e)
    {
        DisplayAlert("Error", "Please fill out all fields", "OK");
    }
}
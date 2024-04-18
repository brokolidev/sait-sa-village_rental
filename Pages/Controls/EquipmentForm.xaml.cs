using System.Diagnostics;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Models;
using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Controls;

[QueryProperty(nameof(eqId), "Id")]
public partial class EquipmentForm : ContentView
{
	private List<Category> categories;
	private DatabaseManager dbManger;
	private Category selectedCategory;
    private Models.Equipment? selecteEquipment;

    public string? eqId
    {
        set
        {
            if(value != null)
            {
                dbManger = new DatabaseManager();
                var eq = dbManger.GetEquipment(Int32.Parse(value));
                if(eq != null)
                {
                    selecteEquipment = eq;
                }
            }
        }
    }

	public EquipmentForm()
	{
		InitializeComponent();

		dbManger = new DatabaseManager();
		categories = new List<Category>();
		categories = dbManger.GetAllCategories();

		CategoryPicker.ItemsSource = categories;

        CategoryPicker.ItemDisplayBinding = new Binding("Name");
        CategoryPicker.SelectedIndexChanged += OnCategoryIndexChanged;
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();
        if (CategoryPicker.SelectedIndex == -1)
        {
            CategoryPicker.SelectedIndex = 0;
            Debug.WriteLine("CategoryPicker.SelectedIndex = 0");
        }
    }

	private void OnCategoryIndexChanged(object sender, EventArgs e)
	{
        selectedCategory = (Category)CategoryPicker.SelectedItem;
        Debug.WriteLine("CategoryPicker changed");
        Debug.WriteLine(selectedCategory.Name);
    }


	private void SaveButton_Clicked(object sender, EventArgs e)
	{
        // validate form
        if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Description.Text) || string.IsNullOrEmpty(DailyRate.Text) || selectedCategory == null)
        {
            Debug.WriteLine("All fields are required");
            return;
        }

        dbManger.AddEquipment(selectedCategory.Id, Name.Text, Description.Text, double.Parse(DailyRate.Text));

        Shell.Current.GoToAsync(nameof(EquipmentList));
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EquipmentList));
    }

}
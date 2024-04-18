using System.Diagnostics;
using System.Runtime.CompilerServices;
using VillageRentalsPrototype.Managers;
using VillageRentalsPrototype.Models;
using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype.Pages.Controls;

public partial class EquipmentForm : ContentView
{
    private List<Category> categories;
	private DatabaseManager dbManger;
    private Category selectedCategory;
    public event EventHandler<EventArgs> OnValidationErrorOccured;

    public bool IsEdit { get; set; }

    //Creating properties to access xaml tags in UI
    public string Id
    {
        get => IdEntry.Text;
        set { IdEntry.Text = value; }
    }

    public int SelectedCategoryId
    {
        get
        {
            var selectedCategory = (Category)CategoryPicker.SelectedItem;
            return selectedCategory.Id;
        }

        set
        {
            CategoryPicker.SelectedItem = categories.Find(c => c.Id == value);
        }
    }

    public string Name
    {
        get => NameEntry.Text;
        set { NameEntry.Text = value; }
    }

    public string Description
    {
        get => DescriptionEntry.Text;
        set { DescriptionEntry.Text = value; }
    }

    public string DailyRate
    {
        get => DailyRateEntry.Text;
        set { DailyRateEntry.Text = value; }
    }


    public EquipmentForm()
	{
		InitializeComponent();

		dbManger = new DatabaseManager();
		categories = new List<Category>();
		categories = dbManger.GetAllCategories();

		CategoryPicker.ItemsSource = categories;

        CategoryPicker.ItemDisplayBinding = new Binding("Name");
    }

    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (CategoryPicker.SelectedIndex == -1)
        {
            CategoryPicker.SelectedIndex = 0;
        }

        if(IsEdit)
        {
            AddButton.IsVisible = false;
        }
        else
        {
            UpdateButton.IsVisible = false;
            IdLabel.IsVisible = false;
            IdEntry.IsVisible = false;
        }

        CategoryPicker.SelectedIndexChanged += OnCategoryIndexChanged;
    }

	private void OnCategoryIndexChanged(object sender, EventArgs e)
	{
        selectedCategory = (Category)CategoryPicker.SelectedItem;
        Debug.WriteLine($"Selected Category variable {selectedCategory}");
    }


	private void SaveButton_Clicked(object sender, EventArgs e)
	{
        if(!ValidateForms())
        {
            OnValidationErrorOccured?.Invoke(this, e);
            return;
        }

        dbManger.AddEquipment(selectedCategory.Id, NameEntry.Text, DescriptionEntry.Text, double.Parse(DailyRateEntry.Text));

        Shell.Current.GoToAsync(nameof(EquipmentList));
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EquipmentList));
    }

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        if (!ValidateForms())
        {
            OnValidationErrorOccured?.Invoke(this, e);
            return;
        }

        dbManger.UpdateEqeuipment(new Models.Equipment(
            int.Parse(IdEntry.Text), 
            NameEntry.Text, 
            DescriptionEntry.Text, 
            double.Parse(DailyRateEntry.Text),
            selectedCategory.Name,
            selectedCategory.Id
        ));

        Shell.Current.GoToAsync(nameof(EquipmentList));
    }

    private bool ValidateForms()
    {
        // validate form
        if (string.IsNullOrEmpty(NameEntry.Text) || string.IsNullOrEmpty(DescriptionEntry.Text) || string.IsNullOrEmpty(DailyRateEntry.Text) || selectedCategory == null)
        {
            // Display alert 
            return false;
        }

        return true;
    }

}
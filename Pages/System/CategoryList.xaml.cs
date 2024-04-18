using System.Collections.ObjectModel;
using System.Diagnostics;
using VillageRentalsPrototype.Managers;

namespace VillageRentalsPrototype.Pages.System;

public partial class CategoryList : ContentPage
{
	DatabaseManager dbManager;
    List<Models.Category> categories;

	public CategoryList()
	{
		InitializeComponent();

		dbManager = new DatabaseManager();
		categories = dbManager.GetAllCategories();
        
        CategoryListView.ItemsSource = categories;
    }

	private void Add_Clicked(object sender, EventArgs e)
	{
		if(string.IsNullOrEmpty(CategoryNameEntry.Text))
		{
			DisplayAlert ("Error", "Please enter a category name", "OK");
			return;
		}

        dbManager.AddCategory(CategoryNameEntry.Text);
		
		CategoryNameEntry.Text = "";

        DisplayAlert ("Success", "Category added", "OK");

        categories = dbManager.GetAllCategories();

        // bind the selected books to the list view
        var categoryCollection = new ObservableCollection<Models.Category>(this.categories);
        CategoryListView.ItemsSource = categoryCollection;
    }

	private async void Delete_Clicked(object sender, EventArgs e)
	{
        // display alert to confirm deletion
        bool answer = await DisplayAlert("Delete", "Are you sure you want to delete this category?", "Yes", "No");

        if (!answer)
        {
            return;
        }

		var categoryId = ((Button)sender).CommandParameter;
		
		dbManager.DeleteCategory((int)categoryId);
		categories = dbManager.GetAllCategories();

        DisplayAlert("Success", "Category deleted", "OK");

        // bind the selected books to the list view
        var categoryCollection = new ObservableCollection<Models.Category>(this.categories);
        CategoryListView.ItemsSource = categoryCollection;
    }
}
using VillageRentalsPrototype.Pages;
using VillageRentalsPrototype.Pages.Customer;
using VillageRentalsPrototype.Pages.Equipment;
using VillageRentalsPrototype.Pages.Inventory;
using VillageRentalsPrototype.Pages.System;

namespace VillageRentalsPrototype
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

            // Equipment
            Routing.RegisterRoute(nameof(EquipmentList), typeof(EquipmentList));
            Routing.RegisterRoute(nameof(EquipmentNew), typeof(EquipmentNew));
            Routing.RegisterRoute(nameof(EquipmentView), typeof(EquipmentView));
            Routing.RegisterRoute(nameof(EquipmentEdit), typeof(EquipmentEdit));

            // Customer
            Routing.RegisterRoute(nameof(CustomerList), typeof(CustomerList));
            Routing.RegisterRoute(nameof(CustomerNew), typeof(CustomerNew));
            Routing.RegisterRoute(nameof(CustomerView), typeof(CustomerView));
            Routing.RegisterRoute(nameof(CustomerEdit), typeof(CustomerEdit));

            // Rental
            Routing.RegisterRoute(nameof(Rental), typeof(Rental));
            Routing.RegisterRoute(nameof(RentalList), typeof(RentalList));

            // System
            Routing.RegisterRoute(nameof(CategoryList), typeof(CategoryList));
            Routing.RegisterRoute(nameof(CategoryNew), typeof(CategoryNew));
            Routing.RegisterRoute(nameof(CategoryView), typeof(CategoryView));
            Routing.RegisterRoute(nameof(CategoryEdit), typeof(CategoryEdit));
        }
    }
}

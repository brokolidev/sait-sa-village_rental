using VillageRentalsPrototype.Pages;
using VillageRentalsPrototype.Pages.Equipment;
using VillageRentalsPrototype.Pages.Inventory;

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
        }
    }
}

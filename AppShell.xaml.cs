using VillageRentalsPrototype.Pages;
using VillageRentalsPrototype.Pages.Inventory;

namespace VillageRentalsPrototype
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(EquipmentList), typeof(EquipmentList));
        }
    }
}

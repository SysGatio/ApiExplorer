namespace Api.Explorer.Blazor.Components.Layout;

public partial class MainLayout
{
    private readonly MudTheme _theme01 = new()
    {
        Palette = new PaletteLight
        {
            Primary = new MudBlazor.Utilities.MudColor("#4a6fa5"),
            Secondary = new MudBlazor.Utilities.MudColor("#2a2e35"),
            AppbarBackground = new MudBlazor.Utilities.MudColor("#2a2e35"),
            DrawerBackground = new MudBlazor.Utilities.MudColor("#000000"),
            Background = new MudBlazor.Utilities.MudColor("#e0e0e0")
        }
    };
}

namespace Api.Explorer.Blazor.Components.Pages;

[UsedImplicitly]
public partial class OnThisDay
{
    #region Injects
    [Inject]
    protected IByabbeService ByabbeService { get; set; } = default!;

    [Inject] 
    protected IDialogService DialogService { get; set; } = default!;

    [Inject] 
    protected ILogService LogService { get; set; } = default!;
    #endregion

    #region Consts
    private const string TitlePage = "On this Day";
    private const string DescritionPage =
        "This API can be used to retrieve birth, deaths, and events for any given day of the year. " +
        "The data is all harvested from Wikipedia and therefore licensed under Creative Commons Attribution-ShareAlike 3.0 Unported License.";
    #endregion

    private int? _month;
    private int? _day;
    private bool _loadingPage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _loadingPage = true;

            _month = DateTime.Now.Month;
            _day = DateTime.Now.Day;

            await ByabbeService.ApiSearchEvents(_month.Value, _day.Value);
        }
        catch (Exception e)
        {
            await ShowDialogError();
            await LogService.LogErrorToDatabase(e);
        }
        finally
        {
            _loadingPage = false;
        }
    }

    private async Task SearchEvents()
    {
        try
        {
            if (!ByabbeService.IsDateValid(_month, _day))
            {
                ByabbeService.ClearEvents();
                return;
            }

            await ByabbeService.ApiSearchEvents(_month!.Value, _day!.Value);
        }
        catch (Exception e)
        {
            await ShowDialogError();
            await LogService.LogErrorToDatabase(e);
        }
    }

    private async Task ShowDialogError()
    {
        await DialogService.ShowMessageBox("Error",
            "An error occurred during the operation. Please try again later or contact support.");
    }
}
using Api.Explorer.Blazor.ExternalApis.Calendar.Byabbe.Dtos;

namespace Api.Explorer.Blazor.Components.Pages;

[UsedImplicitly]
public partial class OnThisDay
{
    #region Injects
    [Inject]
    protected HttpClient HttpClient { get; set; } = default!;
    #endregion

    #region Consts
    private const string TitlePage = "On this Day";
    private const string DescritionPage =
        "This API can be used to retrieve birth, deaths, and events for any given day of the year. " +
        "The data is all harvested from Wikipedia and therefore licensed under Creative Commons Attribution-ShareAlike 3.0 Unported License.";
    #endregion

    private List<Event> _events = [];
    private int? nullableInt;


    protected override async Task OnInitializedAsync()
    {
        var response = await HttpClient.GetFromJsonAsync<HistoricalEvents>($"https://byabbe.se/on-this-day/{1}/{3}/events.json");

        if (response != null)
        {
            _events = [.. response.Events.OrderByDescending(e=> e.Year)];
        }
    }

    private Task IncrementCount()
    {
        throw new NotImplementedException();
    }
}
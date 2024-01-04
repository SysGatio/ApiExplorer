namespace Api.Explorer.Blazor.ExternalApis.Calendar.Byabbe.Dtos;

public class HistoricalEvents
{
    public string Wikipedia { get; set; } = string.Empty;

    public string Date { get; set; } = string.Empty;

    public List<Event> Events { get; set; } = [];
}
namespace Api.Explorer.Blazor.ExternalApis.Calendar.Byabbe.Dtos;

public class Event
{
    public string Year { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<WikipediaLink> Wikipedia { get; set; } = [];
}
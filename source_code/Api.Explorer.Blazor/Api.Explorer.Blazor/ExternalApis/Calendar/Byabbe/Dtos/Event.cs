namespace Api.Explorer.Blazor.ExternalApis.Calendar.Byabbe.Dtos;

public class Event
{
    public string Year { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<WikipediaLink> Wikipedia { get; set; } = [];

    public int YearInt
    {
        get
        {
            var isBc = Year.Contains("BC");
            var yearNumber = Year.Replace("BC", "").Trim();

            if (int.TryParse(yearNumber, out var yearInt))
            {
                return isBc ? -yearInt : yearInt;
            }

            return 0;
        }
    }
}
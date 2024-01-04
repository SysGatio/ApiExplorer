namespace Api.Explorer.Blazor.ExternalApis.Calendar.Byabbe.Services;

public interface IByabbeService
{
    List<Event> Events { get; }

    string ApiMessage { get; }

    Task ApiSearchEvents(int month, int day);

    bool IsDateValid(int? month, int? day);

    string GetFormattedDate(int? month, int? day);

    void ClearEvents();
}

public class ByabbeService(HttpClient httpClient) : IByabbeService
{
    public List<Event> Events { get; private set; } = [];

    public string ApiMessage { get; private set; } = string.Empty;

    public async Task ApiSearchEvents(int month, int day)
    {
        try
        {
            var responseMessage = await httpClient.GetAsync($"https://byabbe.se/on-this-day/{month}/{day}/events.json");

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadFromJsonAsync<HistoricalEvents>();
                if (responseContent != null)
                {
                    Events = [.. responseContent.Events.OrderByDescending(e => e.YearInt)];
                }
                else
                {
                    ApiMessage = "No data found";
                }
            }
            else
            {
                ApiMessage = $"Error: {responseMessage.StatusCode}";
            }
        }
        catch (Exception e)
        {
            ApiMessage = e.Message;
        }
    }

    public string GetFormattedDate(int? month, int? day)
    {
        if (!month.HasValue || !day.HasValue)
        {
            return "Date not set";
        }

        try
        {
            var date = new DateTime(1, month.Value, day.Value);
            return date.ToString("MMMM d", CultureInfo.CurrentCulture);
        }
        catch
        {
            return "Invalid date";
        }
    }
    
    public bool IsDateValid(int? month, int? day)
    {
        if (!month.HasValue || !day.HasValue)
        {
            return false;
        }

        if (month is < 1 or > 12)
        {
            return false;
        }

        int[] daysInMonth = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        return day >= 1 && day <= daysInMonth[month.Value - 1];
    }

    public void ClearEvents()
    {
        Events.Clear();
    }
}

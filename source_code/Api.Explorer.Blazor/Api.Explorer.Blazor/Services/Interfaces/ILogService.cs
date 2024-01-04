namespace Api.Explorer.Blazor.Services.Interfaces;

public interface ILogService
{
    Task LogErrorToDatabase(Exception e);
}

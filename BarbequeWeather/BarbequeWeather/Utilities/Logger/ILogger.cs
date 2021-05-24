namespace BarbequeWeather.Utilities.Logger
{
    public interface ILogger
    {
        void Log(string message, Severity severity);
    }

    public enum Severity
    {
        Verbose,
        Warning,
        Error
    }
}
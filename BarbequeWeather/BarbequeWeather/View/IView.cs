namespace BarbequeWeather.View
{
    public interface IView
    {
        void DisplayResult(string locationDisclaimer, bool result);
        void DisplayError(string errorMessage);
        int GetLatitude();
        int GetLongitude();
        bool RunAgain();
    }
}
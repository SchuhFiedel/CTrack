namespace CTrack.Client.Interfaces
{
    public interface IToastComponent
    {
        void ShowError(string title, string message = "");
        void ShowWarning(string title, string message = "");
        void ShowSuccess(string title, string message = "");
        void ShowInfo(string title, string message = "");
    }
}

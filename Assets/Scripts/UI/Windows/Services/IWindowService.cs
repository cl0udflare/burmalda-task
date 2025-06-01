namespace UI.Windows.Services
{
    public interface IWindowService
    {
        void Open(WindowType windowType);
        void Close(WindowType windowId);
    }
}
namespace UI.Factories
{
    public interface IUIFactory
    {
        void CreateUIRoot();
        void CreateMainMenu();
        void Cleanup();
    }
}
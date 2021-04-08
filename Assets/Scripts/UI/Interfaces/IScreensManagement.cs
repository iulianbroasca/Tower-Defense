using UI.BaseScripts;

namespace UI.Interfaces
{
    public interface IScreensManagement
    {
        BaseScreen GetCurrentScreen();
        BaseScreen GetScreen(object screenType);
        void LoadScreens();
        void SwitchScreen(object screenType);
    }
}

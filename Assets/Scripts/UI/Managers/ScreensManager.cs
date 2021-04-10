using System.Collections.Generic;
using System.Linq;
using Globals;
using MonoSingleton;
using UI.BaseScripts;
using UnityEngine;

namespace UI.Managers
{
    public class ScreensManager : MonoSingleton<ScreensManager>
    {
        private GameObject RootCanvas { get; set; }
        private BaseScreen CurrentBaseScreen { get; set; }

        private readonly Dictionary<object, BaseScreen> screens = new Dictionary<object, BaseScreen>();

        protected override void Awake()
        {
            base.Awake();
            Initialization();
        }

        public BaseScreen GetCurrentScreen()
        {
            return CurrentBaseScreen;
        }

        public BaseScreen GetScreen(object screenType)
        {
            var screen = screens.First(it => it.Key == screenType);
            return screen.Value;
        }

        public void SwitchScreen(object screenType)
        {
            var lastScreen = CurrentBaseScreen;
            CurrentBaseScreen = GetScreen(screenType);

            lastScreen.RefreshScreen();
            lastScreen.DisableScreen();

            CurrentBaseScreen.EnableScreen();
        }

        protected void LoadScreens()
        {
            foreach (var screen in RootCanvas.GetComponentsInChildren<BaseScreen>(true))
            {
                screens.Add(screen.GetType(), screen);
            }
        }

        private void Initialization()
        {
            RootCanvas = GameObject.FindWithTag(Constants.MainCanvasTag);
            LoadScreens();
            CurrentBaseScreen = GameObject.FindWithTag(Constants.HomeScreenTag).GetComponent<BaseScreen>();
            CurrentBaseScreen.EnableScreen();
        }
    }
}

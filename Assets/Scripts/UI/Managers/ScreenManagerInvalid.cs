namespace UI.Managers
{
    public class ScreenManagerInvalid : ScreenManager
    {
        protected override void OnValidate()
        {
            gameObject.name = GetType().Name;
        }
    }
}
using AndroidX.Car.App;
using AndroidX.Car.App.Model;

namespace ArkEcho.Maui.Platforms.Android.AndroidAuto.ClickListener
{
    public class NavigationOnClickListener : Java.Lang.Object, IOnClickListener
    {
        private CarContext context;
        private ScreenManager screenManager;
        private AndroidAutoResources.Screens screen;

        public NavigationOnClickListener(CarContext context, ScreenManager screenManager, AndroidAutoResources.Screens screen)
        {
            this.context = context;
            this.screenManager = screenManager;
            this.screen = screen;
        }
        public void OnClick()
        {
            switch (screen)
            {
                case AndroidAutoResources.Screens.Menu:
                    screenManager.Push(new CarMenuScreen(context));
                    break;
                case AndroidAutoResources.Screens.MessageTemplate:
                    break;
                case AndroidAutoResources.Screens.GridTemplate:
                    break;
                case AndroidAutoResources.Screens.RowTemplate:
                    break;
                case AndroidAutoResources.Screens.Pop:
                    screenManager.Pop();
                    break;
                default:
                    return;
            }
        }
    }
}

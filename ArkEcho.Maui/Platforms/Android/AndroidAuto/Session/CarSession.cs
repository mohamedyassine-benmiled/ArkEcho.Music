using Android.Content;
using AndroidX.Car.App;

namespace ArkEcho.Maui.Platforms.Android.AndroidAuto
{
    public class CarSession : AndroidX.Car.App.Session
    {
        public override Screen OnCreateScreen(Intent p0)
        {
            return new CarMenuScreen(CarContext);
        }
    }
}

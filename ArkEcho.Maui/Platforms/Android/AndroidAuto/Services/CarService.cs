using Android.App;
using AndroidX.Car.App;
using AndroidX.Car.App.Validation;

namespace ArkEcho.Maui.Platforms.Android.AndroidAuto
{
    [Service(Exported = true)]
    [IntentFilter(new string[] { "androidx.car.app.CarAppService" }, Categories = new string[] { "androidx.car.app.category.POI" })]
    public class CarService : CarAppService
    {
        public override HostValidator CreateHostValidator()
        {
            return HostValidator.AllowAllHostsValidator;
        }

        public override Session OnCreateSession()
        {
            return new CarSession();
        }
    }
}

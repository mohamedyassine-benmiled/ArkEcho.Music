using AndroidX.Car.App;
using AndroidX.Car.App.Model;
using ArkEcho.Maui.Platforms.Android.AndroidAuto.ClickListener;

namespace ArkEcho.Maui.Platforms.Android.AndroidAuto
{
    public class CarMenuScreen : Screen
    {
        public CarMenuScreen(CarContext carContext) : base(carContext)
        {
        }

        public override ITemplate OnGetTemplate()
        {
            var messageTemplates = new Row.Builder()
                .SetTitle("Message Templates")
                .AddText("TEST TEXT")
                .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, AndroidAutoResources.Screens.MessageTemplate))
                .SetBrowsable(true)
                .Build();

            var gridTemplates = new Row.Builder()
                .SetTitle("Grid Templates")
                .AddText("TEST TEXT")
                .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, AndroidAutoResources.Screens.GridTemplate))
                .SetBrowsable(true)
                .Build();

            var rowTemplates = new Row.Builder()
                .SetTitle("Row Templates")
                .AddText("TEST TEXT")
                .SetOnClickListener(new NavigationOnClickListener(CarContext, ScreenManager, AndroidAutoResources.Screens.RowTemplate))
                .SetBrowsable(true)
                .Build();

            var listItems = new ItemList.Builder()
                .SetNoItemsMessage("NO ITEMS!!")
                .AddItem(messageTemplates)
                .AddItem(gridTemplates)
                .AddItem(rowTemplates)
                .Build();

            return new ListTemplate.Builder()
                .SetTitle("ArkEcho Music Menu")
                .SetHeaderAction(AndroidX.Car.App.Model.Action.AppIcon)
                .SetSingleList(listItems)
                .Build();
        }
    }
}

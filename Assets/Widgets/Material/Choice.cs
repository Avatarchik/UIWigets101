using System.Collections.Generic;
using Unity.UIWidgets.widgets;

namespace UIWidgetsSample
{
    public class Choice
    {
        public readonly string title;
        public readonly IconData icon;
        
        public Choice(string title, IconData icon) {
            this.title = title;
            this.icon = icon;
        }
        
        public static List<Choice> choices = new List<Choice> {
            new Choice("Car", Unity.UIWidgets.material.Icons.directions_car),
            new Choice("Bicycle", Unity.UIWidgets.material.Icons.directions_bike),
            new Choice("Boat", Unity.UIWidgets.material.Icons.directions_boat),
            new Choice("Bus", Unity.UIWidgets.material.Icons.directions_bus),
            new Choice("Train", Unity.UIWidgets.material.Icons.directions_railway),
            new Choice("Walk", Unity.UIWidgets.material.Icons.directions_walk)
        };
    }
}
using System.Collections.Generic;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;
using FontStyle = Unity.UIWidgets.ui.FontStyle;

namespace UIWidgetsSample
{
    public class UIWidgetsExample : UIWidgetsPanel
    {
        protected override void Awake()
        {
            base.Awake();
            // Application.targetFrameRate = 60; // or higher if you want a smoother scrolling experience.

            // if you want to use your own font or font icons.   
            // FontManager.instance.addFont(Resources.Load<Font>(path: "path to your font"), "font family name");

            // load custom font with weight & style. The font weight & style corresponds to fontWeight, fontStyle of 
            // a TextStyle object
            // FontManager.instance.addFont(Resources.Load<Font>(path: "path to your font"), "Roboto", FontWeight.w500, 
            //    FontStyle.italic);

            // add material icons, familyName must be "Material Icons"
            // FontManager.instance.addFont(Resources.Load<Font>(path: "path to material icons"), "Material Icons");
        }

        protected override Widget createWidget()
        {
            return new WidgetsApp(
                home: new ExampleApp(),
                pageRouteBuilder: (RouteSettings settings, WidgetBuilder builder) =>
                    new PageRouteBuilder(
                        settings: settings,
                        pageBuilder: (BuildContext context, Animation<float> animation,
                            Animation<float> secondaryAnimation) => builder(context)
                    )
            );
        }

        class ExampleApp : StatefulWidget
        {
            public ExampleApp(Key key = null) : base(key)
            {
            }

            public override State createState()
            {
                return new ExampleState();
            }
        }

        class ExampleState : State<ExampleApp>
        {
            int counter = 0;

            public override Widget build(BuildContext context)
            {
                return new Container(
                    alignment: Alignment.center,
                    decoration: new ShapeDecoration(
                        color: new Color(0x44EF1F7F),
                        gradient: new RadialGradient(),
                        shape: new CircleBorder(new BorderSide(
                            color: Color.black,
                            width: 2
                        ))
                    ),
                    child: new Column(
                        mainAxisAlignment:MainAxisAlignment.center,
                        
                        children: new List<Widget>
                        {
                            new Text("Counter: " + this.counter),
                            new GestureDetector(
                                onTap: () =>
                                {
                                    this.setState(()
                                        =>
                                    {
                                        this.counter++;
                                    });
                                },
                                child: new Container(
                                    padding: EdgeInsets.symmetric(20, 20),
                                    color: Colors.blue,
                                    child: new Text("Click Me")
                                )
                            ),
                            new Text("Counter: " + this.counter+1),
                            new Text("Counter: " + this.counter+2),
                            new Text("Counter: " + this.counter+3),
                            new Text("Counter: " + this.counter+4),
                            new Text("Counter: " + this.counter+5),
                            new Text("Counter: " + this.counter+6),
                            new Text("Counter: " + this.counter+7)
                        }
                    ));
            }
        }
    }
}
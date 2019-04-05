using System;
using Unity.UIWidgets.animation;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.widgets;
using Unity.UIWidgets.foundation;
using UnityEngine;
using Color = Unity.UIWidgets.ui.Color;

namespace UIWidgetsSample
{
    public class AnimatedContainerSample : UIWidgetsPanel
    {
        protected override Widget createWidget()
        {
            return new WidgetsApp(
                home: new AnimatedContainerDemo(),
                pageRouteBuilder: (RouteSettings settings, WidgetBuilder builder) =>
                    new PageRouteBuilder(
                        settings: settings,
                        pageBuilder: (BuildContext context, Animation<float> animation,
                            Animation<float> secondaryAnimation) => builder(context)
                    )
            );
        }


        public class AnimatedContainerDemo : StatefulWidget
        {
            public AnimatedContainerDemo(Key key = null) : base()
            {
            }

            public override State createState()
            {
                return new AnimatedContainerDemoState();
            }
        }

        public class AnimatedContainerDemoState : State<AnimatedContainerDemo>
        {
            private int animateWidth = 300;

            public override Widget build(BuildContext context)
            {
                return
                    new Center(
                        child: new AnimatedContainer(
                            duration:TimeSpan.FromSeconds(1),
                            padding: EdgeInsets.all(50),
                            width: animateWidth,
                            height: 300,
                            decoration: new BoxDecoration(
                                color: new Color(0xFFFFFFFF),
                                border: Border.all(color: Color.fromARGB(255, 0xDF, 0x30, 0x70), width: 5),
                                borderRadius: BorderRadius.all(20)
                            ),
                            child: new Center(
                                child: new GestureDetector(
                                    onTap: () => { this.setState(() => { animateWidth = animateWidth + 50; }); },
                                    child: new Container(
                                        padding: EdgeInsets.symmetric(20, 20),
                                        color:  Color.fromARGB(255, 0xDF, 0x30, 0x70),
                                        child: new Text("Click Me")
                                    )
                                )
                            )
                        )
                    );
            }
        }
    }
}
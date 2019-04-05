using System.Collections.Generic;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.widgets;

namespace UIWidgetsSample
{
    public class ChoiceCard : StatelessWidget {
        public ChoiceCard(Key key = null, Choice choice = null) : base(key: key) {
            this.choice = choice;
        }

        public readonly Choice choice;

        public override Widget build(BuildContext context) {
            TextStyle textStyle = Theme.of(context).textTheme.display1;
            return new Card(
                color: Colors.white,
                child: new Center(
                    child: new Column(
                        mainAxisSize: MainAxisSize.min,
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: new List<Widget> {
                            new Icon(this.choice.icon, size: 128.0f, color: textStyle.color),
                            new RaisedButton(
                                child: new Text(this.choice.title, style: textStyle),
                                onPressed: () => {
                                    SnackBar snackBar = new SnackBar(
                                        content: new Text(this.choice.title + " is chosen !"),
                                        action: new SnackBarAction(
                                            label: "Ok",
                                            onPressed: () => { }));

                                    Scaffold.of(context).showSnackBar(snackBar);
                                })
                        }
                    )
                )
            );
        }
    }
}
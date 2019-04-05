using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace UIWidgetsSample
{
    public class BottomAppBarWidget : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new Scaffold(
                backgroundColor: Color.clear,
                bottomNavigationBar: new BottomAppBar(
                    child: new Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        mainAxisSize: MainAxisSize.max,
                        children: new List<Widget>
                        {
                            new IconButton(icon: new Icon(Unity.UIWidgets.material.Icons.menu),onPressed: () =>{}),
                            new IconButton(icon: new Icon(Unity.UIWidgets.material.Icons.account_balance),onPressed: () =>{})
                        }
                    )
                )
            );
        }
    }
}
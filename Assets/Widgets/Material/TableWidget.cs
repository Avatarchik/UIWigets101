using System.Collections.Generic;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;

namespace UIWidgetsSample
{
    public class TableWidget : StatelessWidget
    {
        public override Widget build(BuildContext context)
        {
            return new Scaffold(
                body: new Table(
                    children: new List<TableRow>
                    {
                        new TableRow(
                            decoration: new BoxDecoration(Color.white),
                            children: new List<Widget>
                            {
                                new Text("Head 1"),
                                new Text("Head 2")
                            }
                        ),
                        new TableRow(
                        decoration: new BoxDecoration(Color.white),
                        children: new List<Widget>
                        {
                            new Text("item 1"),
                            new Text("item 2")
                        }
                        )
                    },
                    defaultVerticalAlignment: TableCellVerticalAlignment.middle
                )
                
            );
        }
    }
}
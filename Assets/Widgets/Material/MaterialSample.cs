using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;

namespace UIWidgetsSample
{
    public class MaterialSample : UIWidgetsPanel
    {
        int testCaseId = 2;

        List<Widget> testCases = new List<Widget> {
            new TableWidget(),
            new BottomAppBarWidget(),
            new MaterialTabBarWidget()
        };
        
        protected override Widget createWidget()
        {
            return new MaterialApp(
                showPerformanceOverlay: true,
                home: testCases[testCaseId]
            );
        }

        protected override void Awake()
        {
            base.Awake();
            FontManager.instance.addFont(Resources.Load<Font>(path: "MaterialIcons-Regular"), "Material Icons");
        }
    }
}
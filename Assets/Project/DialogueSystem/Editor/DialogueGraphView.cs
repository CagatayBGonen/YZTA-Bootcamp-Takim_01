using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DialogueGraphView : GraphView
{
    public DialogueGraphView()
    {
        //StyleSheet styleSheet = Resources.Load<StyleSheet>("DialogueGraphStyle");
        //if (styleSheet != null)
        //{
        //    styleSheets.Add(styleSheet);
        //}
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        this.graphViewChanged += OnGraphViewChanged;
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        var grid = new GridBackground();
        Insert(0, grid);
        grid.StretchToParentSize();

        graphViewChanged = OnGraphViewChanged;

        AddElement(CreateStartNode());
    }

    private DialogueNode CreateStartNode()
    {
        var node = new DialogueNode
        {
            GUID = System.Guid.NewGuid().ToString()
        };
        node.Draw();
        node.SetPosition(new Rect(100, 200, 250, 150));
        AddElement(node);
        return node;
    }

    private GraphViewChange OnGraphViewChanged(GraphViewChange change)
    {
        return change;
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        evt.menu.AppendAction("Add Dialogue Node", (actionEvent) => {
            AddElement(CreateDialogueNode("Yeni Diyalog"));
        });
    }
    public DialogueNode CreateDialogueNode(string nodeText)
    {
        var node = new DialogueNode
        {
            title = "Dialogue Node",
            GUID = System.Guid.NewGuid().ToString(),
            DialogueText = nodeText
        };

        node.SetPosition(new Rect(200, 200, 200, 150));
        node.Draw();
        return node;
    }

    private Port GeneratePort(DialogueNode node, Direction portDirection, Port.Capacity capacity = Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(float));
    }
}

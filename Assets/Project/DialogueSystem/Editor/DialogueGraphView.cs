using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueGraphView : GraphView
{
    public DialogueGraphView()
    {
        // Zoom ve panning
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        // Manipulators
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        // Grid background
        this.Insert(0, new GridBackground());
        this.StretchToParentSize();

        // Stil
        StyleSheet styleSheet = Resources.Load<StyleSheet>("DialogueGraphStyle");
        if (styleSheet != null)
        {
            styleSheets.Add(styleSheet);
        }

        AddElement(CreateStartNode());
        this.AddManipulator(new ContextualMenuManipulator(contextEvent =>
        {
            contextEvent.menu.AppendAction("Add Dialogue Node", a => AddDialogueNode("Yeni Konuþma"));
        }));

    }
    private DialogueNode CreateStartNode()
    {
        var node = new DialogueNode
        {
            title = "START",
            GUID = System.Guid.NewGuid().ToString(),
            DialogueText = "Giriþ Konuþmasý"
        };

        node.SetPosition(new Rect(100, 200, 200, 150));
        node.Draw();
        return node;
    }
    public void AddChoicePort(DialogueNode node, string portName = "")
    {
        var generatedPort = node.InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));

        generatedPort.portName = string.IsNullOrEmpty(portName) ? "Next" : portName;

        var textField = new TextField
        {
            value = generatedPort.portName
        };

        textField.RegisterValueChangedCallback(evt => generatedPort.portName = evt.newValue);
        generatedPort.contentContainer.Add(new Label(" choice "));
        generatedPort.contentContainer.Add(textField);

        var deleteButton = new Button(() => node.outputContainer.Remove(generatedPort))
        {
            text = "X"
        };
        generatedPort.contentContainer.Add(deleteButton);

        node.outputContainer.Add(generatedPort);
        node.RefreshPorts();
        node.RefreshExpandedState();
    }
    public void AddDialogueNode(string nodeName)
    {
        var node = new DialogueNode
        {
            title = nodeName,
            GUID = System.Guid.NewGuid().ToString(),
            DialogueText = "..."
        };

        node.SetPosition(new Rect(300, 300, 200, 150));
        node.Draw();
        AddElement(node);
    }

}

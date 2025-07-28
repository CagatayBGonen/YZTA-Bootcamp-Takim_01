using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueNode : Node
{
    public string GUID;
    public string DialogueText = "Diyalog buraya yazýlacak.";

    public Port inputPort;
    public Port outputPort;

    public void Draw()
    {
        // Main container
        var textField = new TextField()
        {
            value = DialogueText
        };
        textField.RegisterValueChangedCallback(evt =>
        {
            DialogueText = evt.newValue;
        });
        mainContainer.Add(textField);

        // Input Port
        inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(float));
        inputPort.portName = "Input";
        inputContainer.Add(inputPort);

        // Output Port
        outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(float));
        outputPort.portName = "Next";
        outputContainer.Add(outputPort);

        RefreshExpandedState();
        RefreshPorts();
    }
}

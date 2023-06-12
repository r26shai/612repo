using UnityEngine;
using UnityEngine.UI;

public class ButtonSplit : MonoBehaviour
{
    public Button button;  // Reference to the UI button
    public SphereSplitter sphereSplitter;  // Reference to the SphereSplitter component

    private void Start()
    {
        // Attach the SplitSphere method to the button's onClick event
        button.onClick.AddListener(CallSplitSphere);
    }

    private void CallSplitSphere()
    {
        // Call the SplitSphere method from the SphereSplitter component
        sphereSplitter.SplitSphere();
    }
}

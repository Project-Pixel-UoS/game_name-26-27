using UnityEngine;

public class UIHelperFunctions : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject button;

    /// <summary>
    /// Changes if the panel is active or not based on argument
    /// </summary>
    /// <param name="state">The state to change to</param>
    public void SetPanelActive(bool state)
    {
        if (panel != null)
        {
            panel.SetActive(state);
        }
    }

    /// <summary>
    /// Changes if the button is active or not based on argument
    /// </summary>
    /// <param name="state">The state to change to</param>
    public void SetButtonActive(bool state)
    {
        if (button != null)
        {
            button.SetActive(state);
        }
    }
}

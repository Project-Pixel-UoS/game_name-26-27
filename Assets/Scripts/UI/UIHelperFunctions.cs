using UnityEngine;

public class UIHelperFunctions : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject button;

    /// <summary>
    /// Changes if the panel is active or not based on argument
    /// </summary>
    public void SetPanelActive(bool state)
    {
        if (panel != null)
        {
            panel.SetActive(state);
        }
    }

    public void SetButtonActive(bool state)
    {
        if (button != null)
        {
            button.SetActive(state);
        }
    }
}

using UnityEngine;

public class PanelControlller : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject button;

    /// <summary>
    /// Activates panel and hides button if supplied
    /// </summary>
    public void OpenPanel()
    {
        // Makes sure that there is a panel
        if (panel != null)
        {
            panel.SetActive(true);

            // Hides the button when the panel loads
            if (button != null)
            {
                button.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Deactivates panel
    /// </summary>
    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}

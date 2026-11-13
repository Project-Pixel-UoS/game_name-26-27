using UnityEngine;

public class PanelControlller : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject button;

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

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CardRewardMenu : MonoBehaviour
{
    [SerializeField] GameObject cardRewardPanel;
    // The button that confirms the card choice
    [SerializeField] Button confirmationButton;
    // The button that opens the card reward panel
    [SerializeField] Button cardRewardPanelButton;
    private const int NUMBER_OF_OPTIONS = 3;

    // Stores cards in an array for ease of access, Only wrapper containing the card prefab is added to array
    public GameObject[] cardOptions = new GameObject[NUMBER_OF_OPTIONS];
    
    /// <summary>
    /// Loads the listeners and asigns the cards to cardOptions array
    /// </summary>
    void Awake()
    {
        confirmationButton.onClick.AddListener(confirmChoice);
    }
    
    /// <summary>
    /// Called when confirm choice button
    /// Only removes option to change card choice
    /// Disables confirmationButton, enables cardRewardPanelButton
    /// Hides the cards reward panel
    /// </summary>
    public void confirmChoice()
    {
        // Make the cards not interactable
        for (int i = 0; i < NUMBER_OF_OPTIONS; i++)
        {
            cardOptions[i].GetComponent<Toggle>().interactable = false;
        }
        // Enables and disables buttons and panels
        confirmationButton.gameObject.SetActive(false);
        cardRewardPanelButton.gameObject.SetActive(true);
        cardRewardPanel.SetActive(false);
    }

    /// <summary>
    /// Deletes the listener when gameObject is deleted
    /// </summary>
    public void OnDestroy()
    {
        confirmationButton.onClick.RemoveListener(confirmChoice);
    }
}
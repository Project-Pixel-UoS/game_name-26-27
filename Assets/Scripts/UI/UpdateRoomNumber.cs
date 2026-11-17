using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

/// <summary>
/// This class is responsible for updating the current room number in the UI.
/// </summary>
/// <remarks>
/// Maintained by: Michael Edems-Eze
/// </remarks>
public class UpdateRoomNumber : MonoBehaviour
{
    public TMPro.TextMeshProUGUI roomNumberText; // Reference to the TextMeshProUGUI component that displays the room number
    // Update is called once per frame
    
    void Start()
    {        
        roomNumberText = GetComponent<TMPro.TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to this GameObject
        if (roomNumberText == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned in the inspector.");
            return;
        }
        roomNumberText.text = "Room: " + RoomManager.instance.roomCounter.ToString(); // Initialize the text to show the current room number
    }
    void Update()
    {
        roomNumberText.text = "Room: " + RoomManager.instance.roomCounter.ToString(); // Update the text to show the current room number
    }
}

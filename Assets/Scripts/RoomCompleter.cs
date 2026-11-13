using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tempory controller to hide and show buttons in correct sequence for next room.
/// Will be controlled by the enemy controller in future
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
public class RoomCompleter : MonoBehaviour
{
    [SerializeField] private Button completeRoom;
    [SerializeField] private Button nextRoom;

    public event System.Action OnAllEnemiesKilled;

    /// <summary>
    /// Called by the Complete Room Button
    /// </summary>
    public void CompleteRoom()
    {
        // Toggle Buttons
        completeRoom.gameObject.SetActive(false);
        nextRoom.gameObject.SetActive(true);

        // Listened to by Room Manager to set room state
        OnAllEnemiesKilled.Invoke(); 
    }

    /// <summary>
    /// Called by the Next Room button.
    /// Triggers the loading of the next room.
    /// </summary>
    public void NextRoom()
    {
        // Toggle buttons
        completeRoom.gameObject.SetActive(true);
        nextRoom.gameObject.SetActive(false);

        RoomManager.instance.NextRoom();
    }
}

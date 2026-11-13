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

    public void CompleteRoom()
    {
        // Toggle Buttons
        completeRoom.gameObject.SetActive(false);
        nextRoom.gameObject.SetActive(true);

        OnAllEnemiesKilled.Invoke();
    }

    public void NextRoom()
    {
        // Toggle buttons
        completeRoom.gameObject.SetActive(true);
        nextRoom.gameObject.SetActive(false);

        RoomManager.instance.NextRoom();
    }
}

using System.IO;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

/// <summary>
/// A singleton to control the state and loading of rooms
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
public class RoomManager : MonoBehaviour
{
    public static RoomManager instance { get; private set; }
    public int roomCounter { get; private set; } = 1;

    [SerializeField] private RoomCompleter UIManager;
    private RoomData roomData;
    public bool isCompleted { get; private set; } = false;

    /// <summary>
    /// setter function for the isCompleted variable.
    /// </summary>
    private void SetComplete() { isCompleted = true; }

    /// <summary>
    /// Unsubscribe from the OnAllEnemiesKilled event when unloaded.
    /// </summary>
    private void OnDisable()
    {
        UIManager.OnAllEnemiesKilled -= SetComplete;
    }

    /// <summary>
    /// Ensures that there is only one instance of a RoomManager
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            LoadNextRoom();
            UIManager.OnAllEnemiesKilled += SetComplete;
        }
    }

    /// <summary>
    /// Calls all processes to load the next room.
    /// </summary>
    private void LoadNextRoom()
    {
        LoadScriptableRoomObject();
        // Load the respective room type prefab
        // Then load the enemies as children

        // Debug
        if (roomData != null)
        {
            Debug.Log("Room " + roomCounter + " Loaded of type " + roomData.getRoomType());
        }
        else
        {
            Debug.Log("No room loaded");
        }
    }

    /// <summary>
    /// Loads the corresponding room object for the current roomCounter.
    /// Logs a Warning if the room is not found.
    /// Sets room = null if not found.
    /// </summary>
    private void LoadScriptableRoomObject()
    {
        var room = Resources.Load("Objects/Rooms/Room" + roomCounter);

        if (room == null)
        {
            Debug.LogWarning("No file found for room number " + roomCounter + ". Failed to load level.");
            return;
        }

        roomData = (RoomData)room;
    }

    /// <summary>
    /// Increments the room counter and triggers the load of the new room Data
    /// </summary>
    public void NextRoom()
    {
        if (isCompleted)
        {
            // Unload the current prefab then proceed

            roomCounter++;
            LoadNextRoom();
            isCompleted = false;
        }
    }

}

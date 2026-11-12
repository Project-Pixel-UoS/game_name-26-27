using Unity.VisualScripting;
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
    private RoomData roomData;
    private bool isCompleted = false;

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
            Create();
        }
    }

    /// <summary>
    /// Load initial level and debug
    /// </summary>
    private void Create()
    {
        LoadNextRoom();
        RoomLog();
    }

    /// <summary>
    /// Print out Debug information
    /// </summary>
    private void RoomLog()
    {
        Debug.Log("Room " + roomCounter + " Loaded. Of type " + roomData.getRoomType());
    }

    /// <summary>
    /// Loads the next RoomData object into the roomData variable
    /// </summary>
    private void LoadNextRoom()
    {
        // I don't know how to fetch a scriptable object?
        // Log the room type
    }

    /// <summary>
    /// Tempory function to complete the room immediately as there are no enemies
    /// </summary>
    public void CompleteRoom()
    {
        isCompleted = true;
    }

    /// <summary>
    /// Increments the room counter and triggers the load of the new room Data
    /// </summary>
    public void NextRoom()
    {
        if (isCompleted)
        {
            roomCounter++;
            LoadNextRoom();
            RoomLog();
            isCompleted = false;
        }
    }

}

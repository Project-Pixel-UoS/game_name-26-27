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
    }

    /// <summary>
    /// Print out Debug information
    /// </summary>
    private void RoomLog()
    {
        Debug.Log("Room " + roomCounter + " Loaded of type " + roomData.getRoomType());
    }

    /// <summary>
    /// Loads the next RoomData object into the roomData variable
    /// </summary>
    private void LoadNextRoom()
    {
        var room = Resources.Load("Objects/Rooms/Room" + roomCounter);

        if (room == null)
        {
            Debug.LogWarning("No file found for room number " + roomCounter + ". Failed to load level.");
            return;
        }

        roomData = (RoomData) room;
        RoomLog();
    }

    /// <summary>
    /// setter function for the isCompleted variable.
    /// </summary>
    /// <param name="state">state to be set.</param>
    public void SetComplete(bool state)
    {
        // Could be changed in future to check for no enemies and set true once all dead?
        // Although maybe this is the job of enemy controller

        isCompleted = state;
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
            isCompleted = false;
        }
    }

}

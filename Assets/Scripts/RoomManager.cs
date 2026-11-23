using UnityEngine;
using System.Collections.Generic;

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
    public bool isCompleted { get; private set; } = false;

    // Stores which room types link to which room prefab
    [SerializeField] private RoomToPrefab[] mappingList;
    // Stores the active room controller such as EnemySpawner
    private RoomCompletedCaller roomController;
    // Stores the scriptable object RoomData
    private RoomData roomData;
    private GameObject roomPrefab;

    /// <summary>
    /// setter function for the isCompleted variable.
    /// </summary>
    private void SetComplete() { isCompleted = true; Debug.Log("Room " + roomCounter + " completed."); }

    /// <summary>
    /// Returns room type.
    /// </summary>
    /// <returns>
    /// The name of the room type as a string
    /// </returns>
    public string GetRoomType()
    {
        if (roomData != null)
        {
            return roomData.getRoomType();
        }

        return null;
    }

    /// <summary>
    /// Unsubscribe from the OnAllEnemiesKilled event when unloaded.
    /// </summary>
    private void OnDisable()
    {
        UnloadRoom();
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
        }
    }

    /// <summary>
    /// Calls all processes to load the next room.
    /// </summary>
    private void LoadNextRoom()
    {
        if (!LoadScriptableRoomObject())
        {
            // Quit if no Room Data object
            Debug.LogWarning("No room data loaded");
            return;
        }
        
        if (!LoadPrefabRoom())
        {
            // Quit load if no prefab
            return;
        }

        if (!LoadRoomController())
        {
            // Warn if no room controller found
            Debug.LogWarning("No RoomCompletedCaller component found on prefab to set room completed.");
        }

        // TODO: Check if room controller is of enemySpawner type

        Debug.Log("Room " + roomCounter + " Loaded of type " + roomData.getRoomType() + " Successfully.");
            
    }

    /// <summary>
    /// Attemps to find the event Caller
    /// </summary>
    /// <returns></returns>
    public bool LoadRoomController()
    {
        // fetch RoomFinishCaller and subscribe
        roomController = roomPrefab.GetComponent<RoomCompletedCaller>();

        if (roomController == null) { return false; }

        if (roomController is EnemySpawner)
        {
            EnemySpawner _roomController = (EnemySpawner)roomController;
            _roomController.SetEnemyList(roomData.enemyTypes);
            _roomController.spawnEnemies();
        }
        
        // Subscribe to the room completed event
        roomController.OnRoomCompleted += SetComplete;
        return true;
    }

    /// <summary>
    /// Loads the corresponding room object for the current roomCounter.
    /// Logs a Warning if the room is not found.
    /// Sets room = null if not found.
    /// </summary>
    /// <returns>
    /// True if successful, False if not.
    /// </returns>
    private bool LoadScriptableRoomObject()
    {
        var room = Resources.Load<RoomData>("Objects/Rooms/Room" + roomCounter);

        if (room == null)
        {
            Debug.LogWarning("No file found for room number " + roomCounter + ". Failed to load level.");
            return false;
        }

        roomData = room;
        return true;
    }

    /// <summary>
    /// Loads the prefab that corresponds to the room type from mapping list
    /// </summary>
    /// <returns>
    /// True if successful, False if not.
    /// </returns>
    private bool LoadPrefabRoom()
    {
        // Load Correct prefab
        string name = roomData.getRoomType();

        foreach (RoomToPrefab mapping in mappingList)
        {
            if (mapping.type.ToString() == name)
            {
                roomPrefab = Instantiate(mapping.prefab);
                return true;
            }
        }
        
        Debug.LogWarning(roomData.getRoomType() + " Does not have an associated prefab, cannot load.");
        return false;
        
    }

    /// <summary>
    /// Increments the room counter and triggers the load of the new room Data.
    /// </summary>
    public void NextRoom()
    {
        if (isCompleted)
        {
            UnloadRoom();
            roomCounter++;
            isCompleted = false;
            LoadNextRoom();
        } else
        {
            Debug.LogWarning("Room " + roomCounter + " not completed, cannot move to next room.");
        }
    }

    /// <summary>
    /// Unloads the current room prefab, unsubscribes from the completeing event and sets the event caller reference to null.
    /// </summary>
    private void UnloadRoom()
    {
        if (roomPrefab != null)
        {
            roomController.OnRoomCompleted -= SetComplete;
            roomController = null;
            Destroy(roomPrefab);
        }
    }

}

[System.Serializable]
public struct RoomToPrefab
{
    public RoomType type;
    public GameObject prefab;
}

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
    public bool isCompleted { get; private set; } = false;


    [SerializeField] private RoomToPrefab[] mappingList;
    private RoomFinishCaller eventCaller;
    private RoomData roomData;
    private GameObject roomPrefab;
    /// <summary>
    /// setter function for the isCompleted variable.
    /// </summary>
    private void SetComplete() { isCompleted = true; }

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
        LoadScriptableRoomObject();

        if (roomData != null)
        {
            bool prefabLoaded = LoadPrefabRoom();

            if (prefabLoaded == false)
            {
                // Quit load if no prefab
                return;
            }

            // fetch RoomFinishCaller and subscribe
            eventCaller = roomPrefab.GetComponent<RoomFinishCaller>();
            if (eventCaller != null)
            {
                // Subscribe to the room completed event
                eventCaller.OnRoomCompleted += SetComplete;
            } else
            {
                Debug.LogWarning("No event caller found on prefab to set room completed.");
            }

            // TODO: Check if event caller is of enemySpawner type

            Debug.Log("Room " + roomCounter + " Loaded of type " + roomData.getRoomType());
            
        }
        else
        {
            Debug.Log("No room data loaded");
        }
    }

    /// <summary>
    /// Loads the corresponding room object for the current roomCounter.
    /// Logs a Warning if the room is not found.
    /// Sets room = null if not found.
    /// </summary>
    private void LoadScriptableRoomObject()
    {
        var room = Resources.Load<RoomData>("Objects/Rooms/Room" + roomCounter);

        if (room == null)
        {
            Debug.LogWarning("No file found for room number " + roomCounter + ". Failed to load level.");
            return;
        }

        roomData = room;
    }

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
        }
    }

    /// <summary>
    /// Unloads the current room prefab, unsubscribes from the completeing event and sets the event caller reference to null.
    /// </summary>
    private void UnloadRoom()
    {
        if (roomPrefab != null)
        {
            eventCaller.OnRoomCompleted -= SetComplete;
            eventCaller = null;
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

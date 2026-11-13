using System.IO;
using System.Security.Cryptography;
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
    public bool isCompleted { get; private set; } = false;


    [SerializeField] private RoomToPrefab[] mappingList;
    [SerializeField] private RoomCompleter UIManager;
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

        if (roomData != null)
        {
            bool prefabLoaded = LoadPrefabRoom();

            if (prefabLoaded == false)
            {
                return;
            }

            SpawnEnemies();

            if (prefabLoaded)
            {
                Debug.Log("Room " + roomCounter + " Loaded of type " + roomData.getRoomType());
            } 
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

    private void SpawnEnemies()
    {
        // IDK 
    }

    /// <summary>
    /// Increments the room counter and triggers the load of the new room Data
    /// </summary>
    public void NextRoom()
    {
        if (isCompleted)
        {
            Destroy(roomPrefab);
            roomCounter++;
            isCompleted = false;
            LoadNextRoom();
        }
    }

}

[System.Serializable]
public struct RoomToPrefab
{
    public RoomType type;
    public GameObject prefab;
}

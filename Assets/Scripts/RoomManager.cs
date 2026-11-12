using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance { get; private set; }

    private int roomCounter;
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
        }
    }

    /// <summary>
    /// Loads the next RoomData object into the roomData variable
    /// </summary>
    private void LoadNextRoom()
    {

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
        }
    }

}

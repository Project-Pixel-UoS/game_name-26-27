using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "Scriptable Objects/RoomData")]

// Files should be named to be "Room1" or "Room2" and so on


/// <summary>
/// Stores data about each Room, such as which enemies can spawn
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
public class RoomData : ScriptableObject
{
    public GameObject[] spawnOptions;

    public RoomType roomType;

    public string getRoomType()
    {

        string type = roomType.ToString();
        return type;
    }
}

/// <summary>
/// an enum for different types of room
/// </summary>
public enum RoomType
{
    HEALING,
    COMBAT
}
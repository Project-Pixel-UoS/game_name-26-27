using System;
using UnityEngine;

/// <summary>
/// Defines requirements for a Individual room controllers. Allows polymorphism
/// </summary>
public class RoomCompletedCaller : MonoBehaviour
{
    // The event that Room Manager subscribes to detect a completed room
    public event Action OnRoomCompleted;

    /// <summary>
    /// Allows children to invoke the event
    /// </summary>
    protected void InvokeCompleted()
    {
        OnRoomCompleted.Invoke();
    }

    /// <summary>
    /// Allows children to call next room
    /// </summary>
    protected void NextRoom()
    {
        Debug.Log("Attempting to load next room.");
        RoomManager.instance.NextRoom();
    }
}

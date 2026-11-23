using System;
using UnityEngine;

/// <summary>
/// Defines requirements for a Individual room controllers. Allows polymorphism
/// </summary>
public class RoomCompletedCaller : MonoBehaviour
{
    // The event that Room Manager subscribes to detect a completed room
    public event Action OnRoomCompleted;

    protected void InvokeCompleted()
    {
        OnRoomCompleted.Invoke();
    }

    protected void NextRoom()
    {
        Debug.Log("Next Room");
        RoomManager.instance.NextRoom();
    }
}

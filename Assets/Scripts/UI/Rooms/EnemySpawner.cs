using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spawns the enemies in correct positions and
/// Invokes completed on all enemies killed
/// </summary>
public class EnemySpawner : RoomCompletedCaller
{
    [SerializeField] private Button nextRoomButton;

    public void Start()
    {
        InvokeCompleted();
        nextRoomButton.onClick.AddListener(NextRoom);
    }
}

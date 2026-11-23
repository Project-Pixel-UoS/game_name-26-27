using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Invokes the completed room event, manages buttons and healing
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
public class HealthRoom : RoomCompletedCaller
{
    [SerializeField] private Button nextRoomButton;
    [SerializeField] private Button healButton;

    /// <summary>
    /// Subscribes to button onClick events.
    /// </summary>
    public void Start()
    {
        healButton.onClick.AddListener(Heal);
        nextRoomButton.onClick.AddListener(NextRoom);
    }

    /// <summary>
    /// Logs healing interaction and toggles buttons visibility.
    /// </summary>
    public void Heal()
    {
        Debug.Log("Healing Player");
        InvokeCompleted();

        healButton.gameObject.SetActive(false);
        nextRoomButton.gameObject.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Invokes the room complete event and upgrading
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
public class LabRoom : RoomCompletedCaller
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button nextRoomButton;

    /// <summary>
    /// Subscribes to click events of ui buttons
    /// </summary>
    public void Start()
    {
        nextRoomButton.onClick.AddListener(NextRoom);
    }

    /// <summary>
    /// Logs upgrade interaction and changes required button visibility.
    /// </summary>
    public void Upgrade()
    {
        Debug.Log("Upgrading cards");
        InvokeCompleted();

        upgradeButton.gameObject.SetActive(false);
        nextRoomButton.gameObject.SetActive(true);
    }

}

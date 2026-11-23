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

    public void Start()
    {
        upgradeButton.onClick.AddListener(Upgrade);
        nextRoomButton.onClick.AddListener(NextRoom);
    }

    public void Upgrade()
    {
        Debug.Log("Upgrading cards");
        InvokeCompleted();

        upgradeButton.gameObject.SetActive(false);
        nextRoomButton.gameObject.SetActive(true);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class HealthRoom : RoomCompletedCaller
{
    [SerializeField] private Button nextRoomButton;
    [SerializeField] private Button healButton;

    public void Start()
    {
        healButton.onClick.AddListener(Heal);
    }

    public void Heal()
    {
        Debug.Log("Healing Player");
        InvokeCompleted();

        healButton.gameObject.SetActive(false);
        nextRoomButton.gameObject.SetActive(true);
    }

    public void NextRoom()
    {
        RoomManager.instance.NextRoom();
    }
}

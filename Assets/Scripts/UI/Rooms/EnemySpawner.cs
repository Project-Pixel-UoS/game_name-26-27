using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spawns the enemies in correct positions and
/// Invokes completed on all enemies killed
/// </summary>
public class EnemySpawner : RoomCompletedCaller
{
    [SerializeField] private Button nextRoomButton;
    private GameObject[] activeEnemies = new GameObject[0];
    private GameObject[] enemySpawnList;
    private bool enemySpawnSet = false;

    public void Start()
    {
        nextRoomButton.onClick.AddListener(NextRoom);
    }

    public void Update()
    {
        if (activeEnemies.Length <= 0) { InvokeCompleted(); }
    }

    public void KillAllEnemies()
    {
        foreach (GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }

        activeEnemies = new GameObject[0];

        InvokeCompleted();
    }

    public void SetEnemyList(GameObject[] list)
    {
        // Only allow one set
        if (!enemySpawnSet)
        {
            enemySpawnList = list;
        }
    }

    public void spawnEnemies()
    {
        // Calculate positions
        // Spawn enemies on positions
    }
}

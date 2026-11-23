using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spawns the enemies in correct positions and
/// Invokes completed on all enemies killed
/// </summary>
public class EnemySpawner : RoomCompletedCaller
{
    [SerializeField] private Button nextRoomButton;
    [SerializeField] private Button completeRoomButton;
    // Current spawned enemies
    private List<GameObject> activeEnemies = new List<GameObject>(0);
    // Enemies to spawn on room start
    private List<GameObject> enemySpawnList;
    // Whether the enemies spawn list has been assigned
    public bool enemySpawnSet { private set; get; } = false;

    /// <summary>
    /// Subscribes next room to the on click event for next room
    /// </summary>
    private void Start()
    {
        // Cos its inherited this method doesn't show up in inspector
        nextRoomButton.onClick.AddListener(NextRoom);
    }

    /// <summary>
    /// Invokes the completed event when all enemies are dead.
    /// This will be more useful when battling works
    /// </summary>
    private void Update()
    {
        if (activeEnemies.Capacity <= 0 && !RoomManager.instance.isCompleted) { InvokeCompleted(); }

        if (RoomManager.instance.isCompleted)
        {
            completeRoomButton.gameObject.SetActive(false);
            nextRoomButton.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Controls the UI visibility and kills all enemies when button is pressed
    /// temporary for now since there is no battling.
    /// </summary>
    public void CompleteRoom()
    {
        KillAllEnemies();

        completeRoomButton.gameObject.SetActive(false);
        nextRoomButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// Defines the process of killing all enemies and clearing the active enemy list.
    /// </summary>
    public void KillAllEnemies()
    {
        foreach (GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }

        activeEnemies = new List<GameObject>(0);
    }

    /// <summary>
    /// Sets the enemy list
    /// </summary>
    /// <param name="list"> The list that the enemy spawn list will be set with</param>
    public void SetEnemyList(List<GameObject> list)
    {
        // Only allow one set
        if (!enemySpawnSet)
        {
            enemySpawnList = list;
            enemySpawnSet = true;
        }
    }

    /// <summary>
    /// triggers calculation of enemy positions and spawns enemies at those assigned computers.
    /// </summary>
    public void spawnEnemies()
    {

        // define a position for each enemy to space them based of their width and width of screen.
        // uses a mobile orientation
        // align horizontally in the middle of the screen

        
        foreach (GameObject enemy in enemySpawnList)
        {
            // TODO: would apply position here on spawn
            var _enemy = Instantiate(enemy);
            activeEnemies.Add(_enemy);
        }
    }
}

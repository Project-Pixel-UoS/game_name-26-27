using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spawns the enemies in correct positions and
/// Invokes completed on all enemies killed
/// </summary>
/// <remarks>
/// Maintained by: Bailey Stewart
/// </remarks>
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
        if (activeEnemies.Count <= 0 && !RoomManager.instance.isCompleted) { InvokeCompleted(); }

        if (RoomManager.instance.isCompleted && completeRoomButton.gameObject.activeSelf    )
        {
            completeRoomButton.gameObject.SetActive(false);
            nextRoomButton.gameObject.SetActive(true);
        }
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
        // Only allow one set call to happen
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
        // Store the width of each enemy
        List<float> widths = new List<float>();
        float totalWidth = 0.0f;
        const float minPadding = 0.1f;

        foreach (GameObject enemy in enemySpawnList)
        {
            GameObject _enemy = Instantiate(enemy);
            activeEnemies.Add(_enemy);

            float width = _enemy.GetComponentInChildren<Renderer>().bounds.size.x;
            widths.Add(width);
            totalWidth += width;
        }

        var cam = Camera.main;
        float screenWidth = cam.orthographicSize * 2f * cam.aspect;

        float leftEdge = cam.transform.position.x - screenWidth * 0.5f;

        float paddingSpace = screenWidth - totalWidth; // Total free space left on screen
        float padding = paddingSpace / (enemySpawnList.Count + 1.0f); // Padding between edges and enemies

        // prevent them from overlapping
        if (padding < minPadding)
        {
            padding = minPadding;
        }

        float offset = leftEdge + padding;// Moves from left to right as tempory X coord assignment
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            offset += widths[i] * 0.5f;
            activeEnemies[i].transform.position = new Vector3(offset, cam.transform.position.y, 0);
            offset += widths[i] * 0.5f + padding;

        }

    }
}
   
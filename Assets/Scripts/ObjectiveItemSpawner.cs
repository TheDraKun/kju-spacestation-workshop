using System.Collections.Generic;
using UnityEngine;

public class ObjectiveItemSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ObjectiveItem objectiveItemPrefab;
    [SerializeField] private Transform spawnPointContainer;
    private int spawnCount = 3;

    private readonly List<Transform> spawnPoints = new();

    private void Awake()
    {
        CacheSpawnPoints();
    }

    private void Start()
    {
        SpawnObjectiveItems();
    }

    private void CacheSpawnPoints()
    {
        spawnPoints.Clear();

        foreach (Transform point in spawnPointContainer)
        {
            spawnPoints.Add(point);
        }
    }

    private void SpawnObjectiveItems()
    {
        if (objectiveItemPrefab == null)
        {
            Debug.LogError("Objective Item Prefab is missing!");
            return;
        }

        if (spawnPoints.Count == 0)
        {
            Debug.LogError("No Spawn Points assigned!");
            return;
        }

        List<Transform> availablePoints = new(spawnPoints);

        Shuffle(availablePoints);

        int itemsToSpawn = Mathf.Min(spawnCount, availablePoints.Count);

        for (int i = 0; i < itemsToSpawn; i++)
        {
            Instantiate(
                objectiveItemPrefab,
                availablePoints[i].position,
                Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f),
                transform);
        }
    }

    private void Shuffle(List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);

            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }

    internal void SetSpawnCount(int requiredItems)
    {
        spawnCount = requiredItems;
    }
}
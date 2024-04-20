using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    MinigameController controller;

    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject crateWarning;
    [SerializeField] private float spawnRange = 8f;
    [SerializeField] private float maxCrateDistance = 8f;

    private float spawnTimer;
    private float lastSpawnLocation = 0;
    private float nextSpawnLocation = 0;

    private void Start()
    {
        controller = FindFirstObjectByType<MinigameController>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            do
            {
                nextSpawnLocation = transform.position.x + Random.Range(-spawnRange, spawnRange);
            } while (Mathf.Abs(nextSpawnLocation - lastSpawnLocation) > maxCrateDistance);

            Instantiate(crateWarning, new Vector2(nextSpawnLocation, transform.position.y), Quaternion.identity);

            lastSpawnLocation = nextSpawnLocation;
            spawnTimer = spawnDelay;
        }
    }

    public void CaughtCrate(int value)
    {
        controller.IncreaseScore(value);
    }

    public void DroppedCrate(int value)
    {
        controller.DecreaseScore(value);
    }
}

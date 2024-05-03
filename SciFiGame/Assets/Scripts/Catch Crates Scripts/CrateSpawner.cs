using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    MinigameController controller;

    [SerializeField] private float spawnRate;
    [SerializeField] private float rateRange;
    [SerializeField] private float maxCrateDistance = 8f;
    [SerializeField] private GameObject crateWarning;
    [SerializeField] private MinigameController miniController;

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
        if (miniController.gameStarted)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer < 0)
        {
            do
            {
                nextSpawnLocation = transform.position.x + Random.Range(-8, 8);
            } while (Mathf.Abs(nextSpawnLocation - lastSpawnLocation) > maxCrateDistance);

            Instantiate(crateWarning, new Vector2(nextSpawnLocation, transform.position.y), Quaternion.identity);

            lastSpawnLocation = nextSpawnLocation;
            spawnTimer = spawnRate + Random.Range(-rateRange, rateRange);
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

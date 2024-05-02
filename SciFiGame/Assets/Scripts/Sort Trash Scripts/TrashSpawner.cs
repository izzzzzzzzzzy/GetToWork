using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] spawnedItems;
    [SerializeField] private float spawnRange = 1;
    [SerializeField] private MinigameController miniController;

    public float spawnTimer;
   
    // Update is called once per frame
    void Update()
    {
        if (miniController.gameStarted)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer < 0)
        {
            Vector2 spawnPos = new(transform.position.x + Random.Range(-spawnRange, spawnRange), transform.position.y);
            GameObject spawnedItem = spawnedItems[Random.Range(0, spawnedItems.Length)];

            Instantiate(spawnedItem, spawnPos, transform.rotation);
            spawnTimer = spawnRate;
        }
    }
}

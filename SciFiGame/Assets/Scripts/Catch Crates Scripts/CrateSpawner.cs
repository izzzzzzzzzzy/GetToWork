using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject crate;
    [SerializeField] private GameObject crateWarning;
    [SerializeField] private float spawnRange = 1f;
    [SerializeField] private float crateWarningLifetime = 2f;

    private float spawnTimer;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            StartCoroutine(SpawnCrate(transform.position.x + Random.Range(-spawnRange, spawnRange)));
            spawnTimer = spawnRate;
        }
    }

    IEnumerator SpawnCrate(float xPosition)
    {
        Vector2 spawnPos = new(xPosition, transform.position.y);

        Instantiate(crateWarning, spawnPos + (2*Vector2.down), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Instantiate(crate, spawnPos, Quaternion.identity);
    }
}

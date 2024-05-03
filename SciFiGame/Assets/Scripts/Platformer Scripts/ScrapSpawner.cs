using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScrapSpawner : MonoBehaviour {
    MinigameController controller;

    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject scrap;
    [SerializeField] private MinigameController miniController;

    private float spawnTimer;

    private void Start() {
        controller = FindFirstObjectByType<MinigameController>();
    }

    // Update is called once per frame
    void Update() {
        if (miniController.gameStarted) {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer < 0) {

            Vector2 spawnPos = transform.position + Random.insideUnitSphere * 10;
            Instantiate(scrap, spawnPos, Quaternion.identity);

            spawnTimer = spawnDelay;
        }
    }
}

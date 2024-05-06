using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawningBug : MonoBehaviour {
    MinigameController controller;

    [SerializeField] private float timer;
    [SerializeField] private GameObject bug;
  //  [SerializeField] private MinigameController miniController;
    public int waitTime;
    public int upperLimit;
    public int lowerLimit;
    public int range;

    private void Start() {
        //     controller = FindFirstObjectByType<MinigameController>();
        range = Random.Range(lowerLimit, upperLimit);

    }

    // Update is called once per frame
    void Update() {

        if (timer < 0) {
            timer = range;
            range = Random.Range(lowerLimit, upperLimit);

            Vector2 spawnPos = transform.position + Random.insideUnitSphere * 10;
            Instantiate(bug, spawnPos, Quaternion.identity);
        }

      //  if (miniController.gameStarted) {
            timer -= Time.deltaTime;
       // }
    }

    private void SpawnBug() {
        Vector2 spawnPos = transform.position + Random.insideUnitSphere * 10;
        Instantiate(bug, spawnPos, Quaternion.identity);
    }
}
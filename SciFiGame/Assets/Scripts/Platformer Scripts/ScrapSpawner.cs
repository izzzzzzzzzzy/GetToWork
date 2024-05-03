using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScrapSpawner : MonoBehaviour {
    MinigameController controller;

    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject scrap;
    [SerializeField] private MinigameController miniController;
    public int upperLimit;
    public int lowerLimit;

    private void Start() {
        controller = FindFirstObjectByType<MinigameController>();
        int range = Random.Range(lowerLimit, upperLimit);

        for (int i = 0; i < range; i++) {
            Vector2 spawnPos = transform.position + Random.insideUnitSphere * 10;
            Instantiate(scrap, spawnPos, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update() {

      
    }
}

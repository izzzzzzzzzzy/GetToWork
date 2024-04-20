using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float rateRange = .5f;

    public BugHole[] allHoles;
    public List<BugHole> freeHoles = new();
    private BugHole hole;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        allHoles = GetComponentsInChildren<BugHole>();
    } 

    // Update is called once per frame
    void Update()
    {
        foreach (BugHole hole in  allHoles)
        {
            if (!hole.HasBug() && !freeHoles.Contains(hole)) 
            {
                freeHoles.Add(hole);
            }
        }

        if (timer < 0 && freeHoles.Count > 0)
        {
            timer = spawnRate + Random.Range(-rateRange, rateRange);

            hole = freeHoles[Random.Range(0, freeHoles.Count)];
            freeHoles.Remove(hole);

            hole.SpawnBug();
        }

        timer -= Time.deltaTime;
    }
}

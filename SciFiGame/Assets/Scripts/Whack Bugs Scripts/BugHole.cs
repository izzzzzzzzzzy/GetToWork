using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHole : MonoBehaviour
{
    [SerializeField] private GameObject bug;
    [SerializeField] private Vector3 spawnOffset = new Vector3(0, 0.5f, 0);

    private GameObject currentBug;
    public bool hasBug;

    // Update is called once per frame
    void Update()
    {
        hasBug = currentBug != null;
    }

    public bool HasBug()
    {
        return hasBug;
    }

    public void SpawnBug()
    {
        currentBug = Instantiate(bug, transform.position + spawnOffset, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private MinigameController gameManager;

    [SerializeField] private float lifetime;
    [SerializeField] private int value;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<MinigameController>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime < 0)
        {
            gameManager.DecreaseScore(value);

            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        gameManager.IncreaseScore(value);
        Destroy(gameObject);
    }
}

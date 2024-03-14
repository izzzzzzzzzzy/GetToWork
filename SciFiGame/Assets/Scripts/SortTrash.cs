using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortTrash : MonoBehaviour
{

    [SerializeField] private float gameTime = 60f;
    [SerializeField] private float target = 20f;
    [SerializeField] private float score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime < 0)
        {
            //TODO: End minigame
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void DecreaseScore()
    {
        score--;
    }
}

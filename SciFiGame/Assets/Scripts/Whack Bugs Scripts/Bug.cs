using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private MinigameController gameManager;
    Animator anim;

    [SerializeField] private float lifetime;
    [SerializeField] private int value;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<MinigameController>();
        anim = GetComponent<Animator>();
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
        anim.SetBool("isHit", true);
        StartCoroutine(waitSecsBeforeDestroying(0.7f));
    }

    private IEnumerator waitSecsBeforeDestroying(float i){
        yield return new WaitForSeconds(i);
        Destroy(gameObject);
    }
}

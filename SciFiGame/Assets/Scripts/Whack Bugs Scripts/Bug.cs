using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    private MinigameController gameManager;
    Animator anim;
    AudioSource audioSource;

    [SerializeField] private float lifetime;
    [SerializeField] private int value;

    private bool isKilled;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindFirstObjectByType<MinigameController>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        if (!isKilled)
        {
            isKilled = true;
            gameManager.IncreaseScore(value);
            anim.SetBool("isHit", true);
            audioSource.Play();
            StartCoroutine(WaitSecsBeforeDestroying(0.7f));
        }
    }

    private IEnumerator WaitSecsBeforeDestroying(float i){
        yield return new WaitForSeconds(i);
        Destroy(gameObject);
    }
}

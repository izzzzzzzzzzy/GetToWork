using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (lifetime < 0 && !isKilled)
        {
            isKilled = true;
            gameManager.DecreaseScore(value);
            StartCoroutine(Descend());
        }
    }

    private void OnMouseDown()
    {
        if (!isKilled && !SceneController.Instance.IsPaused())
        {
            isKilled = true;
            gameManager.IncreaseScore(value);
            audioSource.Play();
            StartCoroutine(Descend());
        }
    }

    private IEnumerator Descend()
    {
        anim.SetBool("isHit", true);
        yield return new WaitForSeconds(.7f);
        Destroy(gameObject);
    }
}

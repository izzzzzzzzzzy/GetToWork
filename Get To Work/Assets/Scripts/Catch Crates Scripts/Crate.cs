using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    CrateSpawner spawner;
    Rigidbody2D rb;
    AudioSource ads;

    [SerializeField] private int value;

    private bool broken;

    public AudioClip onStackSound;
    public AudioClip onBreakSound;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindFirstObjectByType<CrateSpawner>();
        rb = GetComponent<Rigidbody2D>();
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!broken && collider.CompareTag("Crate Stack"))
        {
            transform.SetParent(collider.transform.parent);
            spawner.CaughtCrate(value);
            ads.clip = onStackSound;
            ads.Play();
            Destroy(rb);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            spawner.DroppedCrate(value);
            ads.clip = onBreakSound;
            ads.Play();
            StartCoroutine(WaitForSound());
        }
    }

    IEnumerator WaitForSound(){
        while (ads.isPlaying){
            yield return null;
        }

        Destroy(gameObject);
    }
}

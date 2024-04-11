using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    DraggableScript draggableScript;
    MinigameController gameManager;
    AudioSource audioSource;

    [SerializeField] private int trashType;
    [SerializeField] private float speed = 5;
    [SerializeField] private int value = 1;

    public bool onBelt;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        draggableScript = GetComponent<DraggableScript>();
        gameManager = FindFirstObjectByType<MinigameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7.5)
        {
            transform.position = new Vector2(transform.position.x, -7.5f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Conveyor"))
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }

        if (collision.CompareTag("Chute") && !draggableScript.dragging == true)
        {
            if (trashType == collision.GetComponent<TrashChute>().GetBinType())
            {
                gameManager.IncreaseScore(value);
            }
            else
            {
                gameManager.DecreaseScore(value);
            }

            Destroy(gameObject);
        }
    }

    public void SetSpeed(int nSpeed)
    {
        speed = nSpeed;
    }
}

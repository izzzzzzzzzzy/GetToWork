using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Draggable draggable;
    MinigameController gameManager;

    [SerializeField] private int trashType;
    [SerializeField] private float speed = 5;
    [SerializeField] private int value = 1;
    [SerializeField] private Vector2 conveyorBottomLeft;
    [SerializeField] private Vector2 conveyorTopRight;

    // Start is called before the first frame update
    void Start()
    {
        draggable = GetComponent<Draggable>();
        gameManager = FindFirstObjectByType<MinigameController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= conveyorBottomLeft.x && transform.position.y >= conveyorBottomLeft.y && 
                    transform.position.x <= conveyorTopRight.x && transform.position.y <= conveyorTopRight.y)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Chute") && draggable.dragging == false)
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
}

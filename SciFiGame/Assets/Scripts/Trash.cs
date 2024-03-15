using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    DraggableScript draggableScript;
    SortTrash gameManager;

    [SerializeField] private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow };
    [SerializeField] private float speed = 5;

    private int color;
    public bool onBelt;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        draggableScript = GetComponent<DraggableScript>();
        gameManager = FindFirstObjectByType<SortTrash>();

        color = Mathf.FloorToInt(Random.Range(0, colors.Length));

        spriteRenderer.color = colors[color];
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
            if (color == collision.GetComponent<TrashChute>().GetColor())
            {
                gameManager.IncreaseScore();
            }
            else
            {
                gameManager.DecreaseScore();
            }

            Destroy(gameObject);
        }
    }

    public void SetSpeed(int nSpeed)
    {
        speed = nSpeed;
    }
}

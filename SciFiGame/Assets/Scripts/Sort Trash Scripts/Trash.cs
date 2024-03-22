using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    DraggableScript draggableScript;
    MinigameController gameManager;

    public Sprite trash;
    public Sprite glass;
    public Sprite compost;
    public Sprite cardboard;

    [SerializeField] private Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow };
    [SerializeField] private float speed = 5;
    [SerializeField] private int value = 1;

    private int color;
    public bool onBelt;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        draggableScript = GetComponent<DraggableScript>();
        gameManager = FindFirstObjectByType<MinigameController>();

        color = Mathf.FloorToInt(Random.Range(0, colors.Length));

        //spriteRenderer.color = colors[color];
        if (colors[color] == Color.red) {
            spriteRenderer.sprite = trash;
        } else if (colors[color] == Color.blue) {
            spriteRenderer.sprite = glass;
        } else if (colors[color] == Color.green) {
            spriteRenderer.sprite = compost;
        } else {
            spriteRenderer.sprite = cardboard;
        }
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

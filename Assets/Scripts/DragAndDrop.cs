using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public int foodID;
    private bool canMove;
    private bool isDragging;

    [SerializeField] private string gameObjectTag;
    new Collider2D collider2D;

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        canMove = false;
        isDragging = false;
    }

    private void Update()
    {
        // PC
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (collider2D == Physics2D.OverlapPoint(mousePosition))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }

            if (canMove) isDragging = true;
        }

        if (isDragging)
        {
            transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            isDragging = false;
        }

        // Mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (collider2D == Physics2D.OverlapPoint(touchPosition))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }

                if (canMove)
                {
                    isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                transform.position = touchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                canMove = false;
                isDragging = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(gameObjectTag))
        {
            if (other.gameObject.CompareTag("Steamer") || other.gameObject.CompareTag("Fryer") || other.gameObject.CompareTag("Container"))
            {
                other.gameObject.GetComponent<ContainerManager>().Cook();
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}

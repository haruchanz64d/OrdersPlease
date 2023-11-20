using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum Emotion { NORMAL, SATISFIED, ANGRY }

public class Customer : MonoBehaviour
{
    private int selectedFoodID;
    public Food[] food;
    public SpriteRenderer orderBubble;
    public SpriteRenderer customerSprite;
    public Sprite[] customerState;
    public bool isSatisfied { get; private set; }
    public bool isAngry { get; private set; }

    private Food selectedFood;

    private void Start()
    {
        int randomIndex = Random.Range(0, food.Length);
        selectedFood = food[randomIndex];
        selectedFoodID = selectedFood.foodId;
        orderBubble.sprite = selectedFood.foodImage;

        StartCoroutine(DeleteOrderBubble());
    }

    private IEnumerator DeleteOrderBubble(){
        yield return new WaitForSeconds(2.0f);
        Destroy(orderBubble);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DragAndDrop>().foodID.Equals(0))
            return;

        if (selectedFoodID.Equals(other.gameObject.GetComponent<DragAndDrop>().foodID))
        {
            customerSprite.sprite = customerState[1];
            Invoke("SetSatisfied", 2.0f);
            Destroy(other.gameObject);
        }
        else
        {
            customerSprite.sprite = customerState[2];
            Invoke("SetAngry", 2.0f);
            Destroy(other.gameObject);
        }
    }

    public void SetSatisfied()
    {
        isSatisfied = true;
    }

    public void SetAngry()
    {
        isAngry = true;
    }
}
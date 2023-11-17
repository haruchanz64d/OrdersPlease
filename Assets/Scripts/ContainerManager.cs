using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public enum States { READY, COOKING, DONE }

public class ContainerManager : MonoBehaviour
{
    public Sprite[] sprite;
    public States state;
    public GameObject cookedFoodPrefab;
    [SerializeField] private float cookTimer;
    public Transform foodSpawnPoint;
    private void Start()
    {
        state = States.READY;
    }

    private void Update()
    {
        switch (state)
        {
            case States.READY:
                GetComponent<Image>().overrideSprite = sprite[0];
                break;
            case States.COOKING:
                GetComponent<Image>().overrideSprite = sprite[1];
                break;
            case States.DONE:
                GetComponent<Image>().overrideSprite = sprite[2];
                break;
        }
    }

    public void Cook()
    {
        state = States.COOKING;
        StartCoroutine(OnCookingProcess());
    }

    private IEnumerator OnCookingProcess()
    {
        yield return new WaitForSeconds(cookTimer);
        CookFood();
    }

    private void CookFood()
    {
        state = States.DONE;

        Instantiate(cookedFoodPrefab, foodSpawnPoint.position, Quaternion.identity);

        state = States.READY;
    }
}

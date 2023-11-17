using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject[] customer;
    public Transform customerSpawnPoint;
    private float customerSpawnDelay = 3.0f;
    private bool isCustomerPresent;
    private int customerCount;
    private float timer;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI customerCountText;
    private int failedOrders;
    public TextMeshProUGUI failedOrdersText;
    private int ordersPlaced;
    public TextMeshProUGUI ordersPlacedText;
    private GameObject currentCustomer;
    public CanvasManager canvasManager;

    private void Start()
    {
        timer = 30f;
        score = 0;
        StartCoroutine(SpawnCustomers());
    }

    private void Update()
    {
        if (isCustomerPresent)
        {
            timer -= Time.deltaTime;
            timerText.SetText(timer.ToString("F0"));
        }

        if (ordersPlaced >= 15)
        {
            timer = 15f;
        }

        if (timer <= 0)
        {
            StartCoroutine(SpawnCustomers());
        }

        if (customerCount >= 30 && ordersPlaced == 30)
        {
            canvasManager.OnGameSuccess();
        }

        if (currentCustomer == null)
            return;
            
        if (currentCustomer.GetComponent<Customer>().isSatisfied == true)
        {
            OrderPlaced();
            ResetTimer();
        }
        if (currentCustomer.GetComponent<Customer>().isAngry == true)
        {
            OrderFailed();
            ResetTimer();
        }
    }
    private IEnumerator SpawnCustomers()
    {
        yield return new WaitForSeconds(customerSpawnDelay);
        isCustomerPresent = true;
        int randomCustomerIndex = Random.Range(0, customer.Length);
        GameObject customerPrefab = customer[randomCustomerIndex];
        currentCustomer = Instantiate(customerPrefab, customerSpawnPoint.position, Quaternion.identity);

        customerCount++;
        customerCountText.SetText(customerCount.ToString());

        yield return new WaitForSeconds(timer);
    }

    public void OrderPlaced()
    {
        ordersPlaced++;
        score += 200;
        scoreText.SetText(score.ToString());
        ordersPlacedText.SetText(ordersPlaced.ToString());
        Destroy(currentCustomer);
        isCustomerPresent = false;
        StartCoroutine(SpawnCustomers());
        if (ordersPlaced == 30)
        {
            canvasManager.OnGameSuccess();
        }
    }

    public void OrderFailed()
    {
        failedOrders++;
        failedOrdersText.SetText(failedOrders.ToString());
        Destroy(currentCustomer);
        isCustomerPresent = false;
        StartCoroutine(SpawnCustomers());
        if (failedOrders == 5)
        {
            canvasManager.OnGameOver();
        }
    }

    private void ResetTimer()
    {
        timer = 30f;
        if (ordersPlaced >= 15)
        {
            timer = 15f;
        }
    }
}

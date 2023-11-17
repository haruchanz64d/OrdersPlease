using UnityEngine;

public class RawFoodSpawner : MonoBehaviour
{
    public GameObject rawFoodPrefab;
    public Transform foodSpawnPoint;
    public void SpawnRawFood()
    {
        Instantiate(rawFoodPrefab, foodSpawnPoint.position, Quaternion.identity);
    }
}
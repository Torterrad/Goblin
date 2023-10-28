using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnA; 
    [SerializeField] private Transform spawnB;

    [SerializeField] private GameObject foodObject;

    public float targetTime = 2f;

    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        SpawnObject();
        targetTime = 2f;
    }

    private void SpawnObject()
    {
        Vector3 difference = spawnA.position - spawnB.position;
        Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);
        Vector3 random_position = spawnA.position - new_difference;
        Instantiate(foodObject, random_position, Quaternion.identity);
    }
}

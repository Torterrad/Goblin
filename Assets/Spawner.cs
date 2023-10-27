using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnA; 
    [SerializeField] private Transform spawnB;

    [SerializeField] public GameObject foodObject;

    void Update()
    {
        //TIMER/SCORE BASED
        SpawnObject();
    }

    private void SpawnObject()
    {
        Vector3 difference = spawnA.position - spawnB.position;
        Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);
        Vector3 random_position = spawnA.position - new_difference;
        Instantiate(foodObject, random_position, Quaternion.identity);
    }
}

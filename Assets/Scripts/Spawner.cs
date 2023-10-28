using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnA; 
    [SerializeField] private Transform spawnB;

    [SerializeField] private GameObject foodObject;

    [Header("Score")]
    public Score score;

    [SerializeField] private float targetIncrease = 1000f;

    [SerializeField] private float timeReset;
    [SerializeField] private float setTime = 3f;
    [SerializeField] private float timeDecrement = 0.2f;

    private void Awake()
    {
        timeReset = setTime;
    }

    void Update()
    {
        setTime -= Time.deltaTime;

        if (setTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        SpawnObject();
        setTime = timeReset;
    }

    public void timeDecrease()
    {
        if(setTime <= 0.8f)
        setTime = setTime - timeDecrement;
    }
    private void SpawnObject()
    {
        Vector3 difference = spawnA.position - spawnB.position;
        Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);
        Vector3 random_position = spawnA.position - new_difference;
        Instantiate(foodObject, random_position, Quaternion.identity);
    }
}

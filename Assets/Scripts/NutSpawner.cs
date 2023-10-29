using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnA;
    [SerializeField] private Transform spawnB;

    [SerializeField] private GameObject foodObject;

    [Header("Score")]
    public Score score;
    public FoodMovement food;


    [SerializeField] private float timeReset;
    [SerializeField] private float setNutTime;
    [SerializeField] private float setNutQuantity;
    [SerializeField] private float nutCount = 0;
    public Spawner foodSpawner;
    public bool sleep;

    void Start()
    {
        timeReset = setNutTime;
        sleep = true;
    }

    void Update()
    {
        if (!sleep)
        {
            if (nutCount == setNutQuantity)
            {
                nutCount = 0;
                sleep = true;
            }
            else
                timerCountdown();
        }
    }

    void timerCountdown()
    {
        setNutTime -= Time.deltaTime;

        if (setNutTime <= 0.0f)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        SpawnObject();
        nutCount += 1;
        setNutTime = timeReset;
    }
    private void SpawnObject()
    {
        Vector3 difference = spawnA.position - spawnB.position;
        Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);
        Vector3 random_position = spawnA.position - new_difference;
        Instantiate(foodObject, random_position, Quaternion.identity);
    }

    private void OnDisable()
    {
        sleep = true;
        timeReset = setNutTime;

    }

    public void SetSleepTrue()
    {
        sleep = true;
    }

    public void SetSleepFalse()
    {
        sleep = false;
    }
}

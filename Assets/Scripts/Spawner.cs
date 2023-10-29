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
    public FoodMovement food;
    

    [SerializeField] private float timeReset;
    [SerializeField] private float setTime;
    [SerializeField] private float timeDecrement;
    [SerializeField] private float spawnLimit;

    void Start()
    {
        timeReset = setTime;

    }

    void Update()
    {
        timerCountdown();
    }

    void timerCountdown()
    {
        setTime -= Time.deltaTime;

        if (setTime <= 0.0f)
        {
            timerEnded();
            timeDecrease();
            food.speedIncrease();
        }
    }


    void timerEnded()
    {
        SpawnObject();
    }

    public void timeDecrease()
    {
        if (timeReset > spawnLimit)
        {
            timeReset = (float)System.Math.Round(timeReset- timeDecrement,2);
            Debug.Log("SPAWN RATE INCREASED" + "timeReset: "+ timeReset);
        }
        setTime = timeReset;
    }
    private void SpawnObject()
    {
        Vector3 difference = spawnA.position - spawnB.position;
        Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);
        Vector3 random_position = spawnA.position - new_difference;
        Instantiate(foodObject, random_position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Fall");
    }
}

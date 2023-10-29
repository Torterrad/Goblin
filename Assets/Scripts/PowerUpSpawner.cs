using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnA;
    [SerializeField] private Transform spawnB;

    [SerializeField] private GameObject powerUp;

    [Header("Score")]
    public Score score;

    [SerializeField] private float spawnTimeMin;
    [SerializeField] private float spawnTimeMax;
    [SerializeField] private float timeReset;
    [SerializeField] private float setTime;

    public NutSpawner nutSpawner;

    private void Awake()
    {
        timeReset = Random.Range(spawnTimeMin, spawnTimeMax);
        setTime = timeReset;
    }

    void Update()
    {
        if(nutSpawner.sleep)
            timerCountdown();
    }

    void timerCountdown()
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
        timeReset = Random.Range(spawnTimeMin, spawnTimeMax);
        setTime = timeReset;
    }
    private void SpawnObject()
    {
        Vector3 difference = spawnA.position - spawnB.position;
        Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);
        Vector3 random_position = spawnA.position - new_difference;
        Instantiate(powerUp, random_position, Quaternion.identity);
    }
}

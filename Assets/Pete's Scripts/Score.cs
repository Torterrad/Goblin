using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score: MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int scoreValue;
    private int totalScore = 0;
    [SerializeField] private int targetIncrement;
    [SerializeField] private int targetHit;
    public int spawnerCount = 1;

    [Header("Spawner")]
    public Spawner spawner;

    [Header("Food")]
    public FoodMovement food;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score:" + totalScore.ToString();
        targetHit = targetIncrement;
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        totalScore = totalScore + scoreValue;
        scoreText.text = "Score:" + totalScore.ToString();
        if(totalScore == targetHit)
        {
            targetHit = targetHit + targetIncrement;
            //spawner.timeDecrease();
            //food.speedIncrease();
        }
    }
}

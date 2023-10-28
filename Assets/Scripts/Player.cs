using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("GameManager")]
    public GameManager GM; //GameManager

    [Header("Player Variables")]
    public int maxHealth = 3; //Set maxhealth 
    public int currentHealth;

    [Header("Health Variables")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        currentHealth = maxHealth; //set current health to maxHealth
    }

    public void TakeDamage()
    {
        currentHealth -= 1; //reduce current health
        //FindObjectOfType<AudioManager>().Play("sHurt");
        if (currentHealth <= 0) //if no health
        {
            Debug.Log("GameOver");
            GM.GameOver(); //Cause a game over
        }
        UpdateHealth();
    }

    void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < maxHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}

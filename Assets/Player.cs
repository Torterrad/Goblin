using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("GameManager")]
    public GameManager GM; //GameManager

    [Header("Player Variables")]
    public int maxHealth = 3; //Set maxhealth 
    public int currentHealth;

    void Start()
    {
        maxHealth = currentHealth; //set current health to maxHealth
    }

    public void TakeDamage()
    {
        currentHealth -= 1; //reduce current health
        //Update Health in UI
        //FindObjectOfType<AudioManager>().Play("sHurt");
        if (currentHealth <= 0) //if no health
            Debug.Log("GameOver");
            //GM.GameOver(); //Cause a game over
    }
}

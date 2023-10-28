using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int MaxHealth;
   // public int CurrentHealth;
    //  public GameManager GameManager;
    public Player script;


    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


     void Awake()
    {
        //GameManager = GameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < MaxHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if(i < script.currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if(i < 1)
            {
               // GameManager.GameOver();
            }
        }
    }


}

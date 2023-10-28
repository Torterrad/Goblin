using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Food Varibles")]
    private float foodType;
    [SerializeField] private Sprite[] meatList;
    [SerializeField] private Sprite[] vegList;
    private int foodSprite;
    [SerializeField] private float fallMin;
    [SerializeField] private float fallMax;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(fallMin, fallMax);
        foodType = Random.Range(0, 2);
        Debug.Log(foodType);
        if (foodType == 0f)
            SetVeg();
        else
            SetMeat();

    }

    private void SetVeg()
    {
        gameObject.tag = "Veg"; //set tag
        //pick sprite
        foodSprite = Random.Range(0, 11);
        GetComponent<SpriteRenderer>().sprite = vegList[foodSprite];
    }

    private void SetMeat()
    {
        gameObject.tag = "Meat"; //set tag
        //pick sprite
        foodSprite = Random.Range(0, 11);
        GetComponent<SpriteRenderer>().sprite = meatList[foodSprite];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject != null)
        {
            if ((collision.gameObject.CompareTag("Ground") || (collision.gameObject.CompareTag("Player"))))
            {
                Destroy(gameObject);
            }
        }
    }

}

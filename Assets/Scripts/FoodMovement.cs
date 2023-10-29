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
    [SerializeField] private float fallIncrement;
    [SerializeField] private float fallMinLimit;
    [SerializeField] private float fallMaxLimit;

    public GameObject splat;

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
        foodSprite = Random.Range(0, 12);
        GetComponent<SpriteRenderer>().sprite = vegList[foodSprite];
    }

    private void SetMeat()
    {
        gameObject.tag = "Meat"; //set tag
        //pick sprite
        foodSprite = Random.Range(0, 12);
        GetComponent<SpriteRenderer>().sprite = meatList[foodSprite];
    }

    public void speedIncrease()
    {
        if (fallMin < fallMinLimit || fallMax < fallMaxLimit)
        {
            fallMin = (float)System.Math.Round(fallMin+fallIncrement,3);
            fallMax = (float)System.Math.Round(fallMax+fallIncrement,3);
        }
        Debug.Log("INCREASE DROP SPEED! " + "FallMin: " + fallMin + " FallMax" + fallMax);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject != null)
        {
            if ((collision.gameObject.CompareTag("Ground") || (collision.gameObject.CompareTag("Player"))))
            {
                Vector2 SpawnHere = new Vector2(transform.position.x, -5.15f);
                Instantiate(splat, SpawnHere, collision.transform.rotation);
                
                //PETE I'VE AT CLEANED CODE AND FIXED IT, YOU CANNOT DO THE COROUTINE IN HERE BC THE OBJECT GETS DESTROYED
                //i made a new script on splat object all is needed is the coroutine and destroy
                //the transform is just is position when it is destroyed anyway you
                ////dont need a vector3 if its 2d or if its just going to be the current position
                /////temp isnt needed bc it works the same way food spawns in, its just bc we dont have a prefab yet
                
                
                Destroy(gameObject);
            }

            if ((collision.gameObject.CompareTag("Player")))
            {
                FindObjectOfType<AudioManager>().Play("Eat");
            }
            if ((collision.gameObject.CompareTag("Ground")))
            {
                FindObjectOfType<AudioManager>().Play("Splat1");
            }
        }
    }

}

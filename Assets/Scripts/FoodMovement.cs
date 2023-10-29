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

    public GameObject splat;
    public Vector3 SpawnHere;
    public GameObject food;
    GameObject temp;
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
        temp = Instantiate(splat);

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

    public void speedIncrease()
    {
        fallMin = fallMin + fallIncrement;
        fallMax = fallMax + fallIncrement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject != null)
        {
            if ((collision.gameObject.CompareTag("Ground") || (collision.gameObject.CompareTag("Player"))))
            {
                Destroy(gameObject);
                SpawnHere = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Instantiate(temp, SpawnHere, collision.transform.rotation);
                FindObjectOfType<AudioManager>().Play("Splat1");
                // Instantiate(splat);
                Destroy(gameObject);

                StartCoroutine(SelfDestruct());
                Destroy(temp);
            }
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}

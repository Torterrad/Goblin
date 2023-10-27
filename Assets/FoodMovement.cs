using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Food Varibles")]
    [SerializeField] private float fallMin;
    [SerializeField] private float fallMax;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(fallMin, fallMax);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}

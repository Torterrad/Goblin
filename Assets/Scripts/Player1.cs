using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [Header("GameManager")]
    public GameManager GM; //GameManager

    [Header("Score")]
    public Score score;

    [Header("Player Handler")]
    public Player playerHandler;

    [Header("iFrames")]
    [SerializeField] private Color flashColor; //Color for the player to flash 
    private Color regularColor; //regular colour of sprite will be assigned to this
    [SerializeField] SpriteRenderer sprite; //reference to spriteRenderer
    [SerializeField] float flashDuration; //flash duration
    [SerializeField] int numberOfFlashes; //the number of times the player will flicker
    [SerializeField] bool invincible; //determine if player can be damaged

    void Start()
    {
        regularColor = sprite.color; //get colour of sprite
    }

    private IEnumerator iFrame()
    {
        //Change the sprites colour repeatedily imitating that classic super mario style
        int temp = 0;
        invincible = true; //now player has been damaged they should be invinsible 
        while (temp < numberOfFlashes)
        {
            sprite.color = flashColor; //turn to flash colour
            yield return new WaitForSeconds(flashDuration); //how long to remain that sprite colour
            sprite.color = regularColor; //revert to regular colour
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        invincible = false; //when flashing is over they are able to be damaged again
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Veg")) //when not invincible and the object colliding with is an Enemy 
            score.UpdateScore();
        else if (!invincible && other.CompareTag("Meat"))
        {
            playerHandler.TakeDamage();
            StartCoroutine(iFrame());
        }
    }
}

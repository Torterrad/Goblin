using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Expat Studios (2020) 2D Retro Platformer Tutorial - Unity - pt.6 (Game Manager & clean up) [Online Video] [Access Date: 4th May 2022] https://youtu.be/LxdH7AZpLLo

public class GameManager : MonoBehaviour
{
  

    [Header("Player")]
    public GameObject player1;
    public GameObject player2;

    [Header("Victory/GameOver")]

    public bool hasWon = false;
    public bool hasLost = false;
    public GameObject gameOverScreen;

    [Header("Pause")]
    public GameObject PauseScreen;
    public bool GameIsPaused = false;

    public GameObject GameUI;


    void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
      //  movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
      //  player.gameObject.SetActive(true);
        //GetSceneName();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (hasWon == false && hasLost == false)) //if the game has neither been won or lost, let the player pause with ESC
        {
            if (GameIsPaused) //if paused resume
            {
                Resume();
            }
            else //otherwise paused
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Deactivate pause screen, play music, set Time scale back to normal and now Game is not paused
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        //Same as resume but opposite
        PauseScreen.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GameOver()
    {
        //Activate game over screen
        gameOverScreen.SetActive(true);
        //Deactivate UI containing all other elements
        GameUI.GetComponent<Canvas>().enabled = false;
        //Disable the player, they shouldn't be able to control player after death
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);

        GameIsPaused = true; //core functions/updates in the game will halt while this is true
        hasLost = true; //Player has lost

        Time.timeScale = 0f; //freeze everything
    }

    public void Restart()
    {
        //Restart and deactivate victory or gameover screens
        gameOverScreen.SetActive(false);
        //get scene name from the scene and load it
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadMenu()
    {
        //reset time scale, game is not longer paused and load scene named Menu
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool startGame;
    public static bool gameOver, pauseGame;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        DefaultGameActions();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            GameOverPanel.SetActive(true);
        }
    }
    public void GameAction(string action)
    {
        if(action=="StartGame")
        {
            startGame = true;
        }
        if(action=="GameOver")
        {
            gameOver = true;
        }
        if(action=="PauseGame")
        {
            pauseGame = true;
        }
        if(action=="Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public static void DefaultGameActions()
    {
        startGame = false;
        gameOver = false;
        pauseGame = false;
    }
}

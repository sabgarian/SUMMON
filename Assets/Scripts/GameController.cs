using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public void GameOver()
    {
        gameOverScreen.Setup();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }
    }
}

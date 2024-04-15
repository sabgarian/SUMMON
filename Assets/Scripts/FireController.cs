using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
            gameOverScreen.Setup();
        }
        else if (collision.gameObject.name == "WaterCreature")
        {
            gameObject.SetActive(false);
        }
    }
}

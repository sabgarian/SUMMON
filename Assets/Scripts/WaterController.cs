using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public GameObject iceBlock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
            gameOverScreen.Setup();
        }
        else if (collision.gameObject.name == "IceCreature")
        {
            gameObject.SetActive(false);
            iceBlock.SetActive(true);
        }
    }
}

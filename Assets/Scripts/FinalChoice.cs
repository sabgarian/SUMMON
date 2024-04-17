using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalChoice : MonoBehaviour
{
    public void KnightButton()
    {
        SceneManager.LoadScene("BadEnding");
    }
    public void DemonButton()
    {
        SceneManager.LoadScene("GoodEnding");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour
{
    public Button Quit;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Player quit the game");
    }
}

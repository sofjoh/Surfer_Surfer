using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour
{
    [Tooltip("button for quit game")]
    public Button QuitButton;
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Player quit the game");
    }
}

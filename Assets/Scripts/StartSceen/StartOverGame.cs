using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartOverGame : MonoBehaviour
{
    [Tooltip("Button for play again")]
    public Button PlayAgainButton;

    public void restartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

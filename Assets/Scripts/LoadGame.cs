using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{

    public Button playButton;
    public void LoadMainScene()
    {
        Debug.Log("game scene");
        SceneManager.LoadScene(1);
    }
}

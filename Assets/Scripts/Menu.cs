using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
    public Canvas menuCanvas;
    public Canvas gameOverCanvas;

    void Awake()
    {
        gameOverCanvas.enabled = false;
    }

    public void gameOverOn()
    {
        gameOverCanvas.enabled = true;
        menuCanvas.enabled = false;
    }

    public void ReturnOn()
    {
        gameOverCanvas.enabled = false;
        menuCanvas.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene("Merge", LoadSceneMode.Additive);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
    public Canvas menuCanvas;
    public Canvas gameOverCanvas;
    public Text points;

    void Awake()
    {
        GameObject go = GameObject.Find("GUIController");

        if (go != null)
        {
            Debug.Log("GuiController existiert");

            points.text = go.GetComponent<GUIText>().text;
            go.GetComponent<GUIText>().enabled = false;
            gameOverOn();
        } else
        {
            ReturnOn();
        }
    }

    public void gameOverOn()
    {
        gameOverCanvas.enabled = true;
        menuCanvas.enabled = false;
    }

    public void ReturnOn()
    {
        GameObject go = GameObject.Find("GUIController");
        if(go != null)
        {
            Destroy(go);
        }

        gameOverCanvas.enabled = false;
        menuCanvas.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene("Merge", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

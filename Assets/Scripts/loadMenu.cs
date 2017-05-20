using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMenu : MonoBehaviour {

    // Use this for initialization
    void Start() {
        SceneManager.LoadScene("Asteriods", LoadSceneMode.Additive);
        SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update () {
        GameObject go = GameObject.Find("GUIController");
        if(go != null)
        {
            Destroy(go);
        }
    }
}

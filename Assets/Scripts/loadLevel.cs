using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
        SceneManager.LoadScene("Asteriods", LoadSceneMode.Additive);
        SceneManager.LoadScene("ShipScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

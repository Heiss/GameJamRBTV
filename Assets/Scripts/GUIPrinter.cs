using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIPrinter : MonoBehaviour {
    private int punktZahl1, punktZahl2;
    private GUIText timer;
    private float startTimer;

	// Use this for initialization
	void Start () {
        punktZahl1 = 0;
        punktZahl2 = 0;

        startTimer = Time.time;

        timer = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer.text = "Zeit: " + System.Math.Round(Time.time - startTimer, 2) + "s\n" + "Punktzahl: \n\tRot:" + punktZahl1 + " : Blau: " + punktZahl2;
    }

    void increasePointsForPlayer(int player)
    {
        if (player == 1)
        {
            punktZahl1++;
        } else
        {
            punktZahl2++;
        }
    }
}

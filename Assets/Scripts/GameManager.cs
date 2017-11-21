using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	private void Start () {
        BeginGame ();
	}
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
	}

    private void BeginGame() { }

    private void RestartGame() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;

    private Maze mazeInstance;

    // Use this for initialization
    private void Start ()
    {
        BeginGame ();
	}
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
	}

    private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(mazeInstance.Generate());
        StartCoroutine(mazeInstance.Init());
        //StartCoroutine(mazeInstance.Suffle());
        
        //StartCoroutine(mazeInstance.Research());
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}

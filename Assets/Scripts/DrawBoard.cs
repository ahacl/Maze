using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoard : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 90; i += 3)
        {
            for (int j = 0; j < 90; j += 3)
            {
               Instantiate(obj, new Vector3(i, 0, j), Quaternion.identity);
            }
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {

    private Renderer rend;

    //private Color startColor;

	void Start ()
    {
        rend = GetComponent<Renderer>();
        //startColor = rend.material.color;
    }

    public void SetColor()
    {
        rend.material.color = Color.red;
    }
}

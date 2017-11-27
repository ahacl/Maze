using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour {

    public Plate QuadPrefab;
    public GameObject UP;
    public GameObject DOWN;
    public GameObject LEFT;
    public GameObject RIGHT;
    private bool mazeCheck = false;
    private int vector = 0;

    public void SetmazeCheck(bool _mazeCheck)
    {
        mazeCheck = _mazeCheck;
    }

    public bool GetmazeCheck()
    {
        return mazeCheck;
    }

    public void Setvector(int _vector)
    {
        vector = _vector;
    }

    public int Getvector()
    {
        return vector;
    }

    public void DestroyBlock(int vector)
    {
        if(vector == 1)
        {
            Destroy(UP);
        }
        else if(vector == 2)
        {
            Destroy(DOWN);
        }
        else if(vector == 3)
        {
            Destroy(LEFT);
        }
        else if (vector == 4)
        {
            Destroy(RIGHT);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

    public int sizeX, sizeZ;

    private int[] location = new int[400];

    public MazeCell cellPrefab;

    private MazeCell[,] cells;

    public float generationStepDelay;

    public float researchStepDelay;

    public float InitStepDelay;

    private int remain = 400;

    private float SuffleStepDelay = 0;

    private int pointX;
    private int pointZ;

    public IEnumerator Init()
    {
        WaitForSeconds delay = new WaitForSeconds(InitStepDelay);
        Debug.Log("Init start");
        for (int i = 0; i < 400; i++)
        {
            yield return delay;
            location[i] = i;
        }
        Debug.Log("Init end");
        yield return StartCoroutine(Suffle());
        Debug.Log("Init end2");
    }

    public IEnumerator Suffle()
    {
        WaitForSeconds delay = new WaitForSeconds(SuffleStepDelay);
        for (int i = 0; i < (sizeX*sizeZ*2); i++)
        {
            yield return delay;
            int target1 = Random.Range(1, 400);
            int target2 = Random.Range(1, 400);
            int temp = location[target1];
            location[target1] = location[target2];
            location[target2] = temp;
            //Debug.Log(location[target1].ToString() + location[target2].ToString());
        }

        cells[0, 0].SetmazeCheck(true);
        remain -= 1;

        int x = location[0] / sizeX;
        int z = location[0] % sizeZ;
        pointX = x;
        pointZ = z;
        yield return StartCoroutine(Research(x, z));
    }

    public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[sizeX, sizeZ];
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                yield return delay;
                CreateCell(x, z);
            }
        }
    }

    public IEnumerator Research(int x, int z)
    {
        int k = 0;
        while (remain > 0)
        {
            while (true)
            {
                yield return null;
                if (cells[x, z].GetmazeCheck() == true)
                {
                    k += 1;
                    x = location[k] / sizeX;
                    z = location[k] % sizeZ;
                    pointX = x;
                    pointZ = z;

                }
                else
                    break;
            }
            while (true)
            {
                yield return null;
                int path = Random.Range(1, 5);
                if (path == 1)
                {
                    if (x != 0)
                    {
                        cells[x, z].Setvector(1);
                        Debug.Log(location[(x * sizeX) + z].ToString() + "    " + cells[x, z].Getvector().ToString() + "     " + ((x * sizeX) + z).ToString());
                        if (cells[x - 1, z].GetmazeCheck() == true)
                        {
                            Debug.Log("I got it!!!");
                            break;
                        }
                        x -= 1;
                    }
                }
                else if (path == 2)
                {
                    if (x != sizeX - 1)
                    {
                        cells[x, z].Setvector(2);
                        Debug.Log(location[(x * sizeX) + z].ToString() + "    " + cells[x, z].Getvector().ToString() + "     " + ((x * sizeX) + z).ToString());
                        if (cells[x + 1, z].GetmazeCheck() == true)
                        {
                            Debug.Log("I got it!!!");
                            break;
                        }
                        x += 1;
                    }
                }
                else if (path == 3)
                {
                    if (z != 0)
                    {
                        cells[x, z].Setvector(3);
                        Debug.Log(location[(x * sizeX) + z].ToString() + "    " + cells[x, z].Getvector().ToString() + "     " + ((x * sizeX) + z).ToString());
                        if (cells[x, z - 1].GetmazeCheck() == true)
                        {
                            Debug.Log("I got it!!!");
                            break;
                        }
                        z -= 1;
                    }
                }
                else if (path == 4)
                {
                    if (z != sizeX - 1)
                    {
                        cells[x, z].Setvector(4);
                        Debug.Log(location[(x * sizeX) + z].ToString() + "    " + cells[x, z].Getvector().ToString() + "     " + ((x * sizeX) + z).ToString());
                        if (cells[x, z + 1].GetmazeCheck() == true)
                        {
                            Debug.Log("I got it!!!");
                            break;
                        }
                        z += 1;
                    }
                }
            }
            yield return StartCoroutine(Chase(pointX, pointZ));
        }
    }

    private IEnumerator Chase(int x, int z)
    {
        while (true)
        {
            yield return null;
            cells[x, z].SetmazeCheck(true);
            if (cells[x, z].Getvector() == 1)
            {
                remain -= 1;
                cells[x, z].QuadPrefab.SetColor();
                cells[x, z].DestroyBlock(1);
                cells[x - 1, z].DestroyBlock(2);
                if (cells[x - 1, z].GetmazeCheck() == true)
                {
                    break;
                }
                x -= 1;
            }
            else if (cells[x, z].Getvector() == 2)
            {
                remain -= 1;
                cells[x, z].QuadPrefab.SetColor();
                cells[x, z].DestroyBlock(2);
                cells[x + 1, z].DestroyBlock(1);
                if (cells[x + 1, z].GetmazeCheck() == true)
                {
                    break;
                }
                x += 1;
            }
            else if (cells[x, z].Getvector() == 3)
            {
                remain -= 1;
                cells[x, z].QuadPrefab.SetColor();
                cells[x, z].DestroyBlock(3);
                cells[x, z - 1].DestroyBlock(4);
                if (cells[x, z-1].GetmazeCheck() == true)
                {
                    break;
                }
                z -= 1;
            }
            else if (cells[x, z].Getvector() == 4)
            {
                remain -= 1;
                cells[x, z].QuadPrefab.SetColor();
                cells[x, z].DestroyBlock(4);
                cells[x, z + 1].DestroyBlock(3);
                if (cells[x, z+1].GetmazeCheck() == true)
                {
                    break;
                }
                z += 1;
            }
            Debug.Log(cells[x, z].Getvector().ToString());
        }
    }

    private void CreateCell (int x, int z)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[x, z] = newCell;
        newCell.name = "Maze Cell " + x + ", " + z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);
    }
}

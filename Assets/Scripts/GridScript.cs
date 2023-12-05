using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
    public GameObject[] grid;
    public int playerX;
    public int playerY;

    // Start is called before the first frame update
    void Start()
    {
        playerX = 0;
        playerY = 0;
        foreach (GameObject v in grid)
        {
            dictionary[v.name] = v;
        }
    }

    public void ClearIndicators()
    {
        foreach (GameObject v in grid)
        {
            v.GetComponent<GridSpace>().setIndicator(false);
        }
    }
}

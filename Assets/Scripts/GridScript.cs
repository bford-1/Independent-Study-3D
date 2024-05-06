using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridScript : MonoBehaviour
{
    public Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();
    public GameObject[] grid;
    public int playerX;
    public int playerY;
    public TextMeshProUGUI textMesh;
    public string ifelse;
    private Vector3 originalPosition;
    public string nam;

    void Start()
    {
        playerX = 0;
        playerY = 0;
        foreach (GameObject v in grid)
        {
            dictionary[v.name] = v;
            v.GetComponent<GridSpace>().setCamera(false);
        }
        grid[0].GetComponent<GridSpace>().setCamera(true);
    }
    public void Update()
    {
        string name1 = playerX.ToString() + "," + playerY.ToString();
        nam = name1;
        GameObject nameObj = GameObject.Find(name1);
        string upelse = nameObj.GetComponent<GridSpace>().ifelse;
        ifelse = upelse;
        nam = ifelse;

        if (textMesh != null)
        {
           textMesh.text = nam;
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

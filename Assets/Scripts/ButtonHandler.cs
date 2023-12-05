using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public string direction;
    public GameObject grid;
    
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }

    // Update is called once per frame
    public void Update()
    {   
        GameObject currentSpace = getCurrectSpace();

        if (/*Input.GetKeyDown(KeyCode.E) && */playerInRange)
        {
            if (direction == "Right")
            {
                if (grid.GetComponent<GridScript>().playerY < 4)
                {
                    grid.GetComponent<GridScript>().playerY++;
                }

            }
            else if (direction == "Up")
            {
                if (grid.GetComponent<GridScript>().playerX < 4)
                {
                    grid.GetComponent<GridScript>().playerX++;
                }
            }

            currentSpace.GetComponent<GridSpace>().setCamera(false);
            transitionStuff();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            playerInRange = true;
        }
    }

    public GameObject getCurrectSpace()
    {
        string currentCord = grid.GetComponent<GridScript>().playerX + "," + grid.GetComponent<GridScript>().playerY;
        GameObject currentSpace = grid.GetComponent<GridScript>().dictionary[currentCord];
        return currentSpace;
    }

    public void transitionStuff()
    {
        grid.GetComponent<GridScript>().ClearIndicators();
        string cord = grid.GetComponent<GridScript>().playerX + "," + grid.GetComponent<GridScript>().playerY;
        GameObject space = grid.GetComponent<GridScript>().dictionary[cord];
        space.GetComponent<GridSpace>().setIndicator(true);
        space.GetComponent<GridSpace>().setCamera(true);
        space.GetComponent<GridSpace>().spawnPlayer();
        playerInRange = false;
    }
}


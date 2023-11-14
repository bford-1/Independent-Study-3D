using System.Collections;
using System.Collections.Generic;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (direction == "Up")
            {
                if (grid.GetComponent<GridScript>().playerY < 4)
                {
                    grid.GetComponent<GridScript>().playerY++;
                }
                
            } 
            else if (direction == "Right")
            {
                if (grid.GetComponent<GridScript>().playerX < 4)
                {
                    grid.GetComponent<GridScript>().playerX++;
                }
            }

            grid.GetComponent<GridScript>().ClearIndicators();
            string cord = grid.GetComponent<GridScript>().playerX + "," + grid.GetComponent<GridScript>().playerY;
            GameObject space = grid.GetComponent<GridScript>().dictionary[cord];
            space.GetComponent<GridSpace>().setIndicator(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public string direction;
    public GameObject grid;
    public string upelse; 
    private bool playerInRange;
    public bool result;

    void Start()
    {
        playerInRange = false;

    }

    // Update is called once per frame
    public void Update()
    {

        int playx = grid.GetComponent<GridScript>().playerX;
        int playy = grid.GetComponent<GridScript>().playerY;
        string name1 = playx.ToString() + "," + playy.ToString();
        GameObject nameObj = GameObject.Find(name1);
        upelse = nameObj.GetComponent<GridSpace>().ifelse;
        GameObject currentSpace = getCurrectSpace();
        result = ExpressionEvaluator.Evaluate(upelse);
        Console.WriteLine(result); // Output: True
        if (/*Input.GetKeyDown(KeyCode.E) && */playerInRange)
        { 
            
        
            if (direction == "Right")
            {
                if (grid.GetComponent<GridScript>().playerY < 4)
                {
                    grid.GetComponent<GridScript>().playerY++;
                }
                
                if (grid.GetComponent<GridScript>().playerY == 4)
                {
                    SceneManager.LoadScene(3);
                }
                if (result == true)
                {
                    Debug.Log("hi");
                    SceneManager.LoadScene(0);
                }

            }
            else if (direction == "Up")
            {
                if (grid.GetComponent<GridScript>().playerX < 4)
                {
                    grid.GetComponent<GridScript>().playerX++;
                }
                
                if (grid.GetComponent<GridScript>().playerX == 4)
                {
                    SceneManager.LoadScene(3);
                }
                if (result == false)
                {
                    SceneManager.LoadScene(0);
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
public class ExpressionEvaluator
{
    public static bool Evaluate(string expression)
    {
        try
        {

            DataTable table = new DataTable();

            DataColumn column = new DataColumn("Expression", typeof(bool), expression);
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            table.Rows.Add(row);

            return (bool)row["Expression"];
        }
        catch (Exception ex)
        {

            Console.WriteLine("Error evaluating expression: " + ex.Message);
            return false; 
        }
    }
}


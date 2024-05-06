using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSpace : MonoBehaviour
{
    public int x_cord;
    public int y_cord;
    public GameObject Indicator;
    public GameObject Cam;
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject CRTDisplay;

    public int num1;
    public int num2;
    public string ifelse;
    private Vector3 originalPosition;
    public string nam;
    

    private bool active = false;

    void Start()
    {
        Indicator.SetActive(false);
        InvokeRepeating("FlashIndicator", 0, 0.7f);
        createnumber();
        ifelse = CreateExpressions();
        originalPosition = Cam.transform.position;
     

    }

    void FlashIndicator()
    {
        if (active)
        {
            if (Indicator.activeSelf)
            {
                Indicator.SetActive(false);
            }
            else
            {
                Indicator.SetActive(true);
            }
        }
        else
        {
            Indicator.SetActive(false);
        }
    }

    public void setIndicator(bool indicator)
    {
        active = indicator;
    }

    public void setCamera(bool cameraStatus)
    {
        Cam.SetActive(cameraStatus);
    }

    void createnumber()
    {
        int number1 = Random.Range(1, 101);
        int number2 = Random.Range(1, 101);
        num1 = number1;
        num2 = number2;
        int result = -1;
        string selectedOperator = "";
        int operatorIndex = Random.Range(1, 7);

    }
    public string CreateExpressions()
    {
        // List of comparison operators
        string[] operators = new string[] { "==", ">", "<", ">=", "<=" };
        string selectedOperator = operators[Random.Range(0, operators.Length)];
        string x = num1.ToString();
        string y = num2.ToString();
        string ifStatement =  x + "  " + selectedOperator + " "+ num2 ;
        return (ifStatement);
    }
    public void spawnPlayer()
    {
        Debug.Log("hello");
        Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newPosition = CRTDisplay.transform.position - Cam.transform.forward * 2f;
            Cam.transform.position = newPosition;
            Cam.transform.LookAt(CRTDisplay.transform);
        }
        else
        {
            Cam.transform.position = originalPosition;

        }

        
        
    }

    
}
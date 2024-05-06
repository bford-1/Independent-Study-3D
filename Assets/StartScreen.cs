using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class help : MonoBehaviour
{
    public TextMeshProUGUI titleText; // Reference to the TextMeshProUGUI object for the title text
    public TextMeshProUGUI startText; // Reference to the TextMeshProUGUI object for the start text

    public int isGameStarted; // Flag to keep track of whether the game has started

    void Update()
    {
        // Check if the player has pressed the start key and the game has not already started
    }
    public int GetDisplayValue()
    {
        return (isGameStarted);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        isGameStarted = 1;
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
        isGameStarted = 2;
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
        isGameStarted = 3;
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class StartScreen : MonoBehaviour
{
    public TextMeshProUGUI texty; // Reference to the TextMeshProUGUI object for the title text
    public GameObject[] buttons; // Array of buttons to hide/show
    private bool isGameStarted = false; // Flag to keep track of whether the game has started
    private int messageIndex = 0; // Index of the current message
    private string[] messages = {
            "Hello! Here are the rules to the Game! (Space to continue)",
            "",
            "An if else statement will appear on the left side of the screen (Space to continue)",
            "",
            "If it is true, go forward, if it is false, go right. (SPace to continue)",
            "",
            "If you get it wrong, game over! (Space to continue)",
            "",
            "Your goal is to get to the right most side of the map or the top most side! (Space to continue)",
            "",
            "There will be a minimap on the top right telling you where you are! Good luck! (Space to continue)",
            ""
            
        };

    void Update()
    {
        // Check if the player has pressed the start key and the game has not already started
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
        isGameStarted = true;
    }

    public void LoadLevel2()
    {
        StartCoroutine(DisplayTextAndHideButtons());
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
        isGameStarted = true;
    }
    IEnumerator DisplayTextAndHideButtons()
    {
        // Hide buttons
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

        // Display messages sequentially
        foreach (string message in messages)
        {
            texty.text = message;

            // Wait for the player to press space
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        // Clear the text
        texty.text = "";

        // Show buttons again
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }

        // Game has started
        isGameStarted = true;
    }

    void DisplayNextMessage()
    {
        messageIndex++;
        if (messageIndex >= 0 && messageIndex <= messages.Length)
        {
            texty.text = messages[messageIndex];
        }
        else
        {
            texty.text = "";
        }
    }
}
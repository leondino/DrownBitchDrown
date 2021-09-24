using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessage : MonoBehaviour
{
    [SerializeField, Header("StartMessage")]
    private string startMessage;

    [SerializeField, Header("TextObject")]
    private Text messageText;

    [SerializeField, Header("GameManager")]
    private GameManager gameManager;

    private bool UIOpen;
    private bool gameOver;

    // Start is called before the first frame update
    private void Awake()
    {
        StartGameUI();
    }

    public void StartGameUI()
    {
        UIOpen = true;
        ChangeUI(startMessage);
    }

    public void GameOverUI(string message)
    {
        ChangeUI(message);
        gameOver = true;
        gameManager.thePlayer.SetActive(false);
    }

    public void ResetGame()
    {
        if (gameOver)
        {
            gameOver = false;
            gameManager.ResetGame();
        }
    }

    public void ChangeUI(string message)
    {
        if (!gameOver)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "TimerBackground" && child.name != "ScoreBackground")
                {
                    child.gameObject.SetActive(UIOpen);
                }
            }

            if (UIOpen)
            {
                messageText.text = message;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            UIOpen = !UIOpen;
        }
    }
}

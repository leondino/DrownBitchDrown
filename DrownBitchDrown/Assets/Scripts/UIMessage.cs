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

    private bool UIOpen;

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

    public void ChangeUI(string message)
    {
        foreach (Transform child in transform)
        {
            if (child.name!= "TimerBackground")
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject startPosition;

    public static GameManager instance;

    [HideInInspector]
    public bool isHighTide;

    private float tideTimer;
    private int lowTideDuration = 5;
    private int highTideDuration = 7;

    private bool hasSecondChance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        ResetGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tideTimer += Time.deltaTime;
        // All code for high tide gameplay
        if (isHighTide)
        {
            // High tide timer
            if (tideTimer >= highTideDuration)
            {
                tideTimer = 0;
                // Check if player in correct field then switch tides.
                switch (thePlayer.tag)
                {
                    case "rood":
                        // Game over
                        Debug.Log("Game over");
                        ResetGame();
                        break;
                    case "geel":
                        // Get progression, but next time game over
                        if (hasSecondChance)
                        {
                            Debug.Log("Gele kaart!");
                            hasSecondChance = false;
                            SwitchTide();
                        }
                        else
                        {
                            Debug.Log("Game over");
                            ResetGame();
                        }
                        break;
                    case "groen":
                        // Get progression 
                        SwitchTide();
                        Debug.Log("Good Job!");
                        break;
                }
            }
        }

        // All code for low tide gameplay
        else
        {
            // Low tide timer
            if (tideTimer >= lowTideDuration)
            {
                tideTimer = 0;
                SwitchTide();
            }
        }
    }

    public void SwitchTide()
    {
        // All code for switching to low tide
        if (isHighTide)
        {
            thePlayer.SetActive(false);
            isHighTide = false;
        }

        // All code for switching to high tide
        else
        {
            isHighTide = true;
            thePlayer.SetActive(true);
            thePlayer.transform.position = startPosition.transform.position;
        }
    }

    private void ResetGame()
    {
        isHighTide = false;
        hasSecondChance = true;
        tideTimer = 0;
    }
}

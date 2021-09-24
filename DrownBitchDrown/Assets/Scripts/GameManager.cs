using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject startPosition;
    public TowerColor towers;
    public Material[] oceanMaterials;
    private WaterRandomizeScript waterRandomizer;

    public static GameManager instance;

    [HideInInspector]
    public bool isHighTide;
    
    [SerializeField, Header("UIMessages")]
    private string[] messages;

    [SerializeField, Header("UIMessages")]
    private UIMessage UIManager;

    [SerializeField, Header("Timer")]
    private Text timer;

    private float tideTimer;
    private int lowTideDuration = 5;
    private int highTideDuration = 7;

    private bool hasSecondChance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        waterRandomizer = gameObject.GetComponent<WaterRandomizeScript>();
        ResetGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tideTimer += Time.deltaTime;
        // All code for high tide gameplay
        if (isHighTide)
        {
            timer.text = "Time Left: " + Mathf.RoundToInt(highTideDuration-tideTimer).ToString();
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
                        UIManager.GameOverUI(messages[3]);
                        break;
                    case "geel":
                        // Get progression, but next time game over
                        if (hasSecondChance)
                        {
                            Debug.Log("Gele kaart!");
                            hasSecondChance = false;
                            UIManager.ChangeUI(messages[1]);
                            SwitchTide();
                        }
                        else
                        {
                            Debug.Log("Game over");
                            UIManager.GameOverUI(messages[2]);
                        }
                        break;
                    case "groen":
                        // Get progression 
                        SwitchTide();
                        UIManager.ChangeUI(messages[0]);
                        Debug.Log("Good Job!");
                        break;
                }
            }
        }

        // All code for low tide gameplay
        else
        {
            timer.text = "Time Left: "+Mathf.RoundToInt(lowTideDuration - tideTimer).ToString();
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
            SetElements();
            SetWaterMaterials();
        }

        // All code for switching to high tide
        else
        {
            isHighTide = true;
            thePlayer.SetActive(true);
            thePlayer.transform.position = startPosition.transform.position;
            SetWaterMaterials();
        }
    }

    public void ResetGame()
    {
        isHighTide = false;
        hasSecondChance = true;
        tideTimer = 0;
        SetElements();
        SetWaterMaterials();
        UIManager.StartGameUI();
    }

    private void SetElements()
    {
        waterRandomizer.Swap();
        for (int iSection = 0; iSection < waterRandomizer.sectionsList.Length; iSection++)
        {
            towers.ChangeTower(waterRandomizer.sectionsList[iSection].tag, iSection);
        }
    }

    private void SetWaterMaterials()
    {
        foreach (GameObject section in waterRandomizer.sectionsList)
        {
            Material waterMaterial = null;
            if (!isHighTide)
            {
                switch (section.tag)
                {
                    case "groen":
                        waterMaterial = oceanMaterials[0];
                        break;

                    case "geel":
                        waterMaterial = oceanMaterials[1];
                        break;

                    case "rood":
                        waterMaterial = oceanMaterials[2];
                        break;

                    default:
                        break;
                }
            }
            else
            {
                switch (section.tag)
                {
                    case "groen":
                        waterMaterial = oceanMaterials[3];
                        break;

                    case "geel":
                        waterMaterial = oceanMaterials[4];
                        break;

                    case "rood":
                        waterMaterial = oceanMaterials[5];
                        break;

                    default:
                        break;
                }
            }
            section.GetComponent<Renderer>().material = waterMaterial;
        }
    }
}

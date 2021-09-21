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

    private float tideTimer = 0;
    private int lowTideDuration = 5;
    private int highTideDuration = 7;

    // Start is called before the first frame update
    void Start()
    {
        isHighTide = false;
        instance = this;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject startPosition;
    public bool isHighTide;
    // Start is called before the first frame update
    void Start()
    {
        isHighTide = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // All code for high tide gameplay
        if (isHighTide)
        {

        }

        // All code for low tide gameplay
        else
        {

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

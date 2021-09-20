using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerColor : MonoBehaviour
{
    List<Transform> towers= new List<Transform>();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            towers.Add(child);
        }
    }

    public void ChangeTower(string tag, int section)
    {
        switch (tag)
        {
            case "rood":
                ChangeColor(section, new Color(1, 0, 0));
                break;

            case "geel":
                ChangeColor(section, new Color(1, 1, 0));
                break;

            case "groen":
                ChangeColor(section, new Color(0, 1, 0));
                break;
        }
    }

    private void ChangeColor(int section, Color color)
    {
        towers[section].GetComponent<MeshRenderer>().material.color = color;
    }
}

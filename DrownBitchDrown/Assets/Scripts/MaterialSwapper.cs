using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    public Transform parent;

    List<Transform> objectstoColor;

    void Start()
    {
        objectstoColor = new List<Transform>();

        foreach (Transform item in parent)
        {
            objectstoColor.Add(item);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }
    }

    private void Swap()
    {
        SwitchColors();
    }

    //<summary>Method for changing the material color</summary>//
    public void SwitchColors()
    {
        foreach (Transform item in objectstoColor)
        {
            Renderer rend = item.gameObject.GetComponent<Renderer>();
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}

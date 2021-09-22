using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRandomizeScript : MonoBehaviour
{
    [Header("Sections")]
    [SerializeField]
    private GameObject[] sectionsList;

    [SerializeField]
    private Material[] waterMaterials;

    private int[] sectionType;

    Material finalMat;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<GameObject>();
        sectionType = new int[sectionsList.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }
    }

    private void Swap()
    {
        SwapWaterPrefabs(sectionsList);
    }

    private void SwapWaterPrefabs(GameObject[] sections)
    {
        Debug.Log("Click");

        for (int i = 0; i < sectionType.Length; i++)
        {
            sectionType[i] = 0;
        }

        int randomSection = Random.Range(0, sections.Length);

        sectionType[randomSection] = 1; //rood

        if (randomSection > 0)
        {
            sectionType[randomSection - 1] = 2; //geel
        }
        if (randomSection < 3)
        {
            sectionType[randomSection + 1] = 2; //geel
        }

        for (int i = 0; i < sectionType.Length; i++)
        {
            if (sectionType[i] == 0)
            {
                sectionType[i] = 3; //groen
            }

            Debug.Log("Number is = " + sectionType[i]);
        }

        for (int i = 0; i < sectionsList.Length; i++)
        {
            switch (sectionType[i])
            {
                case 1: sections[i].tag = "rood";
                    break;

                case 2: sections[i].tag = "geel";
                    break;

                case 3: sections[i].tag = "groen";
                    break;

                default:
                    break;
            }
        }
    }
}

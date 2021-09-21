using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRandomizeScript : MonoBehaviour
{
    [Header("Sections")]
    [SerializeField]
    private GameObject[] sectionsList;

    [Header("Sea Types")]
    [SerializeField]
    private GameObject[] waterPrefabList;

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SwapWaterPrefabs()
    {
        for (int i = 0; i < sectionsList.Length; i++)
        {
            foreach (GameObject waterPrefab in waterPrefabList)
            {

            }
        }
    }
}

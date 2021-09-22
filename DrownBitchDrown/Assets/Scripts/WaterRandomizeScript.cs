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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }
    }

    private void Swap()
    {
        SwapWaterPrefabs(waterPrefabList);
    }

    private void SwapWaterPrefabs(GameObject[] prefabs)
    {
        for (int i = 0; i < sectionsList.Length; i++)
        {
            // Find a random index
            int destIndex = Random.Range(0, prefabs.Length);
            GameObject source = prefabs[i];
            GameObject dest = prefabs[destIndex];

            // If is not identical
            if (source != dest)
            {

                // Swap the position
                source.transform.position = dest.transform.position;

                // Swap the array item
                prefabs[i] = prefabs[destIndex];
            }
        }
    }
}

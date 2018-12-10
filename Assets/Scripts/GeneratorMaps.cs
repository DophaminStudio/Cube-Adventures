using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMaps : MonoBehaviour
{
    public GameObject map;
    public GameObject[] prefabs;
    public GameObject road;
    public float radius;
    GameObject mapItem;
    Vector3 halpblala;
    // Use this for initialization
    void Start()
    {
        GenerateMap(20);
        halpblala = new Vector3(20, 20, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateMap(int count)
    {
        for (int i = 0; i < prefabs.Length; i++)
        {

            for (int j = 0; j < count; j++)
            {
                Vector3 rndTransform = new Vector3(Random.Range(0, map.transform.localScale.x), 0, Random.Range(0, map.transform.localScale.z));
                mapItem = Instantiate(prefabs[i], rndTransform, Quaternion.identity) as GameObject;
                if ((Physics.OverlapBox(road.transform.localScale, mapItem.transform.position).Length > 0))
                {
                    DestroyImmediate(mapItem);
                    count++;
                }
            }
        }
    }
}



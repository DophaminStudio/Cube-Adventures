using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorMaps : MonoBehaviour
{
    public GameObject map;
    public GameObject[] prefabs;
    public GameObject road;
    public float radius;
    public GameObject parentSpawn;
    GameObject mapItem;
    Vector3 halpblala;
    int mapHeight = 500;
    int mapWidth = 500;
    // Use this for initialization
    void Start()
    {
        GenerateMap(40);
        halpblala = new Vector3(500, 500, 0);
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
                RaycastHit hit;

                Vector3 rndTransform = new Vector3(Random.Range(0, mapWidth), 0, Random.Range(0, mapHeight));
                
                mapItem = Instantiate(prefabs[i], rndTransform, Quaternion.identity) as GameObject;
                mapItem.transform.parent = parentSpawn.transform;
            }
        }
    }
}



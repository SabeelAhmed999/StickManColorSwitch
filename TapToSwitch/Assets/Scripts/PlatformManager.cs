using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private Transform playerTransform;

    private float spawnZ = 0.0f;
    public float platformLenghtZ = 10f;
    public int amountOfPlatform = 5;


    // Start is called before the first frame update
    void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amountOfPlatform; i++)
        {
            SpawnPlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z>(spawnZ-amountOfPlatform*platformLenghtZ))
        {
            SpawnPlatform();
        }
    }
    private void SpawnPlatform(int prefabIndex=-1)
    {
        GameObject go;
        int item = Random.Range(0, platformPrefabs.Length - 1);
        go = Instantiate(platformPrefabs[item]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += platformLenghtZ;
    }
}

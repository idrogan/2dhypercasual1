using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;
    public GameObject tenPointObj, fiftyPointObj, deathObj, halfSpeedDecreaseObj;
    public GameObject randObj;
    float randX;
    Vector2 whereToSpawn;
    [SerializeField]
    float spawnRate = 1f;
    float nextSpawn = 0.0f;

    void Start()
    {
        objects = new GameObject[4];
        objects[0] = tenPointObj;
        objects[1] = fiftyPointObj;
        objects[2] = deathObj;
        objects[3] = halfSpeedDecreaseObj;
    }

    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-5.6f, 5.6f);
            randObj = objects[Random.Range(0, objects.Length)];
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(randObj, whereToSpawn, Quaternion.identity);
        }
    }
}

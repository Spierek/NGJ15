using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    public Obstacle[] obstacles;

    [Range(0,10)]
    public int[] spawnRate;

    void Awake()
    {
        instance = this;
        if (spawnRate.Length != obstacles.Length)
        {
            MainDebug.WriteLine("SpawnManager warning - size of obstacles table differs with size of spawnRate table. Nulls will happen ;/ ");  
        }
         
    }

    public static void SpawnObstacle(Transform t)
    {
        List<Obstacle> pool = new List<Obstacle>();
        for (int x = 0; x < instance.obstacles.Length; x++)
        {
            for (int i = 0; i < instance.spawnRate[x]; i++)
                pool.Add(instance.obstacles[x]);
        }
        Obstacle obs = Instantiate(pool[Random.Range(0, pool.Count)]) as Obstacle;
        obs.gameObject.transform.parent = t;
        obs.SpawnMe(t);
    }

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}

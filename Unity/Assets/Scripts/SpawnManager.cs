using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    public Obstacle[] obstacles;

    [Range(0,100)]
    public int[] spawnRate;

    void Awake()
    {
        instance = this;
    }

    public static void SpawnObstacle(Transform t)
    {
        Obstacle obs = Instantiate(instance.obstacles[Random.Range(0, instance.obstacles.Length)]) as Obstacle;
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

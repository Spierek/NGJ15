using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    public GameObject[] obstacles;

    void Awake()
    {
        instance = this;
    }

    public static void SpawnObstacle(Transform t)
    {
        string ObjectName = "Spawner" + UnityEngine.Random.Range(1, 3).ToString();
        Debug.Log(ObjectName);
        Transform childT = t.FindChild(ObjectName);
        GameObject obs = Instantiate(instance.obstacles[UnityEngine.Random.Range(0, instance.obstacles.Length)], childT.position, Quaternion.identity) as GameObject;
        obs.transform.parent = t;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

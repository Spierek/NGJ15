using UnityEngine;
using System.Collections;

public class CarForward : Obstacle {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();

        this.transform.position += Vector3.forward * speed;

	}

    public override void SpawnMe(Transform parent)
    {
        string ObjectName = "Spawner1";
        Transform childT = parent.FindChild(ObjectName);
        this.transform.position = childT.position;
       // GameObject obs = Instantiate(instance.obstacles[Random.Range(0, instance.obstacles.Length)], childT.position, Quaternion.identity) as GameObject;
       // obs.transform.parent = t;
    }
}

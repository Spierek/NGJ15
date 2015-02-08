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
        if (!isKill)
        {
            this.transform.position += Vector3.forward * speed;
        }
        else
        {
            this.transform.Rotate(Vector3.forward, 10f);
            this.transform.position += new Vector3(0.1f, 0.25f, 0.75f);
        }
	}

    public override void SpawnMe(Transform parent)
    {
        string ObjectName = "Spawner1";
        Transform childT = parent.FindChild(ObjectName);
        this.transform.position = childT.position;
        base.SpawnMe(parent);
       // GameObject obs = Instantiate(instance.obstacles[Random.Range(0, instance.obstacles.Length)], childT.position, Quaternion.identity) as GameObject;
       // obs.transform.parent = t;
    }

    public override void KillMe()
    {
        base.KillMe();
        Audio.Instance.PlayBumpGlass();
    }
}

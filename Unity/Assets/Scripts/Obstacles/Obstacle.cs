using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public float deathTimer;
    protected bool isKill;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0) Destroy(this.gameObject);
	}

    public virtual void SpawnMe(Transform parent){

    }

    public virtual void KillMe()
    {
        isKill = true;
    }
}

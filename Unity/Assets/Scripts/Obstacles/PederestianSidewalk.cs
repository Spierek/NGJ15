using UnityEngine;
using System.Collections;

public class PederestianSidewalk : Obstacle
{

    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (isKill)        
        {
            this.transform.Rotate(Vector3.forward, 10f);
            this.transform.position += new Vector3(0.1f, 0.25f, 0.75f);
        }
    }

    public override void SpawnMe(Transform parent)
    {
        int spawnerFrm = UnityEngine.Random.Range(1, 3);
        string ObjectName = "SpawnerSide"+spawnerFrm;
        Transform childT = parent.FindChild(ObjectName);
        this.GetComponent<SpriteRenderer>().sprite = SpawnManager.instance.pederestiansSprites[UnityEngine.Random.Range(0, SpawnManager.instance.pederestiansSprites.Length)];
        this.transform.position = childT.position;
        base.SpawnMe(parent);
    }
    public override void KillMe()
    {
        base.KillMe();
        Audio.Instance.PlayHumanHit();
    }
}

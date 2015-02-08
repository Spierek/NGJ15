using UnityEngine;
using System.Collections;

public class PederestianCross : Obstacle
{

    public float speed;
    public bool goingLeft;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (!isKill)
        {
            this.transform.position += (goingLeft ? Vector3.left : Vector3.right) * speed;
        }
        else
        {
            this.transform.Rotate(Vector3.forward, 10f);
            this.transform.position += new Vector3(0.1f, 0.25f, 0.75f);
        }
    }

    public override void SpawnMe(Transform parent)
    {
        int spawnerFrm = UnityEngine.Random.Range(1, 3);
        if (spawnerFrm == 2) goingLeft = true;
        else goingLeft = false;
        string ObjectName = "SpawnerSide"+spawnerFrm;
        Transform childT = parent.FindChild(ObjectName);
        this.transform.position = childT.position;
    }
    public override void KillMe()
    {
        base.KillMe();
        Audio.Instance.PlayHumanHit();
    }
}

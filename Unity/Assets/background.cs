using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float speed;

    private Transform[] childs;

    void Awake()
    {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++ )
        {
            childs[i] = transform.GetChild(i);
            childs[i].localPosition = new Vector3(0f, 10f * i, 0f);
        }
    }
  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].localPosition -= transform.up * speed * Time.deltaTime;
            if (childs[i].localPosition.y <= -10f) childs[i].localPosition += new Vector3(0f, 10f * childs.Length, 0f);
        }
          
	}
}

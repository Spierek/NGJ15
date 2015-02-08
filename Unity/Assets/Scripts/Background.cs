using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float speed;
    private float sectionLength = 30f;

    public List<GameObject> roadPrefabs;
    private List<GameObject> sections = new List<GameObject>();

    void Awake() {
        if (roadPrefabs.Count > 0) {
            for (int i = 0; i < 6; i++) {
                Debug.Log(Random.Range(0, roadPrefabs.Count));
                sections.Add(Instantiate(roadPrefabs[Random.Range(0, roadPrefabs.Count)]) as GameObject);
                sections[i].transform.localPosition = new Vector3(0f, 0f, sectionLength * i);
                sections[i].transform.parent = transform;
            }
        }
        else {
            Debug.LogWarning("No road prefabs found!");
        }
    }
  
    void Update () {
        for (int i = 0; i < sections.Count;i++)
        {
            GameObject s = sections[i];
            s.transform.localPosition -= transform.forward * speed * Time.deltaTime;
            if (s.transform.localPosition.z <= -sectionLength)
            {
                GameObject newS = Instantiate(roadPrefabs[UnityEngine.Random.Range(0, roadPrefabs.Count)], s.transform.position, Quaternion.identity) as GameObject;
                newS.transform.parent = s.transform.parent;
                newS.transform.localPosition += new Vector3(0f, 0f, sectionLength * sections.Count);
               // 
                if (UnityEngine.Random.Range(0, 100) >= 10)
                {
                    SpawnManager.SpawnObstacle(newS.transform);
                }
                Destroy(s.gameObject);
                sections[i] = newS;
            }
        }
    }
}

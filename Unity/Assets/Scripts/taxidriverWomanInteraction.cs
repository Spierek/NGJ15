using UnityEngine;
using System.Collections;

public class taxidriverWomanInteraction : MonoBehaviour {

	//public var woman = GameObject.Find ("Woman").GetComponent<Cube>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var woman = GameObject.Find ("Woman");

		if (Input.GetKey(KeyCode.A))
			woman.renderer.material.color = Color.red;

		if (Input.GetKey(KeyCode.S))
		    woman.renderer.material.color = Color.blue;

		if (Input.GetKey(KeyCode.D))
		    woman.renderer.material.color = Color.green;
		
	}
}

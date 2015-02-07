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

		if (Input.GetKeyDown(KeyCode.Q))
			Audio.Instance.PlayManSayingBreathe();
		if (Input.GetKeyDown(KeyCode.W))
			Audio.Instance.PlayManSayingCalmDown();
		if (Input.GetKeyDown(KeyCode.E))
			Audio.Instance.PlayWomanBreathing();
		if (Input.GetKeyDown(KeyCode.R))
			Audio.Instance.PlayWomanSayingShutup();
		if (Input.GetKeyDown(KeyCode.T))
			Audio.Instance.PlayWomanScreaming();
		if (Input.GetKeyDown(KeyCode.Y))
			Audio.Instance.PlayHumanHit();
		if (Input.GetKeyDown(KeyCode.U))
			Audio.Instance.PlayBabyShort();
		if (Input.GetKeyDown(KeyCode.I))
			Audio.Instance.PlayTires();
		
	}
}

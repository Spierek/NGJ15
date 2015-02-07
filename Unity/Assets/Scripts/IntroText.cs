using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {

	//public Text introText;

	// Use this for initialization
	void Start () {

		var introGameText = GameObject.Find ("IntroGameText").GetComponent<Text>();
		introGameText.text = "Make A Baby Pop";
	}
	
	// Update is called once per frame
	void Update () {
		//introText.text = "Awesome text";
	}
}

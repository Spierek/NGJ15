using UnityEngine;
using System.Collections;

public class BabySoundController : MonoBehaviour {


	static bool playing;

	void Start () {
		
		var audio = gameObject.GetComponent<AudioSource>();
		if(!playing)
		{
			playing = true;
			audio.Play();
		}
	}
}

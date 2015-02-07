using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	static Audio m_Instance;
	static Audio Instance {get{ 
			if(m_Instance == null)
			{
				m_Instance = GameObject.Find("Audio").GetComponent<Audio>();
			}
			return m_Instance;
		}}

	public AudioSource Bump;
	public AudioSource Driving;
	public AudioSource HumanHit1;
	public AudioSource HumanHit2;
	public AudioSource HumanHit3;
	public AudioSource Tires;

	void PlayBump()
	{
		Bump.Play();
	}
	
	void PlayDriving()
	{
		Driving.Play();
	}

	void PlayTires()
	{
		Tires.Play();
	}

	void PlayHumanHit()
	{
		var i = Random.Range(0,2);

		switch(i)
		{
		case 1:
			HumanHit1.Play();
			break;
		case 2: 
			HumanHit2.Play();
			break;
		case 3: 
			HumanHit3.Play();
			break;
		}
	}
}

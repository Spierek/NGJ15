using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

	static Audio m_Instance;
	public static Audio Instance {get{ 
			if(m_Instance == null)
			{
				m_Instance = GameObject.Find("Audio").GetComponent<Audio>();
			}
			return m_Instance;
		}}

	public AudioSource Bump;
	public AudioSource BumpGlass;
	public AudioSource Driving;
	public AudioSource HumanHit1;
	public AudioSource HumanHit2;
	public AudioSource HumanHit3;
	public AudioSource Tires;
	public AudioSource Baby1;
	public AudioSource Baby2;
	public AudioSource BabyShort;
	public AudioSource Breathe;
	public AudioSource Breathe2;
	public AudioSource HeavyBreathing;
	public AudioSource CalmDown;
	public AudioSource CalmDown2;
	public AudioSource Background;
	
	public AudioSource Scream1;
	public AudioSource Scream2;
	public AudioSource Scream3;
	public AudioSource Scream4;
	public AudioSource Shutup1;
	public AudioSource Shutup2;
	public AudioSource Shutup3;
	public AudioSource TakeItEasy;

	public void PlayWomanSayingShutup()
	{
		switch(Random.Range(1,3))
		{
		case 1:
			Shutup1.Play();
			break;
		case 2: 
			Shutup2.Play();
			break;
		case 3: 
			Shutup3.Play();
                break;
        }
    }

	public void PlayWomanFinalScream()
    {
        Scream4.Play ();
    }
    
	public void PlayWomanScreaming()
    {
        switch(Random.Range(1,3))
        {
		case 1:
			Scream1.Play();
			break;
		case 2: 
			Scream2.Play();
                break;
            case 3: 
                Scream3.Play();
                break;
        }
    }

	public void PlayManSayingCalmDown()
	{
		switch(Random.Range(1,3))
		{
		case 1:
			CalmDown.Play();
			break;
		case 2: 
			CalmDown2.Play();
			break;
		case 3: 
			TakeItEasy.Play();
			break;
        }
    }
    
	public void PlayWomanBreathing()
    {
		HeavyBreathing.Play();
	}
	public void PlayManSayingBreathe()
	{
		switch(Random.Range(1,2))
		{
		case 1:
			Breathe.Play();
			break;
		case 2: 
			Breathe2.Play();
                break;
        }
    }

	public void PlayBabyLong()
	{
		Baby1.Play();
    }
	
	public void PlayBabyShort()
	{
		BabyShort.Play();
	}
	
	public void PlayBump()
	{
		Bump.Play();
	}
	
	public void PlayBumpGlass()
	{
		BumpGlass.Play();
	}

	public void PlayBackground()
	{
		Background.Play();
	}

	public void PlayDriving()
	{
		Driving.Play();
	}

	public void PlayTires()
	{
		Tires.Play();
	}

	public void PlayHumanHit()
	{
		switch(Random.Range(1,3))
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

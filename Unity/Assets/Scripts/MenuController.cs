using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {


	public GameObject Screen1;
	public GameObject Screen2;
	public GameObject Screen3;
	public GameObject Screen4;
	
	// Use this for initialization
	void Start () {
		Screen1.SetActive(true);
		Screen2.SetActive(false);
		Screen3.SetActive(false);
		Screen4.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//if(anyButtonPressed)

			if(Screen1.activeInHierarchy)
			{
				Screen1.SetActive(false);
				Screen2.SetActive(true);
			}else

			if(Screen2.activeInHierarchy)
			{
				Screen2.SetActive(false);
				Screen3.SetActive(true);
			}else

			if(Screen3.activeInHierarchy)
			{
				Screen3.SetActive(false);
				Screen4.SetActive(true);
			}else

			if(Screen4.activeInHierarchy)
			{
				Application.LoadLevel(1);
			}
		}

	}
}

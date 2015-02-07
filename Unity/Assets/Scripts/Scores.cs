using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

	static Scores m_Instance;
	static Scores Instance {get{ 
			if(m_Instance == null)
			{
				m_Instance = GameObject.Find("Scores").GetComponent<Scores>();
			}
			return m_Instance;
		}}

	public ParticleEmitter particleEmmiter;
	public Text textObj;
	
	private int score;

	
	private static readonly int MAX_STRESS = 100;
	private int stress;
	public RectTransform stressTransform;
	public RectTransform stressTransformBackground;

	public void Update()
	{
		//Debug.Log();
		if(Time.frameCount % 90 == 0 )
		{
			AddPoints(1);
			AddStress(1);
		}
	}


	static void AddStress(int stress)
	{
		Instance.stress += stress;

		if(Instance.stress > MAX_STRESS)
			Instance.stress = MAX_STRESS;

		DrawStress();
		
		//Instance.particleEmmiter.gameObject.transform.position = Camera.main.ScreenToViewportPoint(Instance.textObj.rectTransform.position);
		//Instance.particleEmmiter.Emit();
	}

	static void DrawStress()
	{
		var aspect = Instance.stress/(float)MAX_STRESS;
		var backgroundScale = Instance.stressTransformBackground.transform.localScale;
		var scaled = new Vector3(backgroundScale.x,Instance.stressTransform.transform.localScale.y / backgroundScale.y,backgroundScale.z);
		scaled = new Vector3(backgroundScale.x,aspect,backgroundScale.z);


		Instance.stressTransform.localScale = scaled;
	}

	static void AddPoints(int points)
	{
		Instance.score += points;
		Instance.textObj.text = Instance.score.ToString();

		Instance.particleEmmiter.transform.position = Camera.main.ScreenToWorldPoint(Instance.textObj.rectTransform.anchoredPosition);
		Instance.particleEmmiter.Emit();
	}


}

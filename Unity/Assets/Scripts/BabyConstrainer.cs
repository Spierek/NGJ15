using UnityEngine;

public class BabyConstrainer : MonoBehaviour {
	#region Variables
	#endregion

	#region Monobehaviour Methods
	void Awake () {
	
	}

	void Update () {
	    transform.localRotation = Quaternion.Euler(30, 0, transform.localEulerAngles.z);
	}
	#endregion

	#region Methods
	#endregion
}

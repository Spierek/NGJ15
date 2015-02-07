using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    #region Variables
    public static UIManager Instance;

    public Text     distanceCounter;
    public Slider   stressBar;
    #endregion

    #region Monobehaviour Methods
    void Awake () {
        Instance = this;
    }

    void Update () {
    
    }
    #endregion

    #region Methods
    public void SetDistance(float value) {
        distanceCounter.text = Mathf.Round(value) + "m";
    }

    public void SetStress(float value) {
        stressBar.value = value;
    }
    #endregion
}

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    #region Variables
    public static UIManager Instance;

    public Text     distanceCounter;
    public Slider   stressBar;
    public Image    fade;

    private float   fadeSpeed = 2f;
    private float   fadeTarget;
    #endregion

    #region Monobehaviour Methods
    void Awake () {
        Instance = this;
        fade.color = new Color(1,1,1,1);
        fadeTarget = 0;
    }

    void Update () {
        FadeScreen();
    }
    #endregion

    #region Methods
    public void SetDistance(float value) {
        distanceCounter.text = Mathf.Round(value) + "m";
    }

    public void SetStress(float value) {
        stressBar.value = value;
    }

    public void SetFadeTarget(float target) {
        fadeTarget = target;
    }

    private void FadeScreen() {
        Debug.Log(fade.color.a);
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a + (fadeTarget - fade.color.a) * Time.deltaTime * fadeSpeed);
    }
    #endregion
}

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    #region Variables
    public static UIManager Instance;

    public Text     distanceCounter;
    public Image    heart;
    public Image    fade;

    private float   heartSpeed;
    private float   heartValue;
    private Vector2 heartScale = new Vector2(0.8f, 1.1f);
    public Color    heartTargetColor;

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
        BeatingHeart();
    }
    #endregion

    #region Methods
    public void SetDistance(float value) {
        distanceCounter.text = Mathf.Round(value) + "m";
    }

    public void SetStress(float value) {
        heartSpeed = value;
        heart.color = Color.Lerp(Color.white, heartTargetColor, value / 100);
    }

    public void SetFadeTarget(float target) {
        fadeTarget = target;
    }

    public void FlashWhite() {
        SetFadeTarget(1);
        fadeSpeed = 50f;
        Invoke("BackFromFlash", 0.1f);
    }

    private void BackFromFlash() {
        fadeSpeed = 20f;
        SetFadeTarget(0);
        Invoke("BackFromFlashRe", 0.2f);
    }

    private void BackFromFlashRe() {
        fadeSpeed = 2f;
    }

    private void BeatingHeart() {
        heartValue = Mathf.Sin(Time.time * heartSpeed / 5);
        heartValue = Remap(heartValue, -1, 1, heartScale.x, heartScale.y);
        heart.rectTransform.localScale = new Vector3(heartValue, heartValue, 1);
    }

    private void FadeScreen() {
        Debug.Log(fade.color.a);
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a + (fadeTarget - fade.color.a) * Time.deltaTime * fadeSpeed);
    }

    private float Remap (float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
    #endregion
}

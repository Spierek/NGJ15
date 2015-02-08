using UnityEngine;

public class CarScript : MonoBehaviour {
    #region Variables
    public Transform        wheel;
    public Transform        lady;
    private Animator        ladyAnimator;
    private Vector3         carLastPosition;

    public float distance = 600f;
    public float timeLimit = 90f;
    private float timeLeft;

    public float horizontalLimit = 9f;
    public float wheelRotationSpeed = 9f;
    public float wheelRotationLimit = 65f;

    [Range(0, 10)] public float carStress = 10f;
    [Range(0, 10)] public float pedestrianStress = 5f;
    [Range(0, 10)] public float wallStress = 2f;
    [Range(0, 10)] public float tumbleStress = 0.5f;

    private float stress;
    private float maxStress = 100f;

    private float calm = 5f;
    private float shootCooldown = 1f;    // Wait time between shots
    private float shootTimer;

    private float initialScreamDelay = 4f;
    private float screamDelay;
    private float screamTimer;

    private float shakePower;
    private float shakeDuration;

    private new Rigidbody   rigidbody;
    private Transform       cameraBox;
    #endregion

    #region Monobehaviour Methods
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
        cameraBox = transform.Find("Camera Box");
        timeLeft = timeLimit;
        Audio.Instance.PlayDriving();

        ladyAnimator = lady.GetComponent<Animator>();
        carLastPosition = transform.localPosition;
    }

    void Update () {
        RotateWheel();
        CameraShaking();
        UpdateDistance();
        CalmDown (calm);

        LadyNoises();

        stress += Time.deltaTime * 0.2f;
    }

    void FixedUpdate() {
        Movement();
    }

    private void OnTriggerEnter(Collider col) {
        col.GetComponent<Obstacle>().KillMe();
        TakeDamage(col.GetComponent<Obstacle>().damage);
        ShakeCamera(0.3f, 5f);
    }
    #endregion

    #region Methods
    private void Movement() {
        // get input and add force
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidbody.AddForce(movementVector * 1000, ForceMode.Impulse);

        // bounce off of walls (distance clamping)
        if ((transform.position.x < -horizontalLimit && rigidbody.velocity.x < 0) || (transform.position.x > horizontalLimit && rigidbody.velocity.x > 0)) {
            rigidbody.velocity = -1.5f * rigidbody.velocity;
            TakeDamage(wallStress);
            ShakeCamera(0.1f, 3f);
            Audio.Instance.PlayBump();
            Audio.Instance.PlayBumpGlass();
        }

        // lady position fix (pseudo-friction)
        lady.localPosition += (carLastPosition - transform.localPosition) * 0.1f;
        lady.localPosition = new Vector3(Mathf.Clamp(lady.localPosition.x, -3f, 3f), lady.localPosition.y, lady.localPosition.z);

        carLastPosition = transform.localPosition;

        // sidewalk stuff
        if ((transform.position.x < -6.5f) || (transform.position.x > 6.5f)) {
            TakeDamage(Time.deltaTime * 0.2f);
            ShakeCamera(0.1f, 0.5f);
        }
    }

    private void RotateWheel() {
        wheel.Rotate(0, 0, -Input.GetAxis("Horizontal") * wheelRotationSpeed);
        if (wheel.localEulerAngles.z > 0 && wheel.localEulerAngles.z < 90) {
            wheel.localRotation = Quaternion.Euler(0, 0, ClampAngle(wheel.localEulerAngles.z * 0.95f, -wheelRotationLimit, wheelRotationLimit));
        }
        else if (wheel.localEulerAngles.z < 360 && wheel.localEulerAngles.z > 190) {
            wheel.localRotation = Quaternion.Euler(0, 0, ClampAngle(wheel.localEulerAngles.z + (360 - wheel.localEulerAngles.z) / 30, -wheelRotationLimit, wheelRotationLimit));
        }
    }

    public void ShakeCamera(float duration, float power) {
        shakeDuration = duration;
        shakePower = power;
    }

    private void CameraShaking() {
        if (shakeDuration > 0) {
            cameraBox.localPosition = Random.insideUnitCircle.normalized * shakeDuration * shakePower;
            shakeDuration -= Time.deltaTime;
        }
        else {
            cameraBox.localPosition = Vector3.zero;
        }
    }

    public void TakeDamage(float damage) {
        stress += damage;
        UIManager.Instance.SetStress(stress);

        // game over
        if (stress >= maxStress) {
            stress = 100;
            MainDebug.WriteLine("GAME OVER", 5f);
        }

        // animation switch
        if (stress > maxStress / 2) {
            ladyAnimator.SetTrigger("HighStress");
        }
    }

    private void LadyNoises() {
        if (!Audio.Instance.IsSayingShutUp()) {
            screamTimer += Time.deltaTime;

            screamDelay = initialScreamDelay * (1.5f - stress / maxStress);
            if (screamTimer > screamDelay) {
                screamTimer = 0;
                Audio.Instance.PlayWomanScreaming();
                Audio.Instance.HeavyBreathing.Stop();
            }
            else if (!Audio.Instance.HeavyBreathing.isPlaying && Audio.Instance.IsNotScreaming()) {
                Audio.Instance.PlayWomanBreathing();
            }
        }
        else {
            Audio.Instance.StopScreamingBreathing();
        }
    }

    private void CalmDown(float calming) {
        //add so that you can't spam the button, and make the woman irritated when you calm her too often
        shootTimer += Time.deltaTime;       // Keep track of passing time

        if (Input.GetKeyDown (KeyCode.Space)) {
            if (!Audio.Instance.IsSayingBreathe() )
                Audio.Instance.PlayManSayingBreathe();

            if (shootTimer < shootCooldown && !Audio.Instance.IsSayingShutUp()) {
                Invoke("ShutTheFuckUp", 0.2f);
                shootTimer = 0;
                return;                         // You can not calm her down yet
            }

            if (shootTimer > shootCooldown) {
                shootTimer = 0;
                stress -= calming;
                UIManager.Instance.SetStress(stress);
            }
        }

        // stress shouldn't be allowed to be negative
        if (stress <= 0) {
            stress = 0;
        }
    }

    private void ShutTheFuckUp() {
        Audio.Instance.StopScreamingBreathing();
        Audio.Instance.PlayWomanSayingShutup();
        TakeDamage(3f);
    }

    private void UpdateDistance() {
        timeLeft -= Time.deltaTime;
        UIManager.Instance.SetDistance(timeLeft / timeLimit * distance);

        if (timeLeft <= 0) {
            timeLeft = 0;
            MainDebug.WriteLine("YOU WIN");
        }
    }

    // from http://answers.unity3d.com/questions/141775/limit-local-rotation.html
    private float ClampAngle(float angle, float min, float max) {
     if (angle<90 || angle>270){       // if angle in the critic region...
         if (angle>180) angle -= 360;  // convert all angles to -180..+180
         if (max>180) max -= 360;
         if (min>180) min -= 360;
     }    
     angle = Mathf.Clamp(angle, min, max);
     if (angle<0) angle += 360;  // if angle negative, convert to 0..360
     return angle;
 }
    #endregion
}

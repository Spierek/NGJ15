using UnityEngine;

public class CarScript : MonoBehaviour {
    #region Variables
    public Transform        wheel;
    
    public float distanceLimit = 5f;
    public float wheelRotationSpeed = 7f;
    public float wheelRotationLimit = 60f;

    private float shakePower;
    private float shakeDuration;

    private new Rigidbody   rigidbody;
    private Transform       cameraBox;
    #endregion

    #region Monobehaviour Methods
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
        cameraBox = transform.Find("Camera Box");
    }

    void Update () {
        RotateWheel();
        CameraShaking();
    }

    void FixedUpdate() {
        Movement();
    }
    #endregion

    #region Methods
    private void Movement() {
        // get input and add force
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidbody.AddForce(movementVector * 1, ForceMode.Impulse);

        // bounce off of walls (distance clamping)
        if ((transform.position.x < -distanceLimit && rigidbody.velocity.x < 0) || (transform.position.x > distanceLimit && rigidbody.velocity.x > 0)) {
            rigidbody.velocity = -2 * rigidbody.velocity;
            ShakeCamera(0.1f, 2f);
        }
    }

    private void RotateWheel() {
        wheel.Rotate(0, 0, -Input.GetAxis("Horizontal") * wheelRotationSpeed);
        wheel.localRotation = Quaternion.Euler(0, 0, ClampAngle(wheel.localEulerAngles.z, -wheelRotationLimit, wheelRotationLimit));
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

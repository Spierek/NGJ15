using UnityEngine;

public class CarScript : MonoBehaviour {
    #region Variables
    private new Rigidbody   rigidbody;
    private Transform       cameraBox;
    
    public float distanceLimit = 5f;

    private float shakePower;
    private float shakeDuration;
    #endregion

    #region Monobehaviour Methods
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
        cameraBox = transform.Find("Camera Box");
    }

    void Update () {
        Movement();

        CameraShaking();
    }
    #endregion

    #region Methods
    private void Movement() {
        // get input and add force
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidbody.AddForce(movementVector * 2, ForceMode.Impulse);

        // bounce off of walls (distance clamping)
        if ((transform.position.x < -distanceLimit && rigidbody.velocity.x < 0) || (transform.position.x > distanceLimit && rigidbody.velocity.x > 0)) {
            rigidbody.velocity = -2 * rigidbody.velocity;
            ShakeCamera(0.1f, 2f);
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
    #endregion
}

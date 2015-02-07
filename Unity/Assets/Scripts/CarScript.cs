using UnityEngine;

public class CarScript : MonoBehaviour {
    #region Variables
    private new Rigidbody rigidbody;
    
    private float speedMod = 1f;
    private float speedLimit = 5f;
    #endregion

    #region Monobehaviour Methods
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update () {
        Movement();
    }
    #endregion

    #region Methods
    private void Movement() {
        // get input and add force
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal") * speedMod, 0);
        rigidbody.AddForce(movementVector, ForceMode.Impulse);

        // clamp horizontal speed
        if (rigidbody.velocity.x < -speedLimit || rigidbody.velocity.x > speedLimit) {
            rigidbody.velocity = new Vector3(Mathf.Clamp(rigidbody.velocity.x, -speedLimit, speedLimit), 0, 0);
        }
    }
    #endregion
}

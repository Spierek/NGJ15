using UnityEngine;

public class CarScript : MonoBehaviour {
    #region Variables
    private new Rigidbody rigidbody;
    
    public float distanceLimit = 5f;
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
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidbody.AddForce(movementVector, ForceMode.Impulse);

        // clamp max distance
        if ((transform.position.x < -distanceLimit && rigidbody.velocity.x < 0) || (transform.position.x > distanceLimit && rigidbody.velocity.x > 0)) {
            rigidbody.velocity = -2 * rigidbody.velocity;
        }
    }
    #endregion
}

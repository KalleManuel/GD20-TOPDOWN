using UnityEngine;

public class CarMovmentController : MonoBehaviour
{

    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode moverRight;
    public KeyCode moveLeft;
    public KeyCode brakeCar;

    [Tooltip("Movement Speed In Meters per Second")]
    public float moveSpeed = 2.5f;

    public float slowDown = 0.5f;
    public float brakeForce = 5f;

    private void Start()
    {
    
    }

    void Update()
    {
        bool forward = Input.GetKey(moveForward);
        bool backward = Input.GetKey(moveBackward);
        bool right = Input.GetKey(moverRight);
        bool left = Input.GetKey(moveLeft);
        bool brake = Input.GetKey(brakeCar);
        bool brakeStop = Input.GetKeyUp(brakeCar);

        if (forward)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
        }

        if (backward)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.up * (moveSpeed * slowDown)); 
        }
        if (right)
        {
            transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
        }
        if (left)
        {
            transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
        }
        if (brake)
        {
            GetComponent<Rigidbody2D>().drag = brakeForce;
        }

        if (brakeStop)
        {
            GetComponent<Rigidbody2D>().drag = 1f;
        }

    }
}

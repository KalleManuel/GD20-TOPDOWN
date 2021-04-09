using UnityEngine;

public class MovementController : MonoBehaviour
{

    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode moverRight;
    public KeyCode moveLeft;
 

    [Tooltip("Movement Speed In Meters per Second")]
    public float moveSpeed = 2.5f;

    public float slowDown = 0.5f;


    void Update()
    {
        bool forward = Input.GetKey(moveForward);
        bool backward = Input.GetKey(moveBackward);
        bool right = Input.GetKey(moverRight);
        bool left = Input.GetKey(moveLeft);
       

        if (forward)
        {
            transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        }

        if (backward)
        {
            transform.Translate(Vector3.down * ((moveSpeed *slowDown) * Time.deltaTime));
        }
        if (right)
        {
            transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
        }
        if (left)
        {
            transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));
        }

    }
}

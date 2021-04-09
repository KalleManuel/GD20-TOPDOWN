using UnityEngine;

public class CarRotationController : MonoBehaviour
{

    public KeyCode rotateRight;
    public KeyCode rotateLeft;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 1.2f;
    public float speed;

    
    void Update()
    {
        bool rightRotate = Input.GetKey(rotateRight);
        bool LeftRotate = Input.GetKey(rotateLeft);

        
        if (rightRotate)
        {
            speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            transform.Rotate(0f,0f,-1f * speed);
        }
        if (LeftRotate)
        {
            speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            transform.Rotate(0f, 0f, 1f * speed);
        }

    }
}

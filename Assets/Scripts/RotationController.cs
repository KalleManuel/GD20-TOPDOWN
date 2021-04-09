using UnityEngine;

public class RotationController : MonoBehaviour
{

    public KeyCode rotateRight;
    public KeyCode rotateLeft;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 150;

    
    void Update()
    {
        bool rightRotate = Input.GetKey(rotateRight);
        bool LeftRotate = Input.GetKey(rotateLeft);

        
        if (rightRotate)
        {
            transform.Rotate(0f,0f,-1f * (rotationSpeed * Time.deltaTime));
        }
        if (LeftRotate)
        {
            transform.Rotate(0f, 0f, 1f * (rotationSpeed * Time.deltaTime));
        }

    }
}

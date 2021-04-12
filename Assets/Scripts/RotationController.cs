using UnityEngine;

public class RotationController : MonoBehaviour
{

  

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed = 150;

    
    BetterCarMovement betterCarMovement;

    
    void Update()
    {
        betterCarMovement = GetComponent<BetterCarMovement>();
        PlayerInput playerInput = betterCarMovement.driver.GetComponent<PlayerInput>();

        bool rightRotate = Input.GetKey(playerInput.rotateTowerRight);
        bool LeftRotate = Input.GetKey(playerInput.rotateTowerLeft);

        
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

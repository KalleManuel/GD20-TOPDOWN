
using UnityEngine;
using System.Linq;

public class HumanMovement : MonoBehaviour
{

    [Tooltip("Movement Speed In Meters per Second")]
    public float moveSpeed = 2.5f;

    public float slowDown = 0.5f;

    public float rotationSpeed = 10;

    public PlayerInput playerInput;

    private void Start()
    {
      

    }

    void Update()
    {
        bool forward = Input.GetKey(playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backwardKey);
        bool rightRotate = Input.GetKey(playerInput.turnRightKey);
        bool LeftRotate = Input.GetKey(playerInput.turnLeftKey);
        bool enterCar = Input.GetKeyDown(playerInput.enterCars);

        if (rightRotate)
        {
            transform.Rotate(0f, 0f, -1f * (rotationSpeed * Time.deltaTime));
        }

        if (LeftRotate)
        {
            transform.Rotate(0f, 0f, 1f * (rotationSpeed * Time.deltaTime));
        }

        if (forward)
        {
            transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        }

        if (backward)
        {
            transform.Translate(Vector3.down * ((moveSpeed * slowDown) * Time.deltaTime));
        }

        if (enterCar)
        {

            BetterCarMovement closestCar = GetClosestCar();
            float distance = Vector3.Distance(closestCar.transform.position, this.transform.position);

           if (distance < 2f)
            {
                closestCar.EnterCar(gameObject);
            }
        }
    }

    BetterCarMovement GetClosestCar()
    {
        return Resources.FindObjectsOfTypeAll<BetterCarMovement>()
             .OrderBy((a) => Vector3.Distance(this.transform.position, a.transform.position))
             .First();
    }

}


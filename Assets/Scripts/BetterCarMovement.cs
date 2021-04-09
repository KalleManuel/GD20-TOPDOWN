
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class BetterCarMovement : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed;

    public float brakeForce;

    public GameObject driver;
   



    public float gearOneSpeed = 25000f;
    public float gearTwoSpeed = 35000f;


    private void Start()
    {
        GetComponent<BetterCarMovement>().enabled = false;
    }

    void Update()
    {
        PlayerInput playerInput = driver.GetComponent<PlayerInput>();

    bool forward = Input.GetKey(playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backwardKey);
        bool rotateLeft = Input.GetKey(playerInput.turnLeftKey);
        bool Rotateright = Input.GetKey(playerInput.turnRightKey);
        bool brake = Input.GetKey(playerInput.brakeCar);
        bool brakeStop = Input.GetKeyUp(playerInput.brakeCar);
        bool exitCar = Input.GetKeyDown(playerInput.exitCars);
        bool gearone = Input.GetKeyDown(playerInput.fistGear);
        bool geartwo = Input.GetKeyDown(playerInput.secondGear);

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (forward)
        {
            rigidbody.AddForce(transform.up * (movementSpeed * Time.deltaTime));
        }

        if (backward)
        {
            rigidbody.AddForce(transform.up * (-movementSpeed * Time.deltaTime));
        }

        if (Rotateright)
        {
            // We want to rotate on the z-axis:
            var rotateBy = new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            // We rotate the transform:
            transform.Rotate(rotateBy);
            // And we also rotate the velocity, so that we do not continue sliding in the old direction:
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (rotateLeft)
        {
            var rotateBy = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (brake)
        {
            GetComponent<Rigidbody2D>().drag = brakeForce;
        }

        if (brakeStop)
        {
            GetComponent<Rigidbody2D>().drag = 1f;
        }
        if (exitCar)
        {

            ExitCar();
            //ToggleCamera();
        }

        if (gearone)
        {
            movementSpeed = gearOneSpeed;
        }

        if (geartwo)
        {
            
            movementSpeed = gearTwoSpeed;
        }
    }
    public void ExitCar()
    {
        driver.SetActive(true);

        GetComponent<BetterCarMovement>().enabled = false;

        Vector3 ofSetPos = new Vector3(gameObject.transform.localPosition.x - 1, gameObject.transform.localPosition.y, 0);
        driver.transform.position = ofSetPos;
        driver = null;
    }

    /*
    void ToggleCamera()
    {
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        cameraFollow.onPlayer = true;
    }    */

}

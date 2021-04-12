
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class BetterCarMovement : MonoBehaviour
{



    /* remember:

    - make methods
    -use return to stop a method
    - exit point
    - get tank to work properbly
    - make it shoot
    - simplify exit, enter - see marks script.
    - make tilemap
    - make game - enemies? lifes?
    - two cameras (split) or  camera range getting wider.
    - add sounds
    


    */

    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;

    [Tooltip("Rotation Speed In Degrees per Second")]
    public float rotationSpeed;

    public float brakeForce;

    public GameObject driver;

    public float gearOneSpeed = 25000f;
    public float gearTwoSpeed = 35000f;

    public Transform exitPoint;

    private bool HasDriver => driver != null;
  

    void Update()
    {
        if (!HasDriver)
            return;

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
            
            var rotateBy = new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);            
            transform.Rotate(rotateBy);
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
        

        if (gearone)
        {
            movementSpeed = gearOneSpeed;
        }

        if (geartwo)
        {
            
            movementSpeed = gearTwoSpeed;
        }

        if (exitCar)
        {

            ExitCar();

        }
    }

    public void EnterCar(GameObject _driver)
    {
        if (HasDriver)
            ExitCar();

        this.driver = _driver;
        _driver.SetActive(false);
    }

    public void ExitCar()
    {
   
        driver.transform.position = exitPoint.transform.position;
        driver.SetActive(true);
        driver = null;
    }

    
}

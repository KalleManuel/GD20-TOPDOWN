
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public bool onPlayer = true;
    public float smoothspeed = 0.125f;
    public Vector3 offset;

    private void Awake()
    {
        onPlayer = true;
        Update();
    }

    private void Update()
    {
        if (onPlayer)
        {
            GameObject human = GameObject.Find("Human");
            target = human.transform;
        }

        else if (!onPlayer)
        {
            GameObject car = GameObject.FindGameObjectWithTag("Car");
            target = car.transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothedPosition;
    }

}

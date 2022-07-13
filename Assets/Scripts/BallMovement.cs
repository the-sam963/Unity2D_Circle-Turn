using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float speed = 150f;

    void FixedUpdate() 
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public void ChangeDirection()
    {
        speed = -speed;
    }
}

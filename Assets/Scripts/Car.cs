using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    public float speed;
    public float torque;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        Vector3 move = transform.forward;
        //rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if(rb.linearVelocity.magnitude < speed)
        {
            rb.AddForce(move * torque);
        }
    }
}

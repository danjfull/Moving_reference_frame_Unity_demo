using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    public InputActionAsset inputActions; // this is set by the input system


    private InputAction m_move;
    private InputAction m_jet;

    private Rigidbody rb;

    public float maxSpeed = 12f;
    public float maxForce = 50f;
    public float jumpForce = 20f;

    public void OnEnable()
    {
        if (inputActions == null)
            return;
        inputActions.FindActionMap("Player").Enable();
        m_move = InputSystem.actions.FindAction("Move");
        m_jet = InputSystem.actions.FindAction("Jump");
    }

    public void OnDisable()
    {
        if (inputActions == null)
            return;
        inputActions.FindActionMap("Player").Disable();
    }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_move = InputSystem.actions.FindAction("Move");
        m_jet = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (MenuManager.IsMenuOpen())
        {
            rb.isKinematic = true; // pause
            return;
        }
        else
        {
            rb.isKinematic = false;
        }
        Vector2 moveInput = m_move.ReadValue<Vector2>();
        Vector3 move = rb.rotation * new Vector3(moveInput.x, 0, moveInput.y).normalized;

        // player walks on what is underneath them, if it is present
        if (Physics.SphereCast(transform.position, 0.5f, Vector3.down, out RaycastHit hitInfo, 1.5f))
        {
            // get velocity of what is under player
            Vector3 floorVelocity = hitInfo.rigidbody != null ? hitInfo.rigidbody.GetPointVelocity(hitInfo.point) : Vector3.zero;
            if (Vector3.Dot(hitInfo.normal.normalized, transform.up.normalized) < 0.33f) // they can only walk on relatively flat areas
            {
                Quaternion groundRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                move = groundRotation * move; // allows player to move up slopes
            }
            // now only move up to a max relative velocity
            Vector3 relativeVelocity = rb.linearVelocity - floorVelocity;
            if (move.magnitude > 0.001f) // if player is trying to move
            {
                Vector3 planedVelocity = Vector3.ProjectOnPlane(relativeVelocity, hitInfo.normal);
                rb.AddForce((move.normalized * maxSpeed - relativeVelocity) * maxForce); // desired velocity is reached with diminishing additional force as player runs faster

                if (planedVelocity.magnitude < 3.0f && move.magnitude > 0.5f) // if character is trying to walk, but isn't...
                {
                    //apply a pushing force, as the character is essentially planting their feet.
                    //rb.AddForce(move.normalized * maxForce * 4.0f); // add up to 5x total pushing power
                }
            }
            else
            {
                // Try to stop moving
                Vector3 horizontalVelocity = Vector3.ProjectOnPlane(relativeVelocity, hitInfo.normal);
                rb.AddForce(-horizontalVelocity * maxForce); // apply a braking force to stop the character
            }
        }
        else
        {
            rb.AddForce(move.normalized * maxForce * 0.1f); // in air, apply a much smaller amount of control
        }

        // jet/jump
        if (m_jet.IsPressed())
        {
            rb.AddForce(rb.rotation * Vector3.up * jumpForce); // apply upward force when jump is pressed
        }

        // limits
        if (rb.angularVelocity.magnitude > 5f)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * 5f; // enforce a max angular rotation speed
        }
    }
}

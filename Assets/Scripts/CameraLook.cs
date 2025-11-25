using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public InputActionAsset inputActions; // this is set by the input system

    private InputAction m_look;

    private float _yCurrent;

    private float _lookSensitivity = 40f;

    public float playerLookSensitivity;

    public void OnEnable()
    {
        if (inputActions == null)
            return;
        inputActions.FindActionMap("Player").Enable();
        m_look = inputActions.FindAction("Look");
        //if (m_look != null)
        //{
        //    m_look.Enable(); // provides control over if this particular action can happen right now
        //}
    }

    public void OnDisable()
    {
        if (inputActions == null)
            return;
        inputActions.FindActionMap("Player").Disable();
        //if (m_look != null)
        //{
        //    m_look.Disable();
        //}
    }

    void Awake()
    {
        m_look = InputSystem.actions.FindAction("Look");
        _yCurrent = 0.0f;
        playerLookSensitivity = 1.0f;

        // hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(MenuManager.IsMenuOpen())
            return;
        // update look direction
        Vector2 lookInput = m_look.ReadValue<Vector2>(); // delta of the mouse (for keyboard/mouse setup)
        _yCurrent = Mathf.Clamp(_yCurrent - lookInput.y/Screen.height * 10f * _lookSensitivity * playerLookSensitivity, -89.9f, 89.9f);
        Rigidbody rb = gameObject.GetComponentInParent<Rigidbody>();
        rb.MoveRotation(Quaternion.AngleAxis(lookInput.x/Screen.width * 10f * _lookSensitivity * playerLookSensitivity, Vector3.up) * rb.rotation); // rotate the character body left/right

        transform.localRotation = Quaternion.AngleAxis(_yCurrent, Vector3.right); // set camera up/down
    }

    public void SetLookSensitivity(float sensitivity)
    {
        playerLookSensitivity = sensitivity;
    }
}

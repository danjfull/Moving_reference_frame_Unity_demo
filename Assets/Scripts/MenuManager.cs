using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public InputActionAsset inputActions; // this is set by the input system
    [SerializeField] private GameObject menuUI;

    private InputAction menu_command;
    private bool isMenuOpen;

    static MenuManager instance;

    public void OnEnable()
    {
        if (inputActions == null)
            return;
        inputActions.FindActionMap("Player").Enable();
        menu_command = inputActions.FindAction("Menu");
    }

    public void OnDisable()
    {
        if (inputActions == null)
            return;
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        instance = this;
        isMenuOpen = true;
        menu_command = InputSystem.actions.FindAction("Menu");
    }

    void Start()
    {
        EnableMenu(); // this opens the menu at start, so you don't have to see it while editing the scene
    }

    private void Update()
    {
        if (menu_command.WasPressedThisFrame())
        {
            if (isMenuOpen)
            {
                // close menu
                DisableMenu();
            }
            else
            {
                EnableMenu();
            }
        }
    }

    public static bool IsMenuOpen()
    {
        return instance.isMenuOpen;
    }

    public void EnableMenu()
    {
        menuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isMenuOpen = true;
    }

    public void DisableMenu()
    {
        menuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isMenuOpen = false;
    }
}

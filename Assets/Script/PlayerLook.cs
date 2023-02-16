using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private InputAction _inputAction;

    [SerializeField] private float sensitivity = 100f;
    //[SerializeField] private Transform playerBody;

    Player_Input _player_Input;


    private void Awake()
    {
        _player_Input = new Player_Input();
        _player_Input.Player.Enable();
    }

    private void Update()
    {
        RayCastDebug();
    }

    private void OnEnable()
    {
        _player_Input.Player.Look.performed += OnLook;
    }
    private void OnDisable()
    {
        _player_Input.Player.Look.performed -= OnLook;
    }

    private void PadInput() //Fixed Update by documentaiton
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.

        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            // 'Use' code here
            Debug.Log("Right Trigger detected, but No Configured Yet");
        }

        Vector2 move = gamepad.leftStick.ReadValue();
    }
    void RayCastDebug()
    {
        Vector3 camPos = Camera.main.transform.position;
        Vector3 camDir = Camera.main.transform.forward;
        Ray ray = new Ray(camPos, camDir);
        float rayLength = 100f;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.green);
    }

    void MouseDelta() //camera rotation
    {
        //MOUSE DETA is use to get value of mouse
        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * sensitivity * Time.deltaTime;
        //Debug.Log("Value of mouse delta" + mouseDelta);

        // Clamp the vertical look angle to avoid flipping the camera upside down
        float currentXRotation = transform.eulerAngles.x;
        float newXRotation = currentXRotation - mouseDelta.y;
        transform.rotation = Quaternion.Euler(newXRotation, transform.eulerAngles.y + mouseDelta.x, 0f);

        // Rotate the player body around the Y axis
        //transform.Rotate(Vector3.up * mouseDelta.x);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>() * sensitivity * Time.deltaTime;
        Debug.Log("Value of MouseDelta" + mouseDelta);
        float currentXRotation = transform.eulerAngles.x;
        float newXRotation = currentXRotation - mouseDelta.y;
        transform.rotation = Quaternion.Euler(newXRotation, transform.eulerAngles.y + mouseDelta.x, 0f);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{

    //PUBLIC AND EXPOSED
    [SerializeField]
    float speed;


    //PRIVATE
    private Player_Input _player_Input;
    private Vector2 moveXY;
    private Vector3 moveTo3D;
    private CharacterController _characterController;


    //LIFE CYCLE and INPUT SYSTEM
    private void Awake()
    {
        _player_Input = new Player_Input();
        _player_Input.Player.Enable();
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _characterController.Move(moveTo3D * speed);
    }

    private void Update()
    {
        //if(!AnyKeyControl)
        //moveTo3D = Vector3.zero; //is reset to 0 while no moving
    }

    private void OnEnable()
    {
        //_player_Input.Player.Fire.performed += OnFire; //sub
        //_player_Input.Player.Move.performed += OnMove;
    }

    private void OnDisable()
    {
        //_player_Input.Player.Fire.performed -= OnFire; //desub
        //_player_Input.Player.Move.performed -= OnMove;
    }

    private void OnMove(InputValue value) //check name and add On
    {
        moveXY = value.Get<Vector2>();
        moveTo3D = new Vector3(moveXY.x, 0f, moveXY.y); //the y go to z //move by refer to map XZ
        moveTo3D = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f) * moveTo3D; //move by considere camera rotation
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire ! ");
    }

    //TOOL DEBUG AND UNUSED

    //private void OnMove(InputAction.CallbackContext context) //V1
    //{
    //    Vector2 moveXY = context.ReadValue<Vector2>(); //_player_Input.Player.Move.ReadValue<Vector2>(); //OS
    //    Debug.Log("Value of moveXY" + moveXY);
    //    Vector3 moveTo3D = new Vector3(moveXY.x, 0f, moveXY.y) * speed * Time.fixedDeltaTime;
    //    transform.position += moveTo3D;
    //}

    //private void OnMove(InputAction.CallbackContext context) //V2
    //{
    //    if (context.performed)
    //    {
    //        Debug.Log("IsPerformed");
    //        moveXY = context.ReadValue<Vector2>(); //_player_Input.Player.Move.ReadValue<Vector2>(); //OS
    //        moveTo3D = new Vector3(moveXY.x, 0f, moveXY.y);
    //    }
    //    if (context.canceled)
    //    {
    //        Debug.Log("Key release");
    //        moveTo3D = Vector3.zero;
    //    }
    //    //le y sera la valeur du z dans le monde.
    //    //Debug.Log("Value of moveXY" + moveXY);
    //}


    // METHOD


}
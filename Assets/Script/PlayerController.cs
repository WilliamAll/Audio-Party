using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    private Player_Input _player_Input;

    private void Awake()
    {
        _player_Input = new Player_Input();
        _player_Input.Player.Enable();
    }

    private void OnEnable()
    {
        _player_Input.Player.Fire.performed += OnFire; //sub
        _player_Input.Player.Move.performed += OnMove;
    }

    private void OnDisable()
    {
        _player_Input.Player.Fire.performed -= OnFire; //desub
        _player_Input.Player.Move.performed -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveXY = context.ReadValue<Vector2>(); //_player_Input.Player.Move.ReadValue<Vector2>(); //OS
        Debug.Log("Value of moveXY" + moveXY);
        Vector3 moveTo3D = new Vector3(moveXY.x, 0f, moveXY.y) * speed * Time.fixedDeltaTime;
        transform.position += moveTo3D;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire ! ");
    }
}
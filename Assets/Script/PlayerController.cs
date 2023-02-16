using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player_Input _player_Input;

    private void Awake()
    {
        _player_Input = new Player_Input();
        _player_Input.Player.Enable();
    }

    private void OnEnable()
    {
        _player_Input.Player.Fire.performed += OnFire; //sub
    }

    private void OnDisable()
    {
        _player_Input.Player.Fire.performed -= OnFire; //desub
    }

    private void Update()
    {
        Vector2 inputtest = _player_Input.Player.Move.ReadValue<Vector2>();
        Debug.Log("Value of InputTest" + inputtest);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire ! ");
    }
}
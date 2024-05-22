using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GetInput : MonoBehaviour
{
    public Vector2 movement;

    public bool getInput = false;
    public bool isSprinting = false;



    public void OnMove(InputAction.CallbackContext _context)
    {
        movement = _context.ReadValue<Vector2>();

        if(movement != null)
        {
            getInput = true;
        }
        else
        {
            getInput = false;
        }
    }

    public void OnSprint(InputAction.CallbackContext _context)
    {
        if(_context.performed)
        {
            isSprinting = true;
        }
        if(_context.canceled)
        {
            isSprinting = false;
        }
    }
}

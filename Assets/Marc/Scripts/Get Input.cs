using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GetInput : MonoBehaviour
{
    public Vector2 movement;  // Movement script

    public bool getInput = false;
     
    public bool isSprinting = false;  // Movement script

    public bool isShooting = false;  // Shoot script

    public bool isDrinking = false;

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

    public void OnShoot(InputAction.CallbackContext _context)
    {
        if(_context.performed)
        {
            isShooting = true;
        }
        if(_context.canceled)
        {
            isShooting = false;
        }
    }

    public void OnDrink(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            isDrinking = true;
        }
        if (_context.canceled)
        {
            isDrinking = false;
        }
    }
}

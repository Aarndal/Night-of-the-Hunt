using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject StoneObject;
    [SerializeField] private GameObject Crosshair;

    private Vector3 MousePosition;

    [Tooltip("How fast the stones should be")] [SerializeField]
    private float shootSpeed;

    private GetInput myInput;

    private void Start()
    {
        myInput = GetComponent<GetInput>();
    }

    private void Update()
    {
        //  Crosshair Location and visibilitys
        this.Crosshair.transform.position = Input.mousePosition;
        
        this.Crosshair.SetActive(GetComponent<StonePossession>().HasStone());
    }

    private void FixedUpdate()
    {
        if (myInput.isShooting)
        {
            ShootStone();
        }
    }

    private void ShootStone()
    {
        StonePossession stonePossession = GetComponent<StonePossession>();

        if (!stonePossession.HasStone()) return;
        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        stonePossession.GetStone().GetComponent<Rigidbody2D>().velocity = mousePos * (this.shootSpeed * Time.deltaTime);
        
        stonePossession.RemoveStone();
    }
}
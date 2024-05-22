using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletObject;

    [Tooltip("How fast the stones should be")]
    [SerializeField] private float shootSpeed;

    private GetInput myInput;

 
    private Vector3 mousePos; // Mouse Position, the way the stones are flying

    private Camera mainCamera;

    private int shootIndex = 0; // able to shoot if index = 0 so player cant spam
    private void Start()
    {
        myInput = GetComponent<GetInput>();

       // mainCamera = Camera.main;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            shootIndex = 0;
        }
    }
    private void FixedUpdate()
    {
        if(myInput.isShooting == true)
        {
            ShootStone();
        }

        
    }

    private void ShootStone()
    {
        if(shootIndex == 0)
        {
          //  mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            shootIndex = 1;

            GameObject tempStone = Instantiate(bulletObject, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            tempStone.SetActive(true);

            Rigidbody2D myRigid = tempStone.AddComponent<Rigidbody2D>();
            myRigid.gravityScale = 0;


            myRigid.velocity = mousePos * shootSpeed * Time.deltaTime;
        }
     
    }
}

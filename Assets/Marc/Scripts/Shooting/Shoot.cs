using _Project.Scripts.Items;
using _Project.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject Crosshair;
    private GameObject StoneObject;
    
    [Tooltip("How fast the stones should be")] [SerializeField]
    private float shootSpeed;
    
    private Vector2 AimPOS;
    private Vector2 ControllerInput;

    private bool isControllerInput = false;

    private void Start()
    {
        GetInput myInput = GetComponent<GetInput>();
        
        myInput.ShootEvent += ShootStone;
    }

    private void Update()
    {
        Debug.Log(GetComponent<GetInput>().aim);
        this.isControllerInput = GetComponent<GetInput>().aim != Vector2.zero;
        
        if (this.isControllerInput)
        {
            Vector2 aim = GetComponent<GetInput>().aim * 500;
            Vector2 offset = new Vector2(1920/2, 1080/3);
            this.Crosshair.transform.position = aim + offset;
        }
        else
        {
            this.Crosshair.transform.position = Input.mousePosition;
        }
        
        this.Crosshair.SetActive(GetComponent<StonePossession>().HasStone());
    }

    private void ShootStone()
    {
        StonePossession stonePossession = GetComponent<StonePossession>();

        if (!stonePossession.HasStone()) return;
        
        Vector3 MousePOS = Mouse.current.position.ReadValue();
        
        if (this.isControllerInput)
        {
            Vector2 aim = GetComponent<GetInput>().aim * 500;
            Vector2 offset = new Vector2(1920/2, 1080/3);
            MousePOS = aim + offset;
        }
        
        MousePOS.z = -Camera.main.transform.position.z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(MousePOS);
        
        var stone = stonePossession.GetStone();
        stone.SetActive(true);
        
        stone.transform.position = this.transform.position;
        stone.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(worldPos - this.transform.position)  * (this.shootSpeed * Time.deltaTime);
        
        stone.GetComponent<StoneItem>().StartThrow();
        stonePossession.RemoveStone();
    }

}
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

    private void Start()
    {
        GetInput myInput = GetComponent<GetInput>();
        
        myInput.ShootEvent += ShootStone;
    }

    private void Update()
    {
        //  Crosshair Location and visibilityss
        this.Crosshair.transform.position = Input.mousePosition;
        
        this.Crosshair.SetActive(GetComponent<StonePossession>().HasStone());
    }

    private void ShootStone()
    {
        StonePossession stonePossession = GetComponent<StonePossession>();

        if (!stonePossession.HasStone()) return;
        
        Vector3 MousePOS = Mouse.current.position.ReadValue();
        MousePOS.z = -Camera.main.transform.position.z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(MousePOS);
        
        var stone = stonePossession.GetStone();
        stone.SetActive(true);
        
        stone.transform.position = transform.position;
        stone.GetComponent<Rigidbody2D>().velocity = (worldPos - transform.position) * (this.shootSpeed * Time.deltaTime);
        
        stone.GetComponent<StoneItem>().StartThrow();
        stonePossession.RemoveStone();
    }

}
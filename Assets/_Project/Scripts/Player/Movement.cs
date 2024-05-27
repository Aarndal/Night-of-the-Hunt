using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private Sprite[] CharacterSprites = new Sprite[4];

    private GetInput myInput; //Get Input through input system
    private Rigidbody2D myRigid; // Rigidbody of player 


    [Tooltip("Normal walk speed")] [SerializeField]
    private float normalSpeed;

    [Space(5)] [Tooltip("Sprint speed")] [SerializeField]
    private float sprintSpeed;

    #region Stamina

    [Header("Stamina")] [Tooltip("How much stamina the player has")] [SerializeField]
    private float CurrentStamina;

    [Tooltip("Limiter of max stamina ( player cant have more than maxStamina")] [SerializeField]
    private float maxStamina;

    [Tooltip("How fast you want to decrease the stamina while sprinting")] [SerializeField]
    private float decreaseSprintingStamina = 3;

    [SerializeField] private float IncreaseStaminaStanding = 2;
    [SerializeField] private float IncreaseStaminaWalking = 3;

    [Tooltip("How fast you want to increase the stamina after sprinting")] [SerializeField]
    private float IncreaseStaminaFactor;

    [Tooltip("How much stamina the wine regenerate")] [SerializeField]
    private float wineInfluence;

    [Space(5)] [Tooltip("Stamina circle")] [SerializeField]
    private Image StaminaImage;

    #endregion

    [Header("Preusod Animation")] [SerializeField]
    private float RotationSpeed = 5;

    [SerializeField] private float RotationsSpeedWalking = 5;
    [SerializeField] private float RotationSpeedSprinting = 10;
    [SerializeField] private float Amplitude = 3f;


    private void Start()
    {
        myInput = GetComponent<GetInput>();
        myRigid = GetComponent<Rigidbody2D>();

        Wine.RefreshStaminaEvent += GetStamina;
        
        this.CurrentStamina = this.maxStamina;
    }

    private void FixedUpdate()
    {
        if (myInput.getInput) Walk();
        else IncreaseStamina(this.IncreaseStaminaStanding * this.IncreaseStaminaFactor);
    }

    /// <summary>
    /// Move Rigidbody through velocity that is manipulated by the input of the player   /    If Player is sprinting -> stamina decreases and player can sprint until stamina reached 0
    /// </summary>
    private void Walk()
    {
        Vector2 moveDirection = new Vector2(myInput.movement.x, myInput.movement.y);
        this.RotationSpeed = this.RotationsSpeedWalking;

        GetComponent<SpriteRenderer>().sprite = moveDirection.y switch
        {
            > 0 => this.CharacterSprites[1],
            < 0 => this.CharacterSprites[0],
            0 when moveDirection.x > 0 => this.CharacterSprites[2],
            0 when moveDirection.x < 0 => this.CharacterSprites[3],
            _ => GetComponent<SpriteRenderer>().sprite
        };

        moveDirection = Vector2.right * myInput.movement.x + Vector2.up * myInput.movement.y;

        if (!myInput.isSprinting || this.CurrentStamina <= 0.0f)
        {
            myInput.isSprinting = false; // if its not set false -> player can sprint all the time

            myRigid.velocity = moveDirection * (this.normalSpeed * Time.deltaTime);
        }

        if (myInput.isSprinting && this.CurrentStamina > 0.0f)
        {
            this.RotationSpeed = this.RotationSpeedSprinting;

            myRigid.velocity = moveDirection * (this.sprintSpeed * Time.deltaTime);
        }

        if (this.myInput.isSprinting) DecreaseStamina();
        else IncreaseStamina(this.IncreaseStaminaWalking * this.IncreaseStaminaFactor);

        // The Rotation Animation
        float rotation = Mathf.Sin(Time.time * this.RotationSpeed) * this.Amplitude;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }



    /// <summary>
    /// increase stamina while walking or while standing ( regenerate stamina while standing is possible cause myinput.getInput is after fist input never false again ( it is not supposed to be like this, but not relevant ))
    /// </summary>
    private void IncreaseStamina(float increaseStamina)
    {
        this.CurrentStamina = Mathf.Clamp(this.CurrentStamina + (increaseStamina * Time.deltaTime), 0.0f, maxStamina);
        this.StaminaImage.fillAmount = (1 / this.maxStamina) * this.CurrentStamina;
    }



    /// <summary>
    /// decrease stamina while sprinting
    /// </summary>
    private void DecreaseStamina()
    {
        this.CurrentStamina = Mathf.Clamp(this.CurrentStamina - (this.decreaseSprintingStamina * Time.deltaTime), 0.0f, maxStamina);
        this.StaminaImage.fillAmount = (1 / this.maxStamina) * this.CurrentStamina;
    }

    private void GetStamina()
    {
        this.CurrentStamina += wineInfluence;
    }
}
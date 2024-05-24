using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSticking : MonoBehaviour
{
    [SerializeField] private GameObject StaminaBar;

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 PlayerScreenPos = Camera.main.WorldToScreenPoint(PlayerPos);
        this.StaminaBar.transform.position = Vector2.Lerp(this.StaminaBar.transform.position, PlayerScreenPos + new Vector2(-150, 200), 0.1f);
    }
}

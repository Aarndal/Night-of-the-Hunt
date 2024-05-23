using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public static event Action myEvent; // Triggers the event if it collides ( distract enemy or smth. ) 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        myEvent?.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Items;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Piep");
        if (other.TryGetComponent(out ICollectable collectable)) collectable.Collect(other);
    }
}
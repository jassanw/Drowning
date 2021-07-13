using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] Enums.Items itemType;

    public static event Action<Enums.Items> OnItemPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            OnItemPickUp?.Invoke(itemType);
            Destroy(gameObject);
        }
    }
}

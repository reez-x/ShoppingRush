using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Ketika keranjang bersentuhan dengan item
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek jika objek yang ditabrak memiliki komponen "Item"
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class CharacterMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f; // Kecepatan pergerakan karakter
//     private bool isMovingLeft = false; // Status apakah karakter bergerak ke kiri
//     private bool isMovingRight = false; // Status apakah karakter bergerak ke kanan
//     private Rigidbody2D rb;

//     // Batas kiri dan kanan
//     public float minX = -5f;  // Batas kiri pergerakan
//     public float maxX = 5f;   // Batas kanan pergerakan

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody2D>(); // Pastikan karakter memiliki Rigidbody2D
//     }

//     private void Update()
//     {
//         if (isMovingLeft)
//         {
//             // Bergerak ke kiri selama tombol ditekan
//             rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Gerak kiri
//         }
//         else if (isMovingRight)
//         {
//             // Bergerak ke kanan selama tombol ditekan
//             rb.velocity = new Vector2(moveSpeed, rb.velocity.y); // Gerak kanan
//         }
//         else
//         {
//             // Berhenti bergerak saat tidak ada tombol yang ditekan
//             rb.velocity = Vector2.zero;
//         }

//         // Membatasi posisi X agar karakter tidak melewati batas kiri dan kanan
//         float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
//         transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
//     }

//     // Fungsi untuk memulai pergerakan ke kiri saat tombol ditekan
//     public void StartMovingLeft()
//     {
//         isMovingLeft = true; // Mulai bergerak ke kiri
//         isMovingRight = false; // Pastikan pergerakan ke kanan dihentikan
//     }

//     // Fungsi untuk memulai pergerakan ke kanan saat tombol ditekan
//     public void StartMovingRight()
//     {
//         isMovingRight = true; // Mulai bergerak ke kanan
//         isMovingLeft = false; // Pastikan pergerakan ke kiri dihentikan
//     }

//     // Fungsi untuk menghentikan pergerakan saat tombol dilepaskan
//     public void StopMoving()
//     {
//         isMovingLeft = false; // Berhenti bergerak ke kiri
//         isMovingRight = false; // Berhenti bergerak ke kanan
//     }
// }


//
////Add acceleration and deceleration
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan maksimum karakter
    public float acceleration = 5f; // Akselerasi untuk pergerakan
    public float deceleration = 5f; // Deselerasi untuk berhenti
    private float currentSpeed = 0f; // Kecepatan saat ini (diperbarui perlahan)

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private Rigidbody2D rb;

    // Batas kiri dan kanan
    public float minX = -5f;  // Batas kiri pergerakan
    public float maxX = 5f;   // Batas kanan pergerakan

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pastikan karakter memiliki Rigidbody2D
    }

    private void Update()
    {
        if (isMovingLeft)
        {
            // Akselerasi saat bergerak ke kiri
            currentSpeed = Mathf.MoveTowards(currentSpeed, -moveSpeed, acceleration * Time.deltaTime);
        }
        else if (isMovingRight)
        {
            // Akselerasi saat bergerak ke kanan
            currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Deselerasi saat tidak ada input
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }

        // Terapkan kecepatan saat ini pada Rigidbody2D
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

        // Membatasi posisi X agar karakter tidak melewati batas kiri dan kanan
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    // Fungsi untuk memulai pergerakan ke kiri saat tombol ditekan
    public void StartMovingLeft()
    {
        isMovingLeft = true;  // Mulai bergerak ke kiri
        isMovingRight = false; // Pastikan pergerakan ke kanan dihentikan
    }

    // Fungsi untuk memulai pergerakan ke kanan saat tombol ditekan
    public void StartMovingRight()
    {
        isMovingRight = true; // Mulai bergerak ke kanan
        isMovingLeft = false; // Pastikan pergerakan ke kiri dihentikan
    }

    // Fungsi untuk menghentikan pergerakan saat tombol dilepaskan
    public void StopMoving()
    {
        isMovingLeft = false; // Berhenti bergerak ke kiri
        isMovingRight = false; // Berhenti bergerak ke kanan
    }
}



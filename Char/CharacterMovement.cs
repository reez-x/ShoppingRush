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

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class CharacterMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f; // Kecepatan pergerakan maksimum karakter
//     public float acceleration = 5f; // Akselerasi untuk pergerakan
//     public float deceleration = 5f; // Deselerasi untuk berhenti
//     private float currentSpeed = 0f; // Kecepatan saat ini (diperbarui perlahan)

//     private bool isMovingLeft = false;
//     private bool isMovingRight = false;

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
//             // Akselerasi saat bergerak ke kiri
//             currentSpeed = Mathf.MoveTowards(currentSpeed, -moveSpeed, acceleration * Time.deltaTime);
//         }
//         else if (isMovingRight)
//         {
//             // Akselerasi saat bergerak ke kanan
//             currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
//         }
//         else
//         {
//             // Deselerasi saat tidak ada input
//             currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
//         }

//         // Terapkan kecepatan saat ini pada Rigidbody2D
//         rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

//         // Membatasi posisi X agar karakter tidak melewati batas kiri dan kanan
//         float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
//         transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
//     }

//     // Fungsi untuk memulai pergerakan ke kiri saat tombol ditekan
//     public void StartMovingLeft()
//     {
//         isMovingLeft = true;  // Mulai bergerak ke kiri
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
////Fix counter deceleration
//

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CharacterMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f; // Kecepatan pergerakan maksimum karakter
//     public float acceleration = 5f; // Akselerasi untuk pergerakan
//     public float deceleration = 5f; // Deselerasi normal untuk berhenti
//     private float currentSpeed = 0f; // Kecepatan saat ini (diperbarui perlahan)

//     private bool isMovingLeft = false;
//     private bool isMovingRight = false;
//     private float lastDirection = 0f; // Arah terakhir (-1 kiri, 1 kanan, 0 tidak bergerak)

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
//         // Menentukan deselerasi yang lebih cepat jika arah berubah
//         float dynamicDeceleration = (currentSpeed != 0f && Mathf.Sign(currentSpeed) != lastDirection) ? deceleration * 2 : deceleration;

//         if (isMovingLeft)
//         {
//             // Akselerasi saat bergerak ke kiri
//             currentSpeed = Mathf.MoveTowards(currentSpeed, -moveSpeed, acceleration * Time.deltaTime);
//             lastDirection = -1f; // Menandakan karakter bergerak ke kiri
//         }
//         else if (isMovingRight)
//         {
//             // Akselerasi saat bergerak ke kanan
//             currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
//             lastDirection = 1f; // Menandakan karakter bergerak ke kanan
//         }
//         else
//         {
//             // Deselerasi saat tidak ada input (menghentikan karakter)
//             currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, dynamicDeceleration * Time.deltaTime);
//         }

//         // Terapkan kecepatan saat ini pada Rigidbody2D
//         rb.velocity = new Vector2(currentSpeed, rb.velocity.y);

//         // Membatasi posisi X agar karakter tidak melewati batas kiri dan kanan
//         float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
//         transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
//     }

//     // Fungsi untuk memulai pergerakan ke kiri saat tombol ditekan
//     public void StartMovingLeft()
//     {
//         isMovingLeft = true;  // Mulai bergerak ke kiri
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
////Add move speed adjust per level
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Kecepatan pergerakan maksimum karakter
    public float acceleration = 5f; // Akselerasi untuk pergerakan
    public float deceleration = 3f; // Deselerasi normal untuk berhenti
    private float currentSpeed = 0f; // Kecepatan saat ini (diperbarui perlahan)

    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private float lastDirection = 0f; // Arah terakhir (-1 kiri, 1 kanan, 0 tidak bergerak)

    private Rigidbody2D rb;

    // Batas kiri dan kanan
    public float minX = -5f;  // Batas kiri pergerakan
    public float maxX = 5f;   // Batas kanan pergerakan

    // Referensi ke XPLevelManager untuk mendapatkan level dan menyesuaikan kecepatan
    public XPLevelManager xpLevelManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pastikan karakter memiliki Rigidbody2D
        if (xpLevelManager == null)
        {
            Debug.LogError("XPLevelManager not assigned!");
        }
    }

    private void Update()
    {
        // Sesuaikan moveSpeed, acceleration, dan deceleration berdasarkan level
        if (xpLevelManager != null)
        {
            AdjustMovementBasedOnLevel(xpLevelManager.GetCurrentLevel());
        }

        // Menentukan deselerasi yang lebih cepat jika arah berubah
        float dynamicDeceleration = (currentSpeed != 0f && Mathf.Sign(currentSpeed) != lastDirection) ? deceleration * 2 : deceleration;

        if (isMovingLeft)
        {
            // Akselerasi saat bergerak ke kiri
            currentSpeed = Mathf.MoveTowards(currentSpeed, -moveSpeed, acceleration * Time.deltaTime);
            lastDirection = -1f; // Menandakan karakter bergerak ke kiri
        }
        else if (isMovingRight)
        {
            // Akselerasi saat bergerak ke kanan
            currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, acceleration * Time.deltaTime);
            lastDirection = 1f; // Menandakan karakter bergerak ke kanan
        }
        else
        {
            // Deselerasi saat tidak ada input (menghentikan karakter)
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, dynamicDeceleration * Time.deltaTime);
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

    // Fungsi untuk menyesuaikan kecepatan berdasarkan level
    private void AdjustMovementBasedOnLevel(int level)
    {
        // Semakin tinggi level, semakin cepat karakter bergerak
        moveSpeed = 2f + level * 8f; // Contoh: menambah 0.5 ke moveSpeed per level
        acceleration = 5f + level * 3f; // Menambah akselerasi per level
        deceleration = 3f + level * 3f; // Menambah deselerasi per level
        // // Semakin tinggi level, semakin cepat karakter bergerak
        // moveSpeed = 5f + level * 1f; // Contoh: menambah 0.5 ke moveSpeed per level
        // acceleration = 5f + level * 0.4f; // Menambah akselerasi per level
        // deceleration = 5f + level * 0.4f; // Menambah deselerasi per level
    }
}

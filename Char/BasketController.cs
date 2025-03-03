using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// public class BasketController : MonoBehaviour
// {
//     public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager

//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki komponen "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             groceryListManager.AddScore(100);
//             Destroy(collision.gameObject);
//         }
//     }
// }



// public class BasketController : MonoBehaviour
// {
//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki tag "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             // Dapatkan nama item dari objek yang ditabrak
//             string itemName = collision.gameObject.name;

//             // Debug: Menampilkan nama item yang ditangkap oleh keranjang
//             Debug.Log("Keranjang menangkap item: " + itemName);

//             Destroy(collision.gameObject);
//         }
//     }
// }



// public class BasketController : MonoBehaviour
// {
//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki tag "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             // Dapatkan nama item dari objek yang ditabrak
//             string itemName = collision.gameObject.name;

//             // Menghapus "(Clone)" dari nama objek jika ada
//             itemName = itemName.Replace("(Clone)", "").Trim();

//             // Debug: Menampilkan nama item yang ditangkap oleh keranjang
//             Debug.Log("Keranjang menangkap item: " + itemName);
//         }
//     }
// }



// public class BasketController : MonoBehaviour
// {
//     public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager

//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki komponen "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             // Dapatkan nama item dari objek yang ditabrak
//             string itemName = collision.gameObject.name;

//             itemName = itemName.Replace("(Clone)", "").Trim();

//             // Jika item tersebut ada di grocery list, tambah skor
//             if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName))
//             {
//                 // Tambah skor 100
//                 groceryListManager.AddScore(100);

//                 // Tandai item yang sudah ditangkap
//                 groceryListManager.MarkItemAsCaptured(itemName);

//                 // Hancurkan item setelah ditangkap
//                 Destroy(collision.gameObject);
//             }
//         }
//     }
// }



// public class BasketController : MonoBehaviour
// {
//     public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager
//     public ParticleSystem correctItemEffect;  // Referensi ke Particle System untuk item yang benar
//     public ParticleSystem wrongItemEffect;  // Referensi ke Particle System untuk item yang salah

//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki komponen "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             // Dapatkan nama item dari objek yang ditabrak
//             string itemName = collision.gameObject.name;

//             // Menghapus "(Clone)" dari nama item jika ada
//             itemName = itemName.Replace("(Clone)", "").Trim();

//             // Jika item tersebut ada di grocery list, tambah skor dan mainkan efek partikel yang sesuai
//             if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName))
//             {
//                 // Tambah skor 100
//                 groceryListManager.AddScore(100);

//                 // Tandai item yang sudah ditangkap
//                 groceryListManager.MarkItemAsCaptured(itemName);

//                 // Mainkan efek partikel yang sesuai untuk item yang benar
//                 PlayCorrectItemEffect();

//                 // Hancurkan item setelah ditangkap
//                 Destroy(collision.gameObject);
//             }
//             else
//             {
//                 // Jika item tidak ada di grocery list, kurangi skor 50 dan mainkan efek partikel yang berbeda
//                 groceryListManager.AddScore(-50);

//                 // Mainkan efek partikel untuk item yang salah
//                 PlayWrongItemEffect();

//                 // Hancurkan item setelah ditangkap
//                 Destroy(collision.gameObject);
//             }
//         }
//     }

//     // Fungsi untuk memainkan efek partikel untuk item yang benar
//     void PlayCorrectItemEffect()
//     {
//         // Jika Particle System untuk item yang benar tidak null, mainkan efek
//         if (correctItemEffect != null)
//         {
//             correctItemEffect.Play();
//         }
//     }

//     // Fungsi untuk memainkan efek partikel untuk item yang salah
//     void PlayWrongItemEffect()
//     {
//         // Jika Particle System untuk item yang salah tidak null, mainkan efek
//         if (wrongItemEffect != null)
//         {
//             wrongItemEffect.Play();
//         }
//     }
// }


////
//Add HP Mechanism
////

// public class BasketController : MonoBehaviour
// {
//     public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager
//     public ParticleSystem correctItemEffect;  // Referensi ke Particle System untuk item yang benar
//     public ParticleSystem wrongItemEffect;  // Referensi ke Particle System untuk item yang salah
    
//     public GameObject[] healthImages;  // Array untuk menyimpan gambar hati HP

//     private int currentHealth;  // HP saat ini

//     void Start()
//     {
//         currentHealth = healthImages.Length;  // Set HP awal sesuai dengan jumlah gambar hati yang ada
//         UpdateHealthUI();  // Update tampilan HP di UI
//     }

//     // Fungsi untuk mengurangi HP dan memperbarui UI
//     void ReduceHealth()
//     {
//         if (currentHealth > 0)
//         {
//             currentHealth--;  // Kurangi HP
//             UpdateHealthUI();  // Update tampilan UI HP
//         }
//     }

//     // Update tampilan HP di UI (menyembunyikan gambar hati sesuai dengan HP yang tersisa)
//     void UpdateHealthUI()
//     {
//         for (int i = 0; i < healthImages.Length; i++)
//         {
//             if (i < currentHealth)
//             {
//                 healthImages[i].SetActive(true);  // Tampilkan gambar hati
//             }
//             else
//             {
//                 healthImages[i].SetActive(false);  // Sembunyikan gambar hati
//             }
//         }
//     }

//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki komponen "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             string itemName = collision.gameObject.name;
//             itemName = itemName.Replace("(Clone)", "").Trim();  // Menghapus "(Clone)" jika ada

//             // Jika item ada di grocery list, tambah skor dan mainkan efek partikel yang sesuai
//             if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName))
//             {
//                 groceryListManager.AddScore(100);  // Tambah skor
//                 groceryListManager.MarkItemAsCaptured(itemName);  // Tandai item yang ditangkap
//                 PlayCorrectItemEffect();  // Mainkan efek partikel untuk item yang benar
//             }
//             else
//             {
//                 // Jika item tidak ada di grocery list, kurangi HP
//                 ReduceHealth();
//                 PlayWrongItemEffect();  // Mainkan efek partikel untuk item yang salah
//             }

//             Destroy(collision.gameObject);  // Hancurkan item setelah ditangkap
//         }
//     }

//     // Fungsi untuk memainkan efek partikel untuk item yang benar
//     void PlayCorrectItemEffect()
//     {
//         if (correctItemEffect != null)
//         {
//             correctItemEffect.Play();
//         }
//     }

//     // Fungsi untuk memainkan efek partikel untuk item yang salah
//     void PlayWrongItemEffect()
//     {
//         if (wrongItemEffect != null)
//         {
//             wrongItemEffect.Play();
//         }
//     }
// }


//
////Add Gameover to Game
//

// public class BasketController : MonoBehaviour
// {
//     public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager
//     public ParticleSystem correctItemEffect;  // Referensi ke Particle System untuk item yang benar
//     public ParticleSystem wrongItemEffect;  // Referensi ke Particle System untuk item yang salah

//     public GameObject[] healthImages;  // Array untuk menyimpan gambar hati HP
//     public GameObject gameOverCanvas;  // Referensi ke Canvas Game Over

//     private int currentHealth;  // HP saat ini

//     void Start()
//     {
//         currentHealth = healthImages.Length;  // Set HP awal sesuai dengan jumlah gambar hati yang ada
//         UpdateHealthUI();  // Update tampilan HP di UI
//         gameOverCanvas.SetActive(false);  // Pastikan Game Over UI tidak terlihat saat awal permainan
//     }

//     // Fungsi untuk mengurangi HP dan memperbarui UI
//     void ReduceHealth()
//     {
//         if (currentHealth > 0)
//         {
//             currentHealth--;  // Kurangi HP
//             UpdateHealthUI();  // Update tampilan UI HP
//         }

//         // Cek jika HP habis, maka game over
//         if (currentHealth <= 0)
//         {
//             GameOver();  // Panggil fungsi Game Over
//         }
//     }

//     // Update tampilan HP di UI (menyembunyikan gambar hati sesuai dengan HP yang tersisa)
//     void UpdateHealthUI()
//     {
//         for (int i = 0; i < healthImages.Length; i++)
//         {
//             if (i < currentHealth)
//             {
//                 healthImages[i].SetActive(true);  // Tampilkan gambar hati
//             }
//             else
//             {
//                 healthImages[i].SetActive(false);  // Sembunyikan gambar hati
//             }
//         }
//     }

//     // Fungsi untuk mengakhiri permainan dan menampilkan Game Over UI
//     void GameOver()
//     {
//         // Menghentikan semua aktivitas (gerakan objek, fisika, dll.)
//         Time.timeScale = 0;

//         // Menampilkan Canvas Game Over
//         gameOverCanvas.SetActive(true);
//     }

//     // Ketika keranjang bersentuhan dengan item
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Cek jika objek yang ditabrak memiliki komponen "Item"
//         if (collision.gameObject.CompareTag("Item"))
//         {
//             string itemName = collision.gameObject.name;
//             itemName = itemName.Replace("(Clone)", "").Trim();  // Menghapus "(Clone)" jika ada

//             // Jika item ada di grocery list, tambah skor dan mainkan efek partikel yang sesuai
//             if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName))
//             {
//                 groceryListManager.AddScore(100);  // Tambah skor
//                 groceryListManager.MarkItemAsCaptured(itemName);  // Tandai item yang ditangkap
//                 PlayCorrectItemEffect();  // Mainkan efek partikel untuk item yang benar
//             }
//             else
//             {
//                 // Jika item tidak ada di grocery list, kurangi HP
//                 ReduceHealth();
//                 PlayWrongItemEffect();  // Mainkan efek partikel untuk item yang salah
//             }

//             Destroy(collision.gameObject);  // Hancurkan item setelah ditangkap
//         }
//     }

//     // Fungsi untuk memainkan efek partikel untuk item yang benar
//     void PlayCorrectItemEffect()
//     {
//         if (correctItemEffect != null)
//         {
//             correctItemEffect.Play();
//         }
//     }

//     // Fungsi untuk memainkan efek partikel untuk item yang salah
//     void PlayWrongItemEffect()
//     {
//         if (wrongItemEffect != null)
//         {
//             wrongItemEffect.Play();
//         }
//     }
// }


//
////Add score to gameover popup
//

using TMPro;  // Pastikan menggunakan TextMeshPro

public class BasketController : MonoBehaviour
{
    public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager
    public ParticleSystem correctItemEffect;  // Referensi ke Particle System untuk item yang benar
    public ParticleSystem wrongItemEffect;  // Referensi ke Particle System untuk item yang salah

    public GameObject[] healthImages;  // Array untuk menyimpan gambar hati HP
    public GameObject gameOverCanvas;  // Referensi ke Canvas Game Over
    public TextMeshProUGUI scoreText;  // Referensi ke TextMeshPro untuk menampilkan skor di Game Over

    private int currentHealth;  // HP saat ini

    void Start()
    {
        currentHealth = healthImages.Length;  // Set HP awal sesuai dengan jumlah gambar hati yang ada
        UpdateHealthUI();  // Update tampilan HP di UI
        gameOverCanvas.SetActive(false);  // Pastikan Game Over UI tidak terlihat saat awal permainan
    }

    // Fungsi untuk mengurangi HP dan memperbarui UI
    void ReduceHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth--;  // Kurangi HP
            UpdateHealthUI();  // Update tampilan UI HP
        }

        // Cek jika HP habis, maka game over
        if (currentHealth <= 0)
        {
            GameOver();  // Panggil fungsi Game Over
        }
    }

    // Update tampilan HP di UI (menyembunyikan gambar hati sesuai dengan HP yang tersisa)
    void UpdateHealthUI()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (i < currentHealth)
            {
                healthImages[i].SetActive(true);  // Tampilkan gambar hati
            }
            else
            {
                healthImages[i].SetActive(false);  // Sembunyikan gambar hati
            }
        }
    }

    // Fungsi untuk mengakhiri permainan dan menampilkan Game Over UI
    void GameOver()
    {
        // Menghentikan semua aktivitas (gerakan objek, fisika, dll.)
        Time.timeScale = 0;

        // Menampilkan Canvas Game Over
        gameOverCanvas.SetActive(true);

        // Menampilkan skor terakhir di Game Over screen
        DisplayFinalScore();
    }

    // Fungsi untuk menampilkan skor terakhir di Game Over
    void DisplayFinalScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + groceryListManager.score.ToString();
        }
    }

    // Ketika keranjang bersentuhan dengan item
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek jika objek yang ditabrak memiliki komponen "Item"
        if (collision.gameObject.CompareTag("Item"))
        {
            string itemName = collision.gameObject.name;
            itemName = itemName.Replace("(Clone)", "").Trim();  // Menghapus "(Clone)" jika ada

            // Jika item ada di grocery list dan belum dicoret
            if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName) && !groceryListManager.IsItemCaptured(itemName))
            {
                groceryListManager.AddScore(100);  // Tambah skor
                groceryListManager.MarkItemAsCaptured(itemName);  // Tandai item yang ditangkap
                PlayCorrectItemEffect();  // Mainkan efek partikel untuk item yang benar
            }
            else
            {
                // Jika item tidak ada di grocery list atau sudah dicoret, kurangi HP
                ReduceHealth();
                PlayWrongItemEffect();  // Mainkan efek partikel untuk item yang salah
            }

            Destroy(collision.gameObject);  // Hancurkan item setelah ditangkap
        }
    }

    // Fungsi untuk memainkan efek partikel untuk item yang benar
    void PlayCorrectItemEffect()
    {
        if (correctItemEffect != null)
        {
            correctItemEffect.Play();
        }
    }

    // Fungsi untuk memainkan efek partikel untuk item yang salah
    void PlayWrongItemEffect()
    {
        if (wrongItemEffect != null)
        {
            wrongItemEffect.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Pastikan ini ada untuk menggunakan TextMeshPro

public class GroceryListManager : MonoBehaviour
{
    public TextMeshProUGUI groceryListText;  // Referensi untuk grocery list UI
    public TextMeshProUGUI scoreText;  // Referensi untuk skor UI
    public int score = 0;  // Skor pemain
    private List<string> groceryList = new List<string>();  // Daftar grocery list
    private List<string> capturedItems = new List<string>();  // Daftar item yang sudah ditangkap

    void Start()
    {
        // Generate grocery list secara acak dan tampilkan di UI
        GenerateGroceryList();
        UpdateGroceryListUI();
        UpdateScoreUI();  // Memperbarui UI untuk skor saat pertama kali dijalankan
    }

    // Meng-generate grocery list secara acak (mengambil 3 item dari prefab di Resources/Prefabs)
    void GenerateGroceryList()
    {
        // Ambil semua prefab di folder Resources/Prefabs
        Object[] items = Resources.LoadAll("Prefabs", typeof(GameObject));  // Muat semua prefab dari folder Prefabs

        groceryList.Clear();  // Kosongkan grocery list sebelumnya

        // Pilih 3 item acak dari prefab yang ada di folder
        for (int i = 0; i < 3; i++)
        {
            // Pilih item acak dari array prefab yang dimuat
            GameObject randomItem = (GameObject)items[Random.Range(0, items.Length)];
            groceryList.Add(randomItem.name);  // Simpan nama item (misalnya: apple, banana)
        }
    }

    // Mengupdate UI grocery list dengan menambahkan strikethrough pada item yang sudah diambil
    void UpdateGroceryListUI()
    {
        groceryListText.text = "";  // Menghapus semua teks sebelumnya
        foreach (string item in groceryList)
        {
            if (capturedItems.Contains(item))
            {
                // Menambahkan strikethrough jika item sudah diambil
                groceryListText.text += "<s>" + item + "</s>\n";
            }
            else
            {
                groceryListText.text += item + "\n";
            }
        }
    }

    // Mengupdate UI skor
    void UpdateScoreUI()
    {
        // Memperbarui tampilan skor di UI
        scoreText.text = "Score: " + score.ToString();
    }

    // Cek apakah item ada dalam grocery list (case insensitive)
    public bool IsItemInGroceryList(string itemName)
    {
        // Menggunakan ToLower() untuk perbandingan case-insensitive
        foreach (string groceryItem in groceryList)
        {
            if (groceryItem.ToLower() == itemName.ToLower())  // Bandingkan tanpa memperhatikan huruf besar atau kecil
            {
                return true;
            }
        }
        return false;
    }

    // Fungsi untuk menambah skor
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();  // Memperbarui UI skor setiap kali skor bertambah
        Debug.Log("Skor: " + score);
    }

    // Fungsi untuk menandai item yang sudah diambil
    public void MarkItemAsCaptured(string itemName)
    {
        if (!capturedItems.Contains(itemName))
        {
            capturedItems.Add(itemName);
        }

        // Update UI setelah item ditandai
        UpdateGroceryListUI();
    }
}
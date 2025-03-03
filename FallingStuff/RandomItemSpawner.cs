// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// #if UNITY_EDITOR
// using UnityEditor;  // Menggunakan UnityEditor hanya di Editor
// #endif

// public class RandomItemSpawner : MonoBehaviour
// {
//     public string folderPath = "Assets/Resources/Prefabs"; // Path folder tempat prefab berada
//     public float spawnHeight = 10f; // Ketinggian spawn untuk objek yang jatuh
//     public float spawnInterval = 2f; // Interval waktu antar spawn
//     public Vector3 itemScale = new Vector3(0.5f, 0.5f, 0.5f); // Faktor skala yang ingin diterapkan pada objek yang jatuh

//     private List<GameObject> itemPrefabs = new List<GameObject>(); // Daftar prefab yang ditemukan
//     public GroceryListManager groceryListManager; // Referensi ke GroceryListManager

//     [Range(1, 10)]  // Membuat slider antara 1 hingga 10 yang dapat diatur dari Unity Inspector
//     public int groceryItemSpawnFrequency = 7;  // Semakin besar angka, semakin sering item grocery list muncul (1-10)

//     void Start()
//     {
//         // Mengambil semua prefab yang ada di folder
//         LoadItemPrefabs();

//         // Mulai spawn item secara acak
//         StartCoroutine(SpawnItemsRandomly());
//     }

//     // Mengambil semua prefab yang ada di folder
//     void LoadItemPrefabs()
//     {
//         itemPrefabs.Clear();

// #if UNITY_EDITOR
//         // Mengambil semua prefab dalam folder yang ditentukan hanya di editor
//         string[] prefabGUIDs = AssetDatabase.FindAssets("t:Prefab", new[] { folderPath });

//         foreach (string guid in prefabGUIDs)
//         {
//             string prefabPath = AssetDatabase.GUIDToAssetPath(guid);
//             GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            
//             if (prefab != null)
//             {
//                 itemPrefabs.Add(prefab); // Tambahkan prefab ke dalam daftar
//             }
//         }

//         // Jika tidak ada prefab yang ditemukan, berikan peringatan
//         if (itemPrefabs.Count == 0)
//         {
//             Debug.LogWarning("Tidak ada prefab ditemukan di folder: " + folderPath);
//         }
// #endif
//     }

//     // Coroutine untuk spawn item secara acak
//     IEnumerator SpawnItemsRandomly()
//     {
//         while (true)
//         {
//             // Pilih prefab dengan probabilitas lebih besar pada item yang ada di grocery list
//             GameObject itemToSpawn = GetItemToSpawn();

//             // Tentukan posisi spawn secara acak
//             float randomX = Random.Range(-5f, 5f); // Rentang X acak
//             Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

//             // Spawn item dan beri Rigidbody2D agar bisa jatuh
//             GameObject spawnedItem = Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);

//             // Tambahkan Rigidbody2D jika belum ada
//             if (spawnedItem.GetComponent<Rigidbody2D>() == null)
//             {
//                 spawnedItem.AddComponent<Rigidbody2D>();
//             }

//             // Set scale (ukurannya) menjadi lebih kecil
//             spawnedItem.transform.localScale = itemScale;  // Mengatur skala objek yang baru di-spawn

//             // Tunggu beberapa detik sebelum spawn item berikutnya
//             yield return new WaitForSeconds(spawnInterval);
//         }
//     }

//     // Fungsi untuk memilih item untuk di-spawn
//     GameObject GetItemToSpawn()
//     {
//         // Pertama, filter item yang ada dalam grocery list
//         List<GameObject> groceryListItems = new List<GameObject>();

//         foreach (GameObject prefab in itemPrefabs)
//         {
//             string itemName = prefab.name.ToLower();
//             if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName))
//             {
//                 groceryListItems.Add(prefab); // Tambahkan item dari grocery list
//             }
//         }

//         // Jika ada item dalam grocery list, pilih salah satu secara acak dengan probabilitas lebih tinggi
//         if (groceryListItems.Count > 0 && Random.Range(0f, 10f) < groceryItemSpawnFrequency)  // Menggunakan nilai slider untuk frekuensi
//         {
//             return groceryListItems[Random.Range(0, groceryListItems.Count)];
//         }
        
//         // Jika tidak, pilih item secara acak dari semua item yang ada
//         return itemPrefabs[Random.Range(0, itemPrefabs.Count)];
//     }
// }


////
//Android Build
////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawner : MonoBehaviour
{
    public string folderPath = "Prefabs/"; // Path folder dalam Resources tanpa "Assets/Resources"
    public float spawnHeight = 10f; // Ketinggian spawn untuk objek yang jatuh
    public float spawnInterval = 2f; // Interval waktu antar spawn
    public Vector3 itemScale = new Vector3(0.5f, 0.5f, 0.5f); // Faktor skala yang ingin diterapkan pada objek yang jatuh

    private List<GameObject> itemPrefabs = new List<GameObject>(); // Daftar prefab yang ditemukan
    public GroceryListManager groceryListManager; // Referensi ke GroceryListManager

    [Range(1, 10)]  // Membuat slider antara 1 hingga 10 yang dapat diatur dari Unity Inspector
    public int groceryItemSpawnFrequency = 7;  // Semakin besar angka, semakin sering item grocery list muncul (1-10)

    void Start()
    {
        // Mengambil semua prefab yang ada di folder
        LoadItemPrefabs();

        // Mulai spawn item secara acak
        StartCoroutine(SpawnItemsRandomly());
    }

    // Mengambil semua prefab yang ada di folder menggunakan Resources.Load
    void LoadItemPrefabs()
    {
        itemPrefabs.Clear();

        // Mengambil semua prefab dalam folder yang ditentukan dari Resources
        GameObject[] prefabsInFolder = Resources.LoadAll<GameObject>(folderPath); // Load semua prefab dari folder

        foreach (GameObject prefab in prefabsInFolder)
        {
            if (prefab != null)
            {
                itemPrefabs.Add(prefab); // Tambahkan prefab ke dalam daftar
            }
        }

        // Jika tidak ada prefab yang ditemukan, berikan peringatan
        if (itemPrefabs.Count == 0)
        {
            Debug.LogWarning("Tidak ada prefab ditemukan di folder: " + folderPath);
        }
    }

    // Coroutine untuk spawn item secara acak
    IEnumerator SpawnItemsRandomly()
    {
        while (true)
        {
            // Pilih prefab dengan probabilitas lebih besar pada item yang ada di grocery list
            GameObject itemToSpawn = GetItemToSpawn();

            if (itemToSpawn == null)
            {
                yield break; // Jika tidak ada item untuk spawn, berhenti
            }

            // Tentukan posisi spawn secara acak
            float randomX = Random.Range(-5f, 5f); // Rentang X acak
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

            // Spawn item dan beri Rigidbody2D agar bisa jatuh
            GameObject spawnedItem = Instantiate(itemToSpawn, spawnPosition, Quaternion.identity);

            // Tambahkan Rigidbody2D jika belum ada
            if (spawnedItem.GetComponent<Rigidbody2D>() == null)
            {
                spawnedItem.AddComponent<Rigidbody2D>();
            }

            // Set scale (ukurannya) menjadi lebih kecil
            spawnedItem.transform.localScale = itemScale;  // Mengatur skala objek yang baru di-spawn

            // Tunggu beberapa detik sebelum spawn item berikutnya
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Fungsi untuk memilih item untuk di-spawn
    GameObject GetItemToSpawn()
    {
        // Pertama, filter item yang ada dalam grocery list
        List<GameObject> groceryListItems = new List<GameObject>();

        foreach (GameObject prefab in itemPrefabs)
        {
            string itemName = prefab.name.ToLower();
            if (groceryListManager != null && groceryListManager.IsItemInGroceryList(itemName))
            {
                groceryListItems.Add(prefab); // Tambahkan item dari grocery list
            }
        }

        // Jika ada item dalam grocery list, pilih salah satu secara acak dengan probabilitas lebih tinggi
        if (groceryListItems.Count > 0 && Random.Range(0f, 10f) < groceryItemSpawnFrequency)  // Menggunakan nilai slider untuk frekuensi
        {
            return groceryListItems[Random.Range(0, groceryListItems.Count)];
        }
        else
        {
            // Jika groceryListItems kosong atau tidak memenuhi frekuensi, pilih item secara acak dari semua item yang ada
            if (itemPrefabs.Count > 0)
            {
                return itemPrefabs[Random.Range(0, itemPrefabs.Count)];
            }
            else
            {
                Debug.LogError("Tidak ada prefab yang tersedia untuk di-spawn.");
                return null;  // Atau Anda bisa memilih item default atau menangani situasi ini sesuai kebutuhan
            }
        }
    }
}


using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Untuk menggunakan Slider
using TMPro;  // Untuk menggunakan TextMeshPro

public class XPLevelManager : MonoBehaviour
{
    public Slider xpBar;  // Referensi ke Slider sebagai XP progress bar
    public TextMeshProUGUI levelText;  // Referensi ke Text untuk menampilkan level
    public int currentXP = 0;  // XP saat ini
    public int maxXP = 50;  // XP maksimal untuk naik level
    public int currentLevel = 0;  // Level saat ini
    public float xpBarSpeed = 0.5f;  // Kecepatan bar bertambah (smooth animation)

    public GroceryListManager groceryListManager;  // Referensi ke GroceryListManager

    private bool isLevelUpReady = false;  // Flag untuk menandakan bahwa level up sudah siap

    // Update level UI dan XP
    void Start()
    {
        UpdateLevelUI();
        UpdateItemCountForLevel();  // Update itemCount untuk level 0 pada awal permainan
    }

    // Fungsi untuk menambah XP
    public void AddXP(int xp)
    {
        currentXP += xp;

        // Jika XP sudah cukup untuk naik level, tandai untuk level up
        if (currentXP >= maxXP)
        {
            isLevelUpReady = true;
        }

        // Update XP bar dengan animasi smooth
        StartCoroutine(UpdateXPBarSmoothly());
    }

    // Fungsi untuk animasi smooth pada XP bar
    IEnumerator UpdateXPBarSmoothly()
    {
        float targetValue = (float)currentXP / maxXP;
        float currentValue = xpBar.value;

        // Update XP bar secara smooth hingga mencapai targetValue
        while (Mathf.Abs(currentValue - targetValue) > 0.01f)
        {
            currentValue = Mathf.Lerp(currentValue, targetValue, xpBarSpeed * Time.deltaTime);
            xpBar.value = currentValue;
            yield return null;
        }

        xpBar.value = targetValue;  // Pastikan bar berhenti di nilai target

        // Jika XP bar sudah penuh dan level up sudah siap, naik level
        if (isLevelUpReady && Mathf.Approximately(xpBar.value, 1f))
        {
            LevelUp();  // Naik level setelah XP bar penuh
        }
    }

    // Fungsi untuk level up
    void LevelUp()
    {
        currentLevel++;
        UpdateLevelUI();
        Debug.Log("Level Up! New Level: " + currentLevel);

        // Update itemCount di GroceryListManager berdasarkan level
        UpdateItemCountForLevel();

        // Reset XP untuk level selanjutnya
        currentXP = 0;

        // Reset flag isLevelUpReady setelah level up
        isLevelUpReady = false;

        // Pastikan XP bar dimulai dari 0 untuk level berikutnya
        StartCoroutine(UpdateXPBarSmoothly());
    }

    // Update UI level
    void UpdateLevelUI()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }

    // Update itemCount di GroceryListManager berdasarkan level
    private void UpdateItemCountForLevel()
    {
        if (groceryListManager != null)
        {
            groceryListManager.itemCount = 2 + currentLevel;  // Mulai dari 2 pada level 0, dan bertambah 1 setiap level
            Debug.Log("Item Count updated to: " + groceryListManager.itemCount);
        }
    }

    // Fungsi untuk mendapatkan level saat ini
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}

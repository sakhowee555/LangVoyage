using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPManager : MonoBehaviour
{
    // ทำให้สคริปต์นี้เรียกใช้ได้จากที่อื่น
    public static XPManager Instance;

    [Header("ข้อมูล XP")]
    public int level = 1;         // เลเวลเริ่มต้น
    public int currentXP = 0;     // XP ปัจจุบัน
    public int xpToNextLevel = 100; // XP ที่ต้องใช้เพื่อเลื่อนเลเวล

    [Header("UI")]
    public Slider xpSlider;               // แถบ XP
    public TextMeshProUGUI levelText;     // ข้อความ Lv 1

    private void Awake()
    {
        // ให้ XPManager อยู่แค่ตัวเดียว
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        LoadXP(); // โหลดข้อมูล XP ที่เคยบันทึกไว้
    }

    private void Start()
    {
        UpdateUI();
    }

    // 📈 ฟังก์ชันเพิ่ม XP
    public void AddXP(int amount)
    {
        currentXP += amount;
        Debug.Log("ได้ XP: " + amount);

        // ถ้า XP ถึงเป้า → เลเวลอัป
        if (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }

        UpdateUI();
        SaveXP();
    }

    // 🚀 ฟังก์ชันเลื่อนเลเวล
    private void LevelUp()
    {
        level++;
        xpToNextLevel += 50; // แต่ละเลเวลใช้ XP เพิ่มอีก 50 (ปรับได้)
        Debug.Log("🎉 เลเวลอัป! ตอนนี้เลเวล: " + level);
    }

    // 🧾 อัปเดตแถบ XP และข้อความบนหน้าจอ
    private void UpdateUI()
    {
        if (xpSlider != null)
        {
            xpSlider.maxValue = xpToNextLevel;
            xpSlider.value = currentXP;
        }

        if (levelText != null)
        {
            levelText.text = "Lv " + level.ToString();
        }
    }
    private void Update()
    {
        // ทดสอบ: กด X เพื่อได้ XP
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddXP(20); // ได้ XP 20 ทุกครั้งที่กด
        }
    }


    // 💾 บันทึก XP
    private void SaveXP()
    {
        PlayerPrefs.SetInt("player_level", level);
        PlayerPrefs.SetInt("player_xp", currentXP);
        PlayerPrefs.SetInt("player_next", xpToNextLevel);
    }

    // 📂 โหลด XP ตอนเปิดเกม
    private void LoadXP()
    {
        level = PlayerPrefs.GetInt("player_level", 1);
        currentXP = PlayerPrefs.GetInt("player_xp", 0);
        xpToNextLevel = PlayerPrefs.GetInt("player_next", 100);
    }
}

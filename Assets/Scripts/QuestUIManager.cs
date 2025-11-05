using UnityEngine;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager Instance; // ใช้เรียกง่าย ๆ จากที่อื่น
    public TextMeshProUGUI questText;

    private void Awake()
    {
        // ทำให้ตัวนี้อยู่ได้ตัวเดียวในฉาก
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (questText != null)
        {
            questText.text = "❏ Find local people in England"; // เควสเริ่มต้น
        }
    }

    public void CompleteQuest()
    {
        if (questText != null)
        {
            questText.text = "✅ Talked to the local person (Completed)";
            Debug.Log("Quest Completed!");
        }
    }
}

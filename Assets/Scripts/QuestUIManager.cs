using UnityEngine;
using TMPro; // สำคัญมาก ต้องมีบรรทัดนี้!

public class QuestUIManager : MonoBehaviour
{
    public TextMeshProUGUI questText;  // <-- ต้องเป็นแบบนี้นะ

    void Start()
    {
        questText.text = "🧭 ภารกิจ:\n- ยังไม่มีภารกิจในตอนนี้";
    }

    public void SetQuest(string newQuest)
    {
        questText.text = "🧭 ภารกิจ:\n- " + newQuest;
    }
}

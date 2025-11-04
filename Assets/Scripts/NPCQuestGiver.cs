using UnityEngine;

public class NPCQuestGiver : MonoBehaviour
{
    public Quest quest;

    public void GiveQuest(PlayerData player)
    {
        if (player.activeQuest == null)
        {
            player.activeQuest = quest;
            Debug.Log("ภารกิจได้รับ: ไปคุยกับ " + quest.targetNPCName);
        }
    }
}

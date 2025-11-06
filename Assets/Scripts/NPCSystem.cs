using UnityEngine;
using TMPro; // 👈 เพิ่มบรรทัดนี้

public class NPCSystem : MonoBehaviour
{
    public string npcName = "Local Villager";
    public string[] dialogueLines;
    private int currentLine = 0;
    private bool playerInRange = false;

    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;   // 👈 ใช้ TMP
    public TextMeshProUGUI npcNameText;    // 👈 ใช้ TMP

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!dialogueUI.activeSelf)
            {
                dialogueUI.SetActive(true);
                npcNameText.text = npcName;
                dialogueText.text = dialogueLines[currentLine];
            }
            else
            {
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    dialogueText.text = dialogueLines[currentLine];
                }
                else
                {
                    dialogueUI.SetActive(false);
                    currentLine = 0;

                    FindObjectOfType<XPManager>().AddXP(50);
                    print("Player got 50 XP from NPC!");
                }
            }
        }
        void Update()
        {
            // ถ้า UI ถูกเปิดจากที่อื่นให้ปิดก่อน (debug)
            // Debug: show current state
            // Debug.Log("playerInRange = " + playerInRange);

            if (playerInRange && Input.GetKeyDown(KeyCode.F))
            {
                // handle dialogue open/next
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"NPC OnTriggerEnter: name='{other.name}' tag='{other.tag}' layer='{LayerMask.LayerToName(other.gameObject.layer)}' isTrigger={other.isTrigger}");
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("NPC: Player detected -> playerInRange = true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"NPC OnTriggerExit: name='{other.name}' tag='{other.tag}' layer='{LayerMask.LayerToName(other.gameObject.layer)}' isTrigger={other.isTrigger}");
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("NPC: Player left -> playerInRange = false");
        }
    }
}

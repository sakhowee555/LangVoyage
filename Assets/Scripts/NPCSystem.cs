using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject dialogueUI;              // กล่องบทสนทนา (DialogueUI)
    public TextMeshProUGUI nameText;           // ช่องชื่อ NPC
    public TextMeshProUGUI dialogueText;       // ช่องข้อความคุย
    public TextMeshProUGUI pressFText;         // "Press F to talk" กลางจอ

    private bool playerInRange = false;
    private bool dialogueActive = false;

    void Start()
    {
        // ปิด UI ทุกอย่างตอนเริ่มเกม
        if (dialogueUI != null)
            dialogueUI.SetActive(false);

        if (pressFText != null)
            pressFText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange)
        {
            // แสดงข้อความกด F เมื่ออยู่ใกล้
            pressFText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!dialogueActive)
                    StartDialogue();
                else
                    EndDialogue();
            }
        }
        else
        {
            pressFText.gameObject.SetActive(false);
        }
    }

    private void StartDialogue()
    {
        dialogueActive = true;
        dialogueUI.SetActive(true); // เปิด UI คุย
        nameText.text = "Local Person"; // ชื่อ NPC
        dialogueText.text = "Hello! Welcome to our town. Let's learn some English words!";
        pressFText.gameObject.SetActive(false); // ซ่อน Press F
    }

    private void EndDialogue()
    {
        dialogueActive = false;
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueUI.SetActive(false);
            dialogueActive = false;
        }
    }
}

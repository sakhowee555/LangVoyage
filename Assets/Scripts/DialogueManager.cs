using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (dialogueUI != null) dialogueUI.SetActive(false);
    }

    public void ShowDialogue(string npcName, string line)
    {
        if (dialogueUI == null) return;
        nameText.text = npcName;
        contentText.text = line;
        dialogueUI.SetActive(true);
    }

    public void HideDialogue()
    {
        if (dialogueUI == null) return;
        dialogueUI.SetActive(false);
    }
}

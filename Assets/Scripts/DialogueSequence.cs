using UnityEngine;

public class DialogueSequence : MonoBehaviour
{
    public string npcName = "MentorNPC";
    public GameObject dialoguePanel;
    public TMPro.TextMeshProUGUI dialogueText;
    public TMPro.TMP_InputField inputField;
    public GameObject yesNoPanel;
    public Transform classroomSpawnPoint;
    public GameObject player;

    private int step = 0;
    private PlayerData playerData;

    public void StartDialogue(PlayerData player)
    {
        playerData = player;
        step = 0;
        dialoguePanel.SetActive(true);
        ShowNext();
    }

    public void OnSubmitInput()
    {
        if (step == 0)
        {
            playerData.playerName = inputField.text;
            step++;
            ShowNext();
        }
        else if (step == 1)
        {
            step++;
            ShowNext();
        }
    }

    public void OnAnswerYes()
    {
        step++;
        ShowNext();
        player.transform.position = classroomSpawnPoint.position;
    }

    public void OnAnswerNo()
    {
        dialogueText.text = "ไว้โอกาสหน้านะ!";
        yesNoPanel.SetActive(false);
    }

    void ShowNext()
    {
        inputField.gameObject.SetActive(false);
        yesNoPanel.SetActive(false);

        switch (step)
        {
            case 0:
                dialogueText.text = "Who are you?";
                inputField.text = "";
                inputField.gameObject.SetActive(true);
                break;
            case 1:
                dialogueText.text = "คุณมาทำอะไรที่นี่?";
                inputField.text = "";
                inputField.gameObject.SetActive(true);
                break;
            case 2:
                dialogueText.text = "คุณต้องการอัปสกิลด้านภาษาไหม?";
                yesNoPanel.SetActive(true);
                break;
            case 3:
                dialoguePanel.SetActive(false);
                break;
        }
    }
}

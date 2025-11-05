using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    private bool player_detection = false;

    void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (player_detection)
        {
            if (interactText != null && !interactText.gameObject.activeSelf)
                interactText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("NPCSystem: Player pressed F while in range.");

                // ✅ เมื่อคุยเสร็จ ให้แจ้งว่าเควสเสร็จ
                if (QuestUIManager.Instance != null)
                    QuestUIManager.Instance.CompleteQuest();
            }
        }
        else
        {
            if (interactText != null && interactText.gameObject.activeSelf)
                interactText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            player_detection = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            player_detection = false;
    }
}

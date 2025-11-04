using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public TextMeshProUGUI interactText; // ลาก TextMeshPro ของ UI มาที่นี่ใน Inspector

    private bool player_detection = false;

    void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false); // เริ่มปิดไว้
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
                // ใส่โค้ดเปิดบทสนทนา / ให้ภารกิจ ฯลฯ ที่นี่
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
        Debug.Log("OnTriggerEnter with: " + other.name + " tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            player_detection = true;
            Debug.Log("Player detected - set player_detection true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit with: " + other.name + " tag: " + other.tag);
        if (other.CompareTag("Player"))
        {
            player_detection = false;
            Debug.Log("Player left - set player_detection false");
        }
    }
}

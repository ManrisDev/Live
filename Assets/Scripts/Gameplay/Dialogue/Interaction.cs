using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Animator interactionAnimator;
    [SerializeField] private GameObject anekdotAudioSource;
    [SerializeField] private Dialogue dialogue;

    private string intObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            intObj = "Player";
            interactionAnimator.SetBool("UseOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intObj = null;
        interactionAnimator.SetBool("UseOpen", false);
    }

    private void Update()
    {
        if (intObj == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                interactionAnimator.SetBool("UseOpen", false);
                anekdotAudioSource.SetActive(true);
            }
        }
    }
}

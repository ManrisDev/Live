using UnityEngine;

public class PatchInteraction : MonoBehaviour
{
    [SerializeField] private Animator interactionTextAnimator;
    [SerializeField] private Animator patchAnimator;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private GameObject trigger;

    private string intObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            intObj = "Player";
            interactionTextAnimator.SetBool("UseOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        intObj = null;
        interactionTextAnimator.SetBool("UseOpen", false);
    }

    private void Update()
    {
        if (intObj == "Player")
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Patch();
                Destroy(this.gameObject);
                interactionTextAnimator.SetBool("UseOpen", false);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }

    private void Patch()
    {
        patchAnimator.SetBool("patchUse", true);
    }
}

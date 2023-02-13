using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Hero movement;
    [SerializeField] private Animator playerAnimator;

    [Header("Dialogue")]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image dialogueIcon;
    [SerializeField] private Animator dialogueAnimator;
    [SerializeField] private Queue<Sprite> dialogueSprite;
    [SerializeField] private GameObject anekdotAudioSource;

    [Header("Game Manager")]
    [SerializeField] private GameManager gameManager;

    private Queue<string> Sentences;
    private Queue<string> Name;

    private States State
    {
        get { return (States)playerAnimator.GetInteger("state"); }
        set { playerAnimator.SetInteger("state", (int)value); }
    }

    void Start()
    {
        Sentences = new Queue<string>();
        Name = new Queue<string>();
        dialogueSprite = new Queue<Sprite>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueAnimator.SetBool("IsOpen", true);
        State = States.idle;
        movement.enabled = false;
        Sentences.Clear();
        Name.Clear();
        dialogueSprite.Clear();

        foreach (Sprite head in dialogue.head)
        {
            dialogueSprite.Enqueue(head);
        }

        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.name)
        {
            Name.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = Sentences.Dequeue();
        string name = Name.Dequeue();
        Sprite head = dialogueSprite.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, name, head));
    }

    IEnumerator TypeSentence(string sentence, string name, Sprite head)
    {
        dialogueText.text = "";
        nameText.text = name;
        dialogueIcon.sprite = head;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        movement.enabled = true;
        anekdotAudioSource.SetActive(false);
        dialogueAnimator.SetBool("IsOpen", false);
    }
}

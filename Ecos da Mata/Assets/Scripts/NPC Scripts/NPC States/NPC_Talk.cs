using UnityEngine;
using System.Collections.Generic;


public class NPC_Talk : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public Animator interactAnim;

    public List<DialogueSO> conversations;
    public DialogueSO currentConversation;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        anim.Play("Idle");
        interactAnim.Play("Open");
    }


    private void OnDisable()
    {
        interactAnim.Play("Close");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

   private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (DialogueManager.Instance.isDialogueActive)
            {
                DialogueManager.Instance.AdvanceDialogue();
                
                // Som ao avançar fala
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayUIClick();
            }
            else
            {
                CheckForNewConversation();
                DialogueManager.Instance.StartDialogue(currentConversation);

                // Som ao começar conversa
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayUIClick();
            }
        }
    }


    private void CheckForNewConversation()
    {
        for (int i = 0; i < conversations.Count; i++)
        {
            var convo = conversations[i];
            if (convo != null && convo.isConditionMet())
            {
                conversations.RemoveAt(i);
                currentConversation = convo;
            }
        }
    }
}



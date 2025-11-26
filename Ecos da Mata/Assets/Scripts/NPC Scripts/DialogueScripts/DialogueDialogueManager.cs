using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI References")]
    public CanvasGroup canvasGroup;
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    public Button[] choiceButtons;

    public bool isDialogueActive;

    private DialogueSO currentDialogue;
    private int dialogueIndex;

    // >>> NOVO: eventos e último speaker
    public event Action<DialogueSO> OnDialogueStarted;
    public event Action<DialogueSO> OnDialogueEnded;

    private ActorSO lastSpeaker;
    public ActorSO LastSpeaker => lastSpeaker;
    // <<<

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        foreach (var Button in choiceButtons)
            Button.gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        currentDialogue = dialogueSO;
        dialogueIndex = 0;
        isDialogueActive = true;

        // >>> NOVO: evento de início
        OnDialogueStarted?.Invoke(currentDialogue);
        // <<<

        ShowDialogue();
    }

    public void AdvanceDialogue()
    {
        if (dialogueIndex < currentDialogue.lines.Length)
            ShowDialogue();
        else
            ShowChoises();
    }

    private void ShowDialogue()
    {
        DialogueLine line = currentDialogue.lines[dialogueIndex];

        DialogueHistoryTracker.Instance.RecordNPC(line.speaker);
        // >>> NOVO: guarda quem falou por último
        lastSpeaker = line.speaker;
        // <<<

        portrait.sprite = line.speaker.portrait;
        actorName.text = line.speaker.actorName;

        dialogueText.text = line.text;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        dialogueIndex++;
    }

    private void ShowChoises()
    {
        ClearChoices();
        if (currentDialogue.options.Length > 0)
        {
            for (int i = 0; i < currentDialogue.options.Length; i++)
            {
                var option = currentDialogue.options[i];

                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = option.optionText;
                choiceButtons[i].gameObject.SetActive(true);

                choiceButtons[i].onClick.AddListener(() => ChooseOption(option.nextDialogue));
            }
        }
        else
        {
            choiceButtons[0].GetComponentInChildren<TMP_Text>().text = "End";
            choiceButtons[0].onClick.AddListener(EndDialogue);
            choiceButtons[0].gameObject.SetActive(true);
        }
    }

    private void ChooseOption(DialogueSO dialogueSO)
    {
        if (dialogueSO == null)
            EndDialogue();
        else
        {
            ClearChoices();
            StartDialogue(dialogueSO);
        }
    }

    private void EndDialogue()
    {
        // dispara o evento antes de limpar o currentDialogue
        OnDialogueEnded?.Invoke(currentDialogue);

        dialogueIndex = 0;
        isDialogueActive = false;
        currentDialogue = null;
        lastSpeaker = null;

        ClearChoices();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }


    private void ClearChoices()
    {
        foreach (var Button in choiceButtons)
        {
            Button.gameObject.SetActive(false);
            Button.onClick.RemoveAllListeners();
        }
    }
}

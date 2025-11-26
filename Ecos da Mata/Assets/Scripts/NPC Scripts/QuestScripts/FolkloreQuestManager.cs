using System;
using System.Collections.Generic;
using UnityEngine;

public class FolkloreQuestManager : MonoBehaviour
{
    public static FolkloreQuestManager Instance { get; private set; }

    [Header("Configuração da Quest")]
    [SerializeField] private LocationSO forceQuestStartLocation;
    [SerializeField] private DialogueSO questStartDialogue; // diálogo do NPC que te dá a missão
    [SerializeField] private string questTitle = "Histórias do Folclore";

    [Tooltip("NPCs que contam como pontos de interesse (padre, etc.)")]
    [SerializeField] private ActorSO[] pontosDeInteresseNPCs;

    [Tooltip("Locais especiais (igreja, cachoeira, floresta, etc.)")]
    [SerializeField] private LocationSO[] pontosDeInteresseLocais;

    

    public bool IsActive { get; private set; }
    public bool IsCompleted { get; private set; }

    private HashSet<ActorSO> npcsDescobertos = new HashSet<ActorSO>();
    private HashSet<LocationSO> locaisDescobertos = new HashSet<LocationSO>();
    private bool isSubscribed = false;

    public int TotalPontos => pontosDeInteresseNPCs.Length + pontosDeInteresseLocais.Length;
    public int PontosDescobertos => npcsDescobertos.Count + locaisDescobertos.Count;

    public event Action<FolkloreQuestManager> OnQuestAtualizada;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        TrySubscribe();
    }

    private void Start()
    {
        // caso o DialogueManager seja criado depois do OnEnable
        TrySubscribe();
    }

    private void Update()
    {
        // se ainda não inscreveu, fica tentando até o DialogueManager existir
        if (!isSubscribed)
            TrySubscribe();
    }

    private void OnDisable()
    {
        if (DialogueManager.Instance != null && isSubscribed)
        {
            DialogueManager.Instance.OnDialogueEnded -= HandleDialogueEnded;
        }

        isSubscribed = false;
    }

    private void TrySubscribe()
    {
        if (isSubscribed) return;
        if (DialogueManager.Instance == null) return;

        DialogueManager.Instance.OnDialogueEnded += HandleDialogueEnded;
        isSubscribed = true;

        Debug.Log("[FolkloreQuest] Inscrito no OnDialogueEnded");
    }


    public void StartQuest()
    {
        if (IsActive) return;

        IsActive = true;
        IsCompleted = false;
        npcsDescobertos.Clear();
        locaisDescobertos.Clear();

        DispararAtualizacao();
        Debug.Log($"Quest '{questTitle}' iniciada!");
    }

    private void HandleDialogueEnded(DialogueSO endedDialogue)
    {
        Debug.Log("[FolkloreQuest] Diálogo encerrado: " + (endedDialogue != null ? endedDialogue.name : "null"));

        // se ainda não começou e esse é o diálogo configurado, inicia a quest
        if (!IsActive && endedDialogue == questStartDialogue)
        {
            StartQuest();
        }

        if (!IsActive || IsCompleted)
            return;

        var npc = DialogueManager.Instance.LastSpeaker;
        if (npc != null)
        {
            RegistrarNPC(npc);
        }
    }


    public void RegistrarNPC(ActorSO actor)
    {
        if (!Array.Exists(pontosDeInteresseNPCs, a => a == actor))
            return;

        if (npcsDescobertos.Contains(actor))
            return;

        npcsDescobertos.Add(actor);
        Debug.Log($"Ponto de interesse NPC descoberto: {actor.actorName} ({PontosDescobertos}/{TotalPontos})");

        VerificarCompleto();
    }

    public void NotifyLocationVisited(LocationSO location)
    {
        // Se a quest já estiver ativa, não precisa fazer nada
        if (IsActive) return;

        if (location == forceQuestStartLocation)
        {
            Debug.Log($"[FolkloreQuest] Quest iniciada pelo local: {location.displayName}");
            StartQuest();
        }
}



    public void RegistrarLocal(LocationSO location)
    {
        if (!Array.Exists(pontosDeInteresseLocais, l => l == location))
            return;

        if (locaisDescobertos.Contains(location))
            return;

        locaisDescobertos.Add(location);
        Debug.Log($"Ponto de interesse local descoberto: {location.displayName} ({PontosDescobertos}/{TotalPontos})");

        VerificarCompleto();
    }

    private void VerificarCompleto()
    {
        if (PontosDescobertos >= TotalPontos)
        {
            IsCompleted = true;
            Debug.Log($"Quest '{questTitle}' COMPLETA!");
        }

        DispararAtualizacao();
    }

    private void DispararAtualizacao()
    {
        OnQuestAtualizada?.Invoke(this);
    }
}

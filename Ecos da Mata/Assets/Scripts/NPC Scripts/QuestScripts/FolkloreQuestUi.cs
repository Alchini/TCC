using TMPro;
using UnityEngine;

public class FolkloreQuestUI : MonoBehaviour
{
    [SerializeField] private TMP_Text questText;


    private void OnEnable()
    {
        // Se o manager já existir, inscreve no evento
        if (FolkloreQuestManager.Instance != null)
        {
            FolkloreQuestManager.Instance.OnQuestAtualizada += AtualizarUI;
            // Atualiza uma vez ao habilitar
            AtualizarUI(FolkloreQuestManager.Instance);
        }
    }

    private void OnDisable()
    {
        if (FolkloreQuestManager.Instance != null)
        {
            FolkloreQuestManager.Instance.OnQuestAtualizada -= AtualizarUI;
        }
    }

    private void Start()
    {
        // Caso o OnEnable tenha rodado antes do FolkloreQuestManager acordar
        if (FolkloreQuestManager.Instance != null)
        {
            FolkloreQuestManager.Instance.OnQuestAtualizada += AtualizarUI;
            AtualizarUI(FolkloreQuestManager.Instance);
        }
    }

    private void AtualizarUI(FolkloreQuestManager quest)
    {
        // Se a quest ainda não começou, pode esconder ou deixar vazio
        if (!quest.IsActive)
        {
            questText.text = ""; // ou "Fale com Ubirajara para começar a missão"
            return;
        }

        // Texto básico de progresso
        questText.text = $"Histórias do Folclore: {quest.PontosDescobertos}/{quest.TotalPontos}";

        // Se quiser destacar quando completar:
        if (quest.IsCompleted)
        {
            questText.text += "  (Completas!)";
        }
    }
}

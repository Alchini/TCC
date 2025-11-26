using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private GameObject startMenuPanel;        // painel do menu
    [SerializeField] private CanvasGroup menuCanvasGroup;      // CanvasGroup do painel
    [SerializeField] private PlayerMovement playerMovement;    // script do player

    [Header("Opções")]
    [SerializeField] private bool pauseTimeWhileMenu = true;
    [SerializeField] private float fadeDuration = 1f;

    private bool gameStarted = false;

    private void Start()
    {
        // Garante que o menu apareça no começo
        if (startMenuPanel != null)
            startMenuPanel.SetActive(true);

        if (menuCanvasGroup != null)
        {
            menuCanvasGroup.alpha = 1f;
            menuCanvasGroup.interactable = true;
            menuCanvasGroup.blocksRaycasts = true;
        }

        // Desabilita o movimento do player enquanto o menu está aberto
        if (playerMovement != null)
            playerMovement.enabled = false;

        // Opcional: pausa o tempo do jogo enquanto está no menu
        if (pauseTimeWhileMenu)
            Time.timeScale = 1f;
    }

    public void OnClickStartGame()
    {
        if (gameStarted) return;
        gameStarted = true;

        // Se quiser tocar um som extra aqui (além do UIButtonSound), pode:
        // AudioManager.Instance?.PlayUIClick();

        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine()
    {
        // Faz o fade usando unscaledDeltaTime (funciona mesmo com Time.timeScale = 0)
        if (menuCanvasGroup != null)
        {
            float t = 0f;
            float startAlpha = menuCanvasGroup.alpha;
            float endAlpha = 0f;

            // Enquanto faz o fade, mantém bloqueando interação
            menuCanvasGroup.interactable = false;
            menuCanvasGroup.blocksRaycasts = true;

            while (t < fadeDuration)
            {
                t += Time.unscaledDeltaTime;
                float lerp = Mathf.Clamp01(t / fadeDuration);
                menuCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, lerp);
                yield return null;
            }

            menuCanvasGroup.alpha = 0f;
            menuCanvasGroup.blocksRaycasts = false;
        }

        // Agora some com o painel (opcional, mas bom)
        if (startMenuPanel != null)
            startMenuPanel.SetActive(false);

        // Reativa movimento do player
        if (playerMovement != null)
            playerMovement.enabled = true;

        // Volta o tempo ao normal
        if (pauseTimeWhileMenu)
            Time.timeScale = 1f;
    }
}

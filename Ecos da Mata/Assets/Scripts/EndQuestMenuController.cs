using UnityEngine;

public class EndQuestMenuController : MonoBehaviour
{
    public static EndQuestMenuController Instance;

    [SerializeField] private GameObject menuFinalObj;

    private void Awake()
    {
        Instance = this;
        menuFinalObj.SetActive(false);
    }

    public void Show()
    {
        menuFinalObj.SetActive(true);
    }

    // Chamado pelo botão
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

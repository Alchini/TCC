using UnityEngine;

public class InteracaoProximidade : MonoBehaviour
{
    private bool jogadorProximo = false;
    public Animator objetoAnimator;

    void Update()
    {
        if (jogadorProximo && Input.GetKeyDown(KeyCode.E))
        {
            ExecutarInteracao();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = true;
            Debug.Log("Jogador pode interagir");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = false;
            Debug.Log("Jogador saiu da área de interação");
        }
    }

    void ExecutarInteracao()
    {
        if (objetoAnimator != null)
        {
            objetoAnimator.SetTrigger("CalicePress");
            Debug.Log("Trigger CalicePress ativado no outro objeto!");
        }
        else
        {
            Debug.LogWarning("Animator de destino não atribuído!");
        }
    }
}

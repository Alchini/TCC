using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayUIHover();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayUIClick();
    }
}

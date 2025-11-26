using UnityEngine;

public class LocationVisitedTrigger : MonoBehaviour
{
    [SerializeField] private LocationSO locationvisited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LocationHistoryTracker.Instance.RecordLocation(locationvisited);

            // >>> NOVO: avisar o FolkloreQuestManager
            if (FolkloreQuestManager.Instance != null)
            {
                FolkloreQuestManager.Instance.NotifyLocationVisited(locationvisited);
            }
            // <<<

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.OnLocationEntered(locationvisited);
            }
        }
    }
}

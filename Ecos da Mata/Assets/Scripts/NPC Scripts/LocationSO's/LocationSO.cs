using UnityEngine;

[CreateAssetMenu(menuName = "LocationSO")]
public class LocationSO : ScriptableObject
{
    public string locationID;
    public string displayName;

    [Header("Áudio")]
    public AudioClip locationMusic;
    public AudioClip locationAmbience;
}
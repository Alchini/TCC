using UnityEngine;
using System.Collections.Generic;


public class LocationHistoryTracker : MonoBehaviour
{
    public static LocationHistoryTracker Instance;
    private readonly HashSet<LocationSO> LocationsVisited = new HashSet<LocationSO>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RecordLocation(LocationSO locationSO)
    {
        LocationsVisited.Add(locationSO);

        Debug.Log("cabo  de chegar em" + locationSO.displayName);
    }


    public bool HasVisited(LocationSO locationSO)
    {
        return LocationsVisited.Contains(locationSO);
    }
}

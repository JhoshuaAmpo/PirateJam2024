using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Must be sorted in order. 0 = first spawn point, 1 = second spawn point,...")]
    private List<SpawnPointDetector> spawnPoints;

    private SpawnPointDetector currentSP;
    private int currentSPInd;

    private void Awake() {
        GetComponentsInChildren<SpawnPointDetector>(spawnPoints);
        currentSPInd = 0;
    }

    public void ActivateNewSpawnPoint(SpawnPointDetector sp) {
        int newSPInd = spawnPoints.IndexOf(sp);
        if (newSPInd == -1) {
            Debug.LogError(sp.gameObject + " is not under SpawnPoints");
            return;
        }
        if(newSPInd > currentSPInd) {
            currentSPInd = newSPInd;
        }
    }

    public Vector3 GetLatestSpawnPoint() {
        return spawnPoints[currentSPInd].transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointDetector : MonoBehaviour
{
    SpawnPointManager spawnPointManager;
    private void Awake() {
        spawnPointManager = transform.parent.GetComponent<SpawnPointManager>();
    }
    private void OnTriggerEnter(Collider other) {
        spawnPointManager.ActivateNewSpawnPoint(this);
    }
}
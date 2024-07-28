using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField]
    Canvas finishCanvas;
    BoxCollider bc;
    private void Awake() {
        bc = GetComponent<BoxCollider>(); 
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ProcessTheEnd();
        }
    }

    private void ProcessTheEnd() {
        PauseGame.Instance.Pause();
        finishCanvas.gameObject.SetActive(true);
    }
}

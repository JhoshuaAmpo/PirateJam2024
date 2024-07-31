using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;
    BGMManager bGMManager;

    bool alreadyTriggerd = false;

    private void Awake() {
        bGMManager = transform.root.GetComponent<BGMManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !alreadyTriggerd) {
            // bGMManager.AddToQueue(audioClip);
            bGMManager.PlayClip(audioClip);
            alreadyTriggerd = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    private int numIronIngots;

    
    private void Awake() {
        numIronIngots = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IronIngot")) {
            numIronIngots++;
            other.gameObject.SetActive(false);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLevelUp : MonoBehaviour
{
    [SerializeField]
    private List<int> nextLevelCost;
    private int expPoints;
    private int level = 0;

    private void Awake() {
        expPoints = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IronIngot")) {
            expPoints++;
            if (level+1 < nextLevelCost.Count && expPoints >= nextLevelCost[level]) {
                expPoints -= nextLevelCost[level];
                // Process level up
                Debug.Log("Congrats you leveled up!");
            }
            other.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    [Tooltip("How much exp the enemy drops")]
    private int exp;

    private void Start() {
        gameObject.SetActive(false);
    }

    public int GetExp() {
        return exp;
    }
}

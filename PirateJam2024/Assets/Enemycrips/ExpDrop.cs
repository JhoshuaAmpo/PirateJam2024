using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    [Tooltip("How much exp the enemy drops")]
    private int exp;

    public int GetExp() {
        return exp;
    }
}

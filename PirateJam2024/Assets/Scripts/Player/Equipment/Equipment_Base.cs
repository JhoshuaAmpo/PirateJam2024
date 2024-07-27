using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment_Base : MonoBehaviour
{
    protected Animator playerAnimator;
    protected virtual void Awake() {
        playerAnimator = transform.root.GetComponentInChildren<Animator>();
    }

    public abstract void ActivateObject();
}

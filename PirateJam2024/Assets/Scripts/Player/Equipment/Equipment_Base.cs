using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment_Base : MonoBehaviour
{
    public float attackCooldown;
    protected float timer = 0;
    protected Animator playerAnimator;

    
    protected virtual void Awake() {
        playerAnimator = transform.root.GetComponentInChildren<Animator>();
    }

    protected virtual void Update() {
        ProcessTimer();
    }

    public abstract void ActivateObject();

    protected void ProcessTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Max(0, timer);
        }
    }
}

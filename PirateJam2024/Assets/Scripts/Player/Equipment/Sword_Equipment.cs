using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Equipment : Equipment_Base
{
    public float sword_damage;

    List<Transform> enemiesInStrikeRange;
    Collider strikeBox;

    protected override void Awake() {
        base.Awake();
        enemiesInStrikeRange = new();
        strikeBox = GetComponent<Collider>();
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void ActivateObject()
    {
        playerAnimator.SetTrigger("Slash");
        AnimationClip nextClip = playerAnimator.GetCurrentAnimatorClipInfo(1)[0].clip;
        if (timer > 0) { return; }
        timer = attackCooldown;
        float smallestDist = 10000000f;
        Transform closestEnemy = null;
        // play sword sfx
        foreach(Transform enemy in enemiesInStrikeRange) {
            float curDist = Vector3.Distance(enemy.position, strikeBox.bounds.center);
            if (curDist < smallestDist) {
                smallestDist = curDist;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy) {
            // Debug.Log("Strinking enemy: " + closestEnemy.name);
            closestEnemy.GetComponent<EnemyHealth>().TakeDamage(sword_damage);
        }
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.name + " has entered striking range");
        enemiesInStrikeRange.Add(other.transform);
    }

    private void OnTriggerExit(Collider other) {
        enemiesInStrikeRange.Remove(other.transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Equipment : Equipment_Base
{
    List<Transform> enemiesInStrikeRange;
    Collider strikeBox;

    private void Awake() {
        enemiesInStrikeRange = new();
        strikeBox = GetComponent<Collider>();
    }
    public override void ActivateObject()
    {
        float smallestDist = 10000000f;
        Transform closestEnemy = null;
        // trigger sword strike anim
        // play sword sfx
        foreach(Transform enemy in enemiesInStrikeRange) {
            float curDist = Vector3.Distance(enemy.position, strikeBox.bounds.center);
            if (curDist < smallestDist) {
                smallestDist = curDist;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy) {
            Debug.Log("Strinking enemy: " + closestEnemy.name);
        }
        // closestEnemy.TakeDamage();
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.name + " has entered striking range");
        enemiesInStrikeRange.Add(other.transform);
    }

    private void OnTriggerExit(Collider other) {
        enemiesInStrikeRange.Remove(other.transform);
    }
}

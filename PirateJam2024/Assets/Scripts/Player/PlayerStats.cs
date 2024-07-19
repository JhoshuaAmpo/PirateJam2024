using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float attackPower;

    [SerializeField]
    private float attackSpeed;
    

    public float GetAttackPower(){
        return attackPower;
    }

    public void UpgradeAttackPower(float pwr){
        attackPower += pwr;
    }

}

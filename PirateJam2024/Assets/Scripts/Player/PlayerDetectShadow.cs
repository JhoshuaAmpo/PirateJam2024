using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetectShadow : MonoBehaviour
{
    [SerializeField]
    Light directionalLight;
    [SerializeField]
    Light otherLightSources;

    [SerializeField]
    float yOffset;

    PlayerHealth playerHealth;
    PlayerHands playerHands;

    private void Awake() {
        playerHealth = GetComponent<PlayerHealth>();
        playerHands = GetComponent<PlayerHands>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerHands.IsTorchOut() && InShadow()) {
            Debug.Log("I'm in the shadows!");
                playerHealth.TakeDamage(playerHealth.MaxHP);
            // if(playerHealth.CurrentHP > 0) {

            // }
        }
    }

    private bool InShadow(){
        Vector3 origin = new(transform.position.x, transform.position.y - yOffset, transform.position.z);
        Debug.DrawRay(origin, -directionalLight.transform.forward * 100, Color.yellow, 10);
        return Physics.Raycast(origin, -directionalLight.transform.forward, 100);
    }
}

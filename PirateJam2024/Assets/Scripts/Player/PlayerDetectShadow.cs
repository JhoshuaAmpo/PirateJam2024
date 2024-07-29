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
            // Debug.Log("I'm in the shadows!");
            playerHealth.TakeDamage(playerHealth.MaxHP);
        }
    }

    private bool InShadow(){
        Vector3 origin = new(transform.position.x, transform.position.y - yOffset, transform.position.z);
        // Debug.DrawRay(origin, -directionalLight.transform.forward * 100, Color.yellow, 10);
        bool a = Physics.Raycast(origin, -directionalLight.transform.forward, out RaycastHit hit, 100);
        if (a) {
            a = !hit.collider.CompareTag("enemy");
        }
        if (hit.collider) {
            Debug.Log("Hit: " + hit.collider.name);
        }
        return a;
    }
}

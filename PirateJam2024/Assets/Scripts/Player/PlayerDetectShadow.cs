using System.Collections;
using System.Collections.Generic;
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

    private void Awake() {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InShadow()) {
            Debug.Log("I'm in the shadows!");
        } else {

        }
    }

    private bool InShadow(){
        Vector3 origin = new(transform.position.x, transform.position.y - yOffset, transform.position.z);
        Debug.DrawRay(origin, -directionalLight.transform.forward * 100, Color.yellow, 10);
        return Physics.Raycast(origin, -directionalLight.transform.forward, 100);
    }
}

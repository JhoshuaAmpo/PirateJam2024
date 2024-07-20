using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUpgrade : MonoBehaviour
{
    PlayerActions playerActions;
    private int numIronIngots;


    private void Awake() {
        numIronIngots = 0;
        playerActions = new();
        playerActions.Menu.Enable();
        playerActions.Menu.UpgradeMenu.performed += ToggleUpgradeMenu;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IronIngot")) {
            numIronIngots++;
            other.gameObject.SetActive(false);
        }
    }

    private void ToggleUpgradeMenu(InputAction.CallbackContext context){
        Debug.Log("Menu Opened");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHands : MonoBehaviour
{
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    GameObject rightHand;

    [SerializeField]
    List<Equipment_Base> leftHandEquipment;

    [SerializeField]
    List<Equipment_Base> rightHandEquipment;

    private int leftHandIndex = 0;
    private int rightHandIndex = 0;

    PlayerActions playerActions;
    void Awake(){
        playerActions = new();
        playerActions.HandActions.Enable();
        playerActions.HandActions.UseLeftHand.performed += UseLeftHand;
        playerActions.HandActions.SwitchLeftHand.performed += SwitchLeftHand;
        playerActions.HandActions.UseRightHand.performed += UseRightHand;
        playerActions.HandActions.SwitchRightHand.performed += SwitchRightHand;
    }

    private void OnEnable() {
        playerActions.HandActions.Enable();
    }

    private void OnDisable() {
        playerActions.HandActions.Disable();
    }

    public void UseLeftHand(InputAction.CallbackContext context) {
        Debug.Log("Left hand clicked!");
    }

    public void UseRightHand(InputAction.CallbackContext context) {
        Debug.Log("Right hand clicked!");
    }

    public void SwitchLeftHand(InputAction.CallbackContext context) {
        Debug.Log("Left hand switched!");
        leftHandIndex = (leftHandIndex + 1) % 2;
    }

    public void SwitchRightHand(InputAction.CallbackContext context) {
        Debug.Log("Right hand switched!");
        rightHandIndex = (rightHandIndex + 1) % 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHands : MonoBehaviour
{
    [Header("Left Hand")]
    [SerializeField]
    GameObject leftHand;
    [SerializeField]
    List<Equipment_Base> leftHandEquipment;

    [Header("Right Hand")]
    [SerializeField]
    GameObject rightHand;
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

        foreach (var item in leftHandEquipment)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in rightHandEquipment)
        {
            item.gameObject.SetActive(false);
        }

        leftHandEquipment[leftHandIndex].gameObject.SetActive(true);
        rightHandEquipment[rightHandIndex].gameObject.SetActive(true);
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
        leftHandEquipment[leftHandIndex].gameObject.SetActive(false);
        leftHandIndex = (leftHandIndex + 1) % 2;
        leftHandEquipment[leftHandIndex].gameObject.SetActive(true);
    }

    public void SwitchRightHand(InputAction.CallbackContext context) {
        Debug.Log("Right hand switched!");
        rightHandEquipment[rightHandIndex].gameObject.SetActive(false);
        rightHandIndex = (rightHandIndex + 1) % 2;
        rightHandEquipment[rightHandIndex].gameObject.SetActive(true);
    }
}

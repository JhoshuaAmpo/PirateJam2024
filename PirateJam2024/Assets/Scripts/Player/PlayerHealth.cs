using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP { get; private set;}

    [SerializeField]
    private SpawnPointManager spawnPointManager;
    [SerializeField]
    private GameObject deathScreen;
    [SerializeField]
    private HUDBar hpBar;
    [SerializeField]
    private float hpGainedPerSecond;


    private CharacterController characterController;

    private void Awake() {
        CurrentHP = MaxHP;
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        Heal(hpGainedPerSecond * Time.deltaTime);
    }

    public void TakeDamage(float damage){
        CurrentHP -= damage;
        hpBar.SetBar(CurrentHP/MaxHP);
        if (CurrentHP <= 0) {
            ProcessDeath();
        }
    }

    public void Heal(float hpRegained){
        if (CurrentHP > 0) {
            CurrentHP += hpRegained;
            CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
            hpBar.SetBar(CurrentHP/MaxHP);
        }
    }

    public void UpgradeMaxHP(float hpGained) {
        MaxHP += hpGained;
        CurrentHP = MaxHP;
    }

    private void ProcessDeath() {
        PauseGame.Instance.Pause();
        Cursor.visible = true;
        deathScreen.SetActive(true);
    }

    public void Respawn() {
        Debug.Log("I have been clicked");
        deathScreen.SetActive(false);
        Cursor.visible = false;
        PauseGame.Instance.Resume();
        // if (PauseGame.Instance.isGamePaused) { 
        //     PauseGame.Instance.Resume();
        // }
        // CurrentHP = MaxHP;
        // characterController.enabled = false;
        // transform.position = spawnPointManager.GetLatestSpawnPoint();
        // characterController.enabled = true;
        
        // deathScreen.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP { get; private set;}

    [SerializeField]
    private SpawnPointManager spawnPointManager;
    [SerializeField]
    private GameObject deathScreen;

    private CharacterController characterController;

    private void Awake() {
        CurrentHP = MaxHP;
        characterController = GetComponent<CharacterController>();
    }

    public void TakeDamage(float damage){
        CurrentHP -= damage;
        if (CurrentHP <= 0) {
            ProcessDeath();
        }
    }

    public void Heal(float hpRegained){
        if (CurrentHP > 0) {
            CurrentHP += hpRegained;
            Mathf.Clamp(CurrentHP, 0, MaxHP);
        }
    }

    public void UpgradeMaxHP(float hpGained) {
        MaxHP += hpGained;
        CurrentHP = MaxHP;
    }

    private void ProcessDeath() {
        Debug.Log("Player died!");
        Respawn();
        PauseGame.Instance.Pause();
        deathScreen.SetActive(true);
    }

    public void Respawn() {
        if (PauseGame.Instance.isGamePaused) { 
            PauseGame.Instance.Resume();
        }
        characterController.enabled = false;
        transform.position = spawnPointManager.GetLatestSpawnPoint();
        characterController.enabled = true;
        deathScreen.SetActive(false);
        Debug.Log(gameObject + " has respawned at: " + spawnPointManager.GetLatestSpawnPoint());
    }
}

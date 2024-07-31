using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MainMenuTransition : MonoBehaviour
{
    [SerializeField]
    SceneLoader sceneLoader;
    [SerializeField]
    Canvas mainCanvas;
    [SerializeField]
    Animator fadeAnimator;

    List<CinemachineVirtualCamera> cameras;
    CinemachineBrain camBrain;
    

    private void Awake() {
        cameras = new();
        camBrain = Camera.main.GetComponent<CinemachineBrain>();
        GetComponentsInChildren<CinemachineVirtualCamera>(cameras);
        cameras[0].gameObject.SetActive(true);
        cameras[1].gameObject.SetActive(false);
    }

    public void PlayButton() {
        fadeAnimator.gameObject.SetActive(true);
        StartCoroutine(ProcessPlay());
    }

    private IEnumerator ProcessPlay() {
        cameras[0].gameObject.SetActive(false);
        cameras[1].gameObject.SetActive(true);
        mainCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(camBrain.m_DefaultBlend.m_Time + 0.5f);
        sceneLoader.LoadScene(1);
    }
}

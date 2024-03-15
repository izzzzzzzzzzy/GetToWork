using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Vector2 mainPlayerCoords;
    [SerializeField] private Vector3 mainCameraCoords;
    
    private Camera mainCamera;
    private SceneFade sceneFade;
    private PlayerController mainPlayer;

    // Start is called before the first frame update
    void Start()
    {   
        mainCamera = FindFirstObjectByType<Camera>();
        mainPlayer = FindFirstObjectByType<PlayerController>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneFade == null) {
            sceneFade = mainCamera.GetComponentInChildren<SceneFade>();
        }
    }

    public void Teleport(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(TeleportCor(player, nPlayerPos, nCameraPos));
    }

    public void StartMinigame(string sceneName, Vector2 exitCoords)
    {
        StartCoroutine(StartMinigameCor(sceneName, exitCoords));
    }

    public void EndMinigame()
    {
        StartCoroutine(EndMinigameCor());
    }

    IEnumerator TeleportCor(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSeconds(transitionTime);

        mainCamera.transform.position = new Vector3(nCameraPos.x, nCameraPos.y, -10);
        player.transform.position = nPlayerPos;
    }

    IEnumerator StartMinigameCor(string sceneName, Vector2 exitCoords)
    {
        mainCameraCoords = mainCamera.transform.position;
        mainPlayerCoords = exitCoords;

        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator EndMinigameCor()
    {
        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainScene");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = FindFirstObjectByType<Camera>();

        if (scene.name == "MainScene")
        {
            mainPlayer = FindFirstObjectByType<PlayerController>();
            mainPlayer.transform.position = mainPlayerCoords;
            mainCamera.transform.position = mainCameraCoords;
        }
    }
}

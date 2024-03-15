using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Vector2 mainPlayerCoords;
    [SerializeField] private Vector2 mainCameraCoords;
    
    private SceneFade sceneFade;

    // Start is called before the first frame update
    void Start()
    {   
        sceneFade = GetComponentInChildren<SceneFade>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        transform.position = nCameraPos;
        player.transform.position = nPlayerPos;
    }

    IEnumerator StartMinigameCor(string sceneName, Vector2 exitCoords)
    {
        mainCameraCoords = transform.position;
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

        transform.position = mainCameraCoords;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            FindFirstObjectByType<PlayerController>().transform.position = mainPlayerCoords;
        }
    }
}

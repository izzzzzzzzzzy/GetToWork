using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    MainManager mainManager;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Vector2 mainPlayerCoords;
    [SerializeField] private Vector3 mainCameraCoords;

    private Camera mainCamera;
    private SceneFade sceneFade;
    private MainPlayerController mainPlayer;
    public Canvas pauseMenu;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        mainManager = GetComponent<MainManager>();
        mainCamera = FindFirstObjectByType<Camera>();
        mainPlayer = FindFirstObjectByType<MainPlayerController>();

        mainCameraCoords = new(0, 0, -10);
        mainPlayerCoords = new(0, 0);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneFade == null) {
            sceneFade = mainCamera.GetComponentInChildren<SceneFade>();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                PlayGame();
            }
        }
        pauseMenu.gameObject.SetActive(isPaused);
    }

    public void EnterDoor(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(Teleport(player, nPlayerPos, nCameraPos));
    }

    public void StartMinigame(string sceneName, Vector2 exitCoords)
    {
        StartCoroutine(LoadMinigame(sceneName, exitCoords));
    }

    public void EndMinigame(int timeSec, int timeMin, int points)
    {
        int time = (mainManager.dayTimeLeftSeconds + (mainManager.dayTimeLeftMinutes * 60)) - (timeSec + (timeMin * 60));
        mainManager.dayTimeLeftSeconds = (int)time%60;
        mainManager.dayTimeLeftMinutes = (int)time/60;
        mainManager.money += points;
        StartCoroutine(LoadMainScene());
    }

    public void StartDay()
    {
        mainCameraCoords = new(0, -15, -10);
        mainPlayerCoords = new(0, -15);

        StartCoroutine(LoadMainScene());
    }

    IEnumerator Teleport(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSecondsRealtime(transitionTime);

        mainCamera.transform.position = new Vector3(nCameraPos.x, nCameraPos.y, -10);
        player.transform.position = nPlayerPos;
    }

    IEnumerator LoadMinigame(string sceneName, Vector2 exitCoords)
    {
        mainCameraCoords = mainCamera.transform.position;
        mainPlayerCoords = exitCoords;

        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadMainScene()
    {
        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene("MainScene");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = FindFirstObjectByType<Camera>();

        if (scene.name == "MainScene")
        {
            mainPlayer = FindFirstObjectByType<MainPlayerController>();
            mainPlayer.transform.position = mainPlayerCoords;
            mainCamera.transform.position = mainCameraCoords;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

}

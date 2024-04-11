using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    //MainManager mainManager;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private Vector2 mainPlayerCoords;
    [SerializeField] private Vector3 mainCameraCoords;

    private Camera mainCamera;
    private SceneFade sceneFade;
    private MainPlayerController mainPlayer;
    public Canvas pauseMenu;
    public GameObject pauseMenuActivateButton;
    private bool isPaused;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //mainManager = GetComponent<MainManager>();
        mainCamera = FindFirstObjectByType<Camera>();
        sceneFade = mainCamera.GetComponentInChildren<SceneFade>();
        mainPlayer = FindFirstObjectByType<MainPlayerController>();
        if(SceneManager.GetActiveScene().name == "StartScreen" || SceneManager.GetActiveScene().name == "EndOfDay"){
            pauseMenuActivateButton.SetActive(false);
        }
        else{
            pauseMenuActivateButton.SetActive(true);
        }

        mainCameraCoords = new(0, -15, -10);
        mainPlayerCoords = new(0, -15);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = FindFirstObjectByType<Camera>();
        }
        if (sceneFade == null) {
            sceneFade = mainCamera.GetComponentInChildren<SceneFade>();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "StartScreen" && SceneManager.GetActiveScene().name != "EndOfDay")
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
        else if(SceneManager.GetActiveScene().name != "StartScreen" && SceneManager.GetActiveScene().name != "EndOfDay"){
            pauseMenuActivateButton.SetActive(true);
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

    public void EndMinigame(float score)
    {
        MainManager.Instance.money += score > 0 ? score : 0;

        StartCoroutine(LoadScene("MainScene"));
    }

    public void StartDay()
    {
        mainCameraCoords = new(0, -15, -10);
        mainPlayerCoords = new(0, -15);

        MainManager.Instance.StartDay();

        StartCoroutine(LoadScene("MainScene"));
    }

    public void EndDay()
    {
        StartCoroutine(LoadScene("EndOfDay"));
    }

    IEnumerator Teleport(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSeconds(transitionTime);

        mainCamera.transform.position = new Vector3(nCameraPos.x, nCameraPos.y, -10);
        player.transform.position = nPlayerPos;
    }

    IEnumerator LoadMinigame(string sceneName, Vector2 exitCoords)
    {
        mainCameraCoords = mainCamera.transform.position;
        mainPlayerCoords = exitCoords;

        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadScene(string sceneName)
    {
        StartCoroutine(sceneFade.FadeScreen(transitionTime));
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
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

        if(scene.name == "StartScreen" || scene.name == "EndOfDay"){
            pauseMenuActivateButton.SetActive(false);
            PlayGame();
        }
        else{
            pauseMenuActivateButton.SetActive(true);
            PlayGame();
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

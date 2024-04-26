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

    [SerializeField] private Vector2 mainPlayerCoords;
    [SerializeField] private Vector3 mainCameraCoords;

    public Camera mainCamera;
    public SceneFade sceneFade;
    private MainPlayerController mainPlayer;
    public Canvas pauseMenu;
    public GameObject pauseMenuActivateButton;
    private bool isPaused;
    public AudioSource buttonSFX;
    private int limbIndex = -1;

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
        mainCamera = FindFirstObjectByType<Camera>();
        sceneFade = mainCamera.GetComponentInChildren<SceneFade>();
        mainPlayer = FindFirstObjectByType<MainPlayerController>();

        if(SceneManager.GetActiveScene().name == "StartScreen" || SceneManager.GetActiveScene().name == "EndOfDay" || SceneManager.GetActiveScene().name == "Backstory")
        {
            pauseMenuActivateButton.SetActive(false);
            print("false");

        } else {
            pauseMenuActivateButton.SetActive(true);
        }

        mainCameraCoords = new(0, -17, -10);
        mainPlayerCoords = new(0, -21);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = FindFirstObjectByType<Camera>();
        }
        if (sceneFade == null)
        {
            sceneFade = mainCamera.GetComponentInChildren<SceneFade>();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "StartScreen" && SceneManager.GetActiveScene().name != "EndOfDay" && SceneManager.GetActiveScene().name != "Backstory")
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
        else if(SceneManager.GetActiveScene().name != "StartScreen" && SceneManager.GetActiveScene().name != "EndOfDay" && SceneManager.GetActiveScene().name != "Backstory"){
            pauseMenuActivateButton.SetActive(true);
        }
        pauseMenu.gameObject.SetActive(isPaused);
    }

    public void EnterDoor(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(Teleport(player, nPlayerPos, nCameraPos));
    }

    public void StartMinigame(string sceneName, Vector2 exitCoords, int limbIndex)
    {
        this.limbIndex = limbIndex;
        StartCoroutine(LoadMinigame(sceneName, exitCoords));
    }

    public void EndMinigame(float score, string[] limbs)
    {
        MainManager.Instance.money += score > 0 ? score : 0;
        if (limbIndex != -1)
        {
            MainManager.Instance.limbHealths[limbIndex] -= (int)(score / 2) / limbs.Length;
            limbIndex = -1;
        }
        //for limb in limbs{
        //    MainManager.Instance.limbHealth -= score/len(limbs)
        //}
        StartCoroutine(LoadScene("MainScene"));
    }

    public void StartDay()
    {
        mainCameraCoords = new(0, -17, -10);
        mainPlayerCoords = new(0, -21);
        StartCoroutine(LoadScene("MainScene"));
    }

    public void EndDay()
    {
        StartCoroutine(LoadScene("EndOfDay"));
    }

    public void PlayBackstory()
    {
        StartCoroutine(LoadScene("Backstory"));
    }

    IEnumerator Teleport(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        StartCoroutine(sceneFade.FadeScreen());
        yield return new WaitForSeconds(1);

        mainCamera.transform.position = new Vector3(nCameraPos.x, nCameraPos.y, -10);
        player.transform.position = nPlayerPos;
    }

    IEnumerator LoadMinigame(string sceneName, Vector2 exitCoords)
    {
        mainCameraCoords = mainCamera.transform.position;
        mainPlayerCoords = exitCoords;

        StartCoroutine(sceneFade.FadeScreen());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadScene(string sceneName)
    {
        StartCoroutine(sceneFade.FadeScreen());
        yield return new WaitForSeconds(1);
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
        buttonSFX = this.GetComponentInChildren<AudioSource>();
        buttonSFX.Play();
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

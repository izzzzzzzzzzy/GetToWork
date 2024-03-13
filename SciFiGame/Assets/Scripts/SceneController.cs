using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] private float transitionTime = 1f;
    
    private SceneFade sceneFade;

    // Start is called before the first frame update
    void Start()
    {   
        DontDestroyOnLoad(gameObject);

        sceneFade = GetComponentInChildren<SceneFade>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Teleport(GameObject player, Vector2 nPlayerPos, Vector2 nCameraPos)
    {
        sceneFade.FadeOut();
        yield return new WaitForSeconds(transitionTime);
        transform.position = nCameraPos;
        player.transform.position = nPlayerPos;
        sceneFade.FadeIn();
    }

    public IEnumerator ChangeScene(string sceneName)
    {
        sceneFade.FadeOut();
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
        sceneFade.FadeIn();
    }
}

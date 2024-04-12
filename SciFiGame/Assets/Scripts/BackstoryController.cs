using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackstoryController : MonoBehaviour
{
    [SerializeField] private Vector3[] backstoryCoords = new Vector3[6];

    private bool waiting = false;
    private int index = 0;

    SceneFade sceneFade;
    Camera mainCamera;
    SceneController sceneController;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = SceneController.Instance;
        sceneFade = FindFirstObjectByType<SceneFade>();
        mainCamera = FindFirstObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting && Input.GetKeyDown(KeyCode.E))
        {
            if (index == 6)
            {
                sceneController.StartDay();
            }
            else
            {
                waiting = true;
                StartCoroutine(sceneFade.FadeScreen());
                StartCoroutine(SwitchImage());
            }
        }
    }

    IEnumerator SwitchImage()
    {
        yield return new WaitForSeconds(1);

        mainCamera.transform.position = backstoryCoords[index++];
        
        waiting = false;
    }



}

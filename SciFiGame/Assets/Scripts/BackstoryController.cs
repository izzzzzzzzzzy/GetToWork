using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackstoryController : MonoBehaviour
{
    [SerializeField] private Vector3[] backstoryCoords = new Vector3[6];

    private int index = 0;

    SceneController sceneController;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = SceneController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (index == 6)
            {
                sceneController.StartDay();
            }
            else
            {
                sceneController.MoveCamera(backstoryCoords[index++]);
            }
        }
    }
}

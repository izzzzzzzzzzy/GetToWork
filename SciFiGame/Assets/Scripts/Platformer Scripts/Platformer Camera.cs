using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    Rigidbody2D playerRB;
    MainManager mainManager;

    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool hasXBounds;
    [SerializeField] private bool hasYBounds;
    [SerializeField] private float[] xRange = new float[2];
    [SerializeField] private float[] yRange = new float[2];
    [SerializeField] private float damping = 0.25f;
    [SerializeField] private float lookAheadMultiplier = 0.25f;
    [SerializeField] private float transitionDelay;

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;
    private Vector3 distance;
    public Image[] UIimages;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < UIimages.Length; i++) {
            UIimages[i].enabled = false;
        }

        if (!hasXBounds) {
            xRange[0] = float.MinValue;
            xRange[1] = float.MaxValue;
        }

        if (!hasYBounds) {
            yRange[0] = float.MinValue;
            yRange[1] = float.MaxValue;
        }
    }

    private void FixedUpdate() {
        if (player == null)
        {
            player = FindFirstObjectByType<PlatformingPlayerController>().GetComponent<Transform>();
            playerRB = player.GetComponent<Rigidbody2D>();
        } 

        targetPosition = player.position + offset;

        targetPosition.x += playerRB.velocity.x * lookAheadMultiplier;

        if (playerRB.velocity.y < 0) {
            targetPosition.y += playerRB.velocity.y * lookAheadMultiplier;
        }

        if (targetPosition.x < xRange[0]) {
            targetPosition.x = xRange[0];
        } else if (targetPosition.x > xRange[1]) {
            targetPosition.x = xRange[1];
        }

        if (targetPosition.y < yRange[0]) {
            targetPosition.y = yRange[0];
        } else if (targetPosition.y > yRange[1]) {
            targetPosition.y = yRange[1];
        }

        distance = targetPosition - transform.position;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping / distance.magnitude);
    }
}


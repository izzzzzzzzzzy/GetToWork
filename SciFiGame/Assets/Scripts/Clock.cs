using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private float dayTime = 180f;
    [SerializeField] private GameObject hand;

    public void SetAngle(float timeRemaining)
    {
        float angle = timeRemaining / dayTime * 360;
        hand.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

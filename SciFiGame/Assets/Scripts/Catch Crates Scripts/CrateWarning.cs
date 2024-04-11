using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateWarning : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForAnim());
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

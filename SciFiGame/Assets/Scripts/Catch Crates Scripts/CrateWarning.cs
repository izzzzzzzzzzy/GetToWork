using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateWarning : MonoBehaviour
{
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private GameObject crate;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForAnim());
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(lifetime);
        Instantiate(crate, transform.position + (2 * Vector3.up), Quaternion.identity);
        Destroy(gameObject);
    }
}

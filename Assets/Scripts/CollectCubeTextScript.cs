using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCubeTextScript : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(AnimCoroutine());
    }
    IEnumerator AnimCoroutine()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
    public void FixedUpdate()
    {
        transform.Translate(-0.05f, 0.05f, 0.3f-0.05f);
    }
}

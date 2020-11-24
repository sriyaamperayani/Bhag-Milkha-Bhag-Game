using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForPlatform());
    }
    IEnumerator WaitForPlatform()
    {
        yield return new WaitForSeconds(4f);
        transform.Translate(0, 0, -15f * Time.deltaTime);
        if (transform.localPosition.z <= -50f)
        {
            transform.position = new Vector3(0, 0, 150);
        }
    }
}

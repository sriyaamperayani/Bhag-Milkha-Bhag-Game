using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playertransform;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        distance = this.transform.position - playertransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playertransform.position != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, playertransform.position + distance, 0.2f);
        }
    }
}
